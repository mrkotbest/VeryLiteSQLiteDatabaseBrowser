using System;
using System.Data;
using System.Windows.Forms;

namespace SQLiteApp
{
    public partial class MainForm : Form
	{
        private static DatabaseManager _dbManager;
        private DataTable _employeesTable;

        public MainForm() => InitializeComponent();

        private void InitializeGrid()
        {
            LoadData();

            mainGrid.AutoGenerateColumns = true;
            mainGrid.AllowUserToAddRows = true;
            mainGrid.EditMode = DataGridViewEditMode.EditProgrammatically;

            if (mainGrid.Columns["AutoId"] != null)
            {
                mainGrid.Columns["AutoId"].ReadOnly = true;
                mainGrid.Columns["AutoId"].Width = 40;
            }
            if (mainGrid.Columns["CreatedDate"] != null) mainGrid.Columns["CreatedDate"].Visible = false;
            if (mainGrid.Columns["ModifiedDate"] != null) mainGrid.Columns["ModifiedDate"].Visible = false;
        }

        private void LoadData(DataTable dataTable = null)
        {
            _employeesTable = dataTable ?? _dbManager.GetEmployeesDataTable();
            mainGrid.DataSource = _employeesTable;
        }

        private Employee ExtractEmployeeFromRow(DataGridViewRow row, bool isNew, out string validationError)
        {
            validationError = null;

            string firstName = row.Cells["FirstName"].Value?.ToString()?.Trim() ?? string.Empty;
            string lastName = row.Cells["LastName"].Value?.ToString()?.Trim() ?? string.Empty;
            string jobTitle = row.Cells["JobTitle"].Value?.ToString()?.Trim() ?? string.Empty;
            string email = row.Cells["Email"].Value?.ToString()?.Trim() ?? string.Empty;
            string phone = row.Cells["Phone"].Value?.ToString()?.Trim();

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(jobTitle) || string.IsNullOrEmpty(email))
            {
                validationError = "All required fields (FirstName, LastName, JobTitle, Email) must be filled!";
                return null;
            }

            string createdDate = isNew ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : row.Cells["CreatedDate"].Value?.ToString();
            string modifiedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int autoId = isNew ? 0 : int.TryParse(row.Cells["AutoId"].Value?.ToString(), out int id) ? id : -1;

            return new Employee(firstName, lastName, jobTitle, email, phone, createdDate, modifiedDate, autoId);
        }

        private void DisplayPosition()
        {
            if (mainGrid.Rows.Count > 0 && mainGrid.CurrentRow != null)
            {
                int currentPosition = mainGrid.CurrentRow.Index + 1;
                int totalCount = mainGrid.Rows.Count - (mainGrid.AllowUserToAddRows ? 1 : 0);
                tssPosition.Text = $"Position: {currentPosition}/{totalCount}";
            }
            else tssPosition.Text = "Position: 0/0";
        }

		#region FormComponentsEvents
		private void MainForm_Load(object sender, EventArgs e)
		{
            _dbManager = new DatabaseManager();
            InitializeGrid();
        }

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z) // Ctrl+Z check
            {
                if (UndoManager.CanUndo)
                {
                    UndoManager.Undo();
                    LoadData();
                }
                else MessageBox.Show("No actions to undo", "Undo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mainGrid_SelectionChanged(object sender, EventArgs e) => DisplayPosition();

        private void mainGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            var hitTestInfo = mainGrid.HitTest(e.X, e.Y);
            if (hitTestInfo.RowIndex >= 0 && mainGrid.SelectedRows.Count > 0 && mainGrid.SelectedRows[0].Index == hitTestInfo.RowIndex)
                contextMenu.Show(mainGrid, e.Location);
        }

        private void mainGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Delete) return;

            e.SuppressKeyPress = true;

            try
            {
                if (e.KeyCode == Keys.Enter) // Adding or update
                {
                    mainGrid.EndEdit();
                    bool changesMade = false;

                    foreach (DataGridViewRow row in mainGrid.Rows)
                    {
                        if (row.IsNewRow) continue;

                        bool isNewRow = string.IsNullOrEmpty(row.Cells["AutoId"].Value?.ToString());
                        var employee = ExtractEmployeeFromRow(row, isNewRow, out var validationError);
                        if (employee == null) continue;

                        if (isNewRow) changesMade |= _dbManager.AddEmployee(employee);
                        else changesMade |= _dbManager.UpdateEmployee(employee);
                    }

                    if (changesMade)
                        MessageBox.Show("Table updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (e.KeyCode == Keys.Delete) // Remove
                {
                    var row = mainGrid.CurrentRow;
                    if (row == null) return;

                    var autoId = row.Cells["AutoId"].Value?.ToString();
                    if (string.IsNullOrEmpty(autoId)) return;

                    if (MessageBox.Show($"Are you sure you want to delete #{autoId} record?", "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        _dbManager.DeleteEmployee(Convert.ToInt32(autoId));
                }

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing table: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mainGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) mainGrid.BeginEdit(true);
        }

        private void contextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (mainGrid.CurrentRow is DataGridViewRow row)
            {
                contextMenu.Items.Clear();
                contextMenu.Items.Add(new ToolStripStaticItem($"Created Date: {row.Cells["CreatedDate"].Value?.ToString()}"));
                contextMenu.Items.Add(new ToolStripStaticItem($"Modified Date: {row.Cells["ModifiedDate"].Value?.ToString()}"));
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            var searchQuery = tbSearch.Text.Trim();
            var dataTable = string.IsNullOrEmpty(searchQuery) ? null : _dbManager.SearchEmployees(searchQuery);
            LoadData(dataTable);
        }
        #endregion
    }
}
