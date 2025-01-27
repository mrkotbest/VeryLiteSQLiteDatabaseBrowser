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

		private void MainForm_Load(object sender, EventArgs e)
		{
            _dbManager = new DatabaseManager();
            InitializeGrid();
        }

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

        private void InitializeGrid()
        {
            LoadData();

            mainGrid.AutoGenerateColumns = true;
            mainGrid.AllowUserToAddRows = true;
            mainGrid.EditMode = DataGridViewEditMode.EditOnEnter;
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

            var firstName = row.Cells["FirstName"].Value?.ToString()?.Trim() ?? string.Empty;
            var lastName = row.Cells["LastName"].Value?.ToString()?.Trim() ?? string.Empty;
            var jobTitle = row.Cells["JobTitle"].Value?.ToString()?.Trim() ?? string.Empty;
            var email = row.Cells["Email"].Value?.ToString()?.Trim() ?? string.Empty;
            var phone = row.Cells["Phone"].Value?.ToString()?.Trim();

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(jobTitle) || string.IsNullOrEmpty(email))
            {
                validationError = "All required fields (FirstName, LastName, JobTitle, Email) must be filled!";
                return null;
            }

            var createdDate = isNew ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : row.Cells["CreatedDate"].Value?.ToString();
            var modifiedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var autoId = isNew ? 0 : int.TryParse(row.Cells["AutoId"].Value?.ToString(), out var id) ? id : -1;

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

        private void mainGrid_SelectionChanged(object sender, EventArgs e)
        {
            DisplayPosition();
        }

        private void mainGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = mainGrid.HitTest(e.X, e.Y);
                if (hitTestInfo.RowIndex >= 0 && mainGrid.SelectedRows.Count > 0 && mainGrid.SelectedRows[0].Index == hitTestInfo.RowIndex)
                {
                    contextMenu.Show(mainGrid, e.Location);
                }
            }
        }

        private void mainGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                var row = mainGrid.CurrentRow;
                if (row != null)
                {
                    try
                    {
                        bool isNewRow = string.IsNullOrEmpty(row.Cells["AutoId"].Value?.ToString());
                        var employee = ExtractEmployeeFromRow(row, isNewRow, out var validationError);

                        if (employee == null)
                        {
                            MessageBox.Show(validationError, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            mainGrid.CancelEdit();
                            return;
                        }

                        if (isNewRow)
                        {
                            if (_dbManager.AddEmployee(employee)) MessageBox.Show("New record added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else MessageBox.Show("Failed to add new record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (_dbManager.UpdateEmployee(employee)) MessageBox.Show("Record successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else MessageBox.Show("Failed to update record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        mainGrid.EndEdit();
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error processing row: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                var row = mainGrid.CurrentRow;
                if (row != null)
                {
                    var autoId = mainGrid.CurrentRow.Cells["AutoId"].Value?.ToString();
                    if (string.IsNullOrEmpty(autoId)) return;

                    var confirmResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes) _dbManager.DeleteEmployee(Convert.ToInt32(autoId));
                    LoadData();
                }
            }
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
            var dataTable = string.IsNullOrEmpty(tbSearch.Text.Trim()) ? null : _dbManager.SearchEmployees(tbSearch.Text.Trim());
            LoadData(dataTable);
        }
        #endregion
    }
}
