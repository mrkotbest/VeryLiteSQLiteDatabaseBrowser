using System;
using System.Data;
using System.Windows.Forms;

namespace SQLiteApp
{
    public partial class MainForm : Form
	{
        private static DatabaseManager _dbManager;
		private static BindingSource _bindingSource;

        public MainForm() => InitializeComponent();

		private void MainForm_Load(object sender, EventArgs e)
		{
            _dbManager = new DatabaseManager();
			UpdateDataBinding();
        }

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

        private void UpdateDataBinding(DataTable dataTable = null)
        {
            try
            {
                TextBox tb;
                foreach (Control control in gbOperations.Controls)
                {
                    if (control.GetType() == typeof(TextBox))
                    {
                        tb = (TextBox)control;
                        tb.DataBindings.Clear();
                        tb.Text = string.Empty;
                    }
                }

                if (dataTable == null) dataTable = _dbManager.GetEmployeesDataTable();
                _bindingSource = new BindingSource() { DataSource = dataTable };
                mainGrid.DataSource = _bindingSource;

                tbAutoId.DataBindings.Add("Text", _bindingSource, "AutoId");
                tbFirstName.DataBindings.Add("Text", _bindingSource, "FirstName");
                tbLastName.DataBindings.Add("Text", _bindingSource, "LastName");
                tbJobTitle.DataBindings.Add("Text", _bindingSource, "JobTitle");
                tbEmail.DataBindings.Add("Text", _bindingSource, "Email");
                tbPhone.DataBindings.Add("Text", _bindingSource, "Phone");

                if (mainGrid.Columns["CreatedDate"] != null) mainGrid.Columns["CreatedDate"].Visible = false;
                if (mainGrid.Columns["ModifiedDate"] != null) mainGrid.Columns["ModifiedDate"].Visible = false;
                mainGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                mainGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                mainGrid.Enabled = true;

                foreach (DataGridViewColumn column in mainGrid.Columns)
                    column.Width = (mainGrid.Width / mainGrid.Columns.Count) - 5;
                mainGrid.Columns[0].Width = 40; // AutoId Column

                DisplayPosition();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"DataBinding Error: {ex.Message}", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayPosition()
        {
            if (_bindingSource != null) tssPosition.Text = $"Position: {_bindingSource.Position + 1}/{_bindingSource.Count}";
        }

		#region Movements
		private void btnMoveFirst_Click(object sender, EventArgs e)
		{
			_bindingSource.MoveFirst();
			DisplayPosition();
		}

		private void btnMovePrevious_Click(object sender, EventArgs e)
		{
			_bindingSource.MovePrevious();
			DisplayPosition();
		}

		private void btnMoveNext_Click(object sender, EventArgs e)
		{
			_bindingSource.MoveNext();
			DisplayPosition();
		}

		private void btnMoveLast_Click(object sender, EventArgs e)
		{
			_bindingSource.MoveLast();
			DisplayPosition();
		}
		#endregion

		#region Components
        private void mainGrid_SelectionChanged(object sender, EventArgs e) => DisplayPosition();

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

        private void contextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_bindingSource.Current is DataRowView row)
            {
                contextMenu.Items.Clear();
                contextMenu.Items.Add(new ToolStripStaticItem($"Created Date: {row["CreatedDate"]}"));
                contextMenu.Items.Add(new ToolStripStaticItem($"Modified Date: {row["ModifiedDate"]}"));
            }
        }
		#endregion

		#region CRUD Operations
		private void btnDelete_Click(object sender, EventArgs e)
		{
            if (mainGrid.SelectedRows.Count > 0)
            {
                if (btnAdd.Text == "Cancel") return;

                var autoId = tbAutoId.Text.Trim();

                if (string.IsNullOrEmpty(autoId))
                {
                    MessageBox.Show("Select the record", "SQLite (DELETE)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //var row = mainGrid.SelectedRows[0];
                //int autoId = Convert.ToInt32(row.Cells["AutoId"].Value);

                try
                {
                    if (MessageBox.Show($"Delete selected record (#{autoId})?", "SQLite (DELETE)",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        bool result = _dbManager.DeleteEmployee(Convert.ToInt32(autoId));
                        if (result) UpdateDataBinding();
                        else MessageBox.Show("Failed to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

		private void btnAdd_Click(object sender, EventArgs e)
		{
            try
            {
                if (btnAdd.Text == "Add New")
				{
					btnAdd.Text = "Cancel";
					tssPosition.Text = "Position: 0/0";
					mainGrid.ClearSelection();
					mainGrid.Enabled = false;
				}
				else if (btnAdd.Text == "Cancel")
				{
					btnAdd.Text = "Add New";
					UpdateDataBinding();
					return;
				}

                TextBox tb;
				foreach (Control control in gbOperations.Controls)
				{
					if (control.GetType() == typeof(TextBox))
					{
						tb = (TextBox)control;
						tb.DataBindings.Clear();
						tb.Text = string.Empty;
						if (tb.Name.Equals("tbFirstName") && tb.CanFocus) tb.Focus();
					}
				}
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

		private void btnSave_Click(object sender, EventArgs e)
		{
            if (string.IsNullOrEmpty(tbFirstName.Text.Trim()) ||
                string.IsNullOrEmpty(tbLastName.Text.Trim()) ||
                string.IsNullOrEmpty(tbJobTitle.Text.Trim()) ||
                string.IsNullOrEmpty(tbEmail.Text.Trim()))
            {
                MessageBox.Show("Fill in empty fields", "Add New Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var employee = new Employee
            {
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                JobTitle = tbJobTitle.Text,
                Email = tbEmail.Text,
                Phone = tbPhone.Text,
                CreatedDate = btnAdd.Text.Equals("Cancel") ? DateTime.UtcNow.ToString() : ((DataRowView)_bindingSource.Current)["CreatedDate"].ToString(),
                ModifiedDate = DateTime.UtcNow.ToString()
            };

            try
            {
                if (btnAdd.Text.Equals("Add New"))
                {
                    var autoId = tbAutoId.Text.Trim();
                    if (string.IsNullOrEmpty(autoId))
                    {
                        MessageBox.Show("Select the record");
                        return;
                    }
                    employee.AutoId = Convert.ToInt32(autoId);

                    if (MessageBox.Show($"Update selected record (#{autoId})?", "SQLite (UPDATE)",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        bool result = _dbManager.UpdateEmployee(employee);
                        if (result) UpdateDataBinding();
                        else MessageBox.Show("Failed to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (btnAdd.Text.Equals("Cancel"))
                {
                    if (MessageBox.Show("Add new record?", "SQLite (INSERT)",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool result = _dbManager.AddEmployee(employee);
                        if (result)
                        {
                            UpdateDataBinding();
                            _bindingSource.MoveLast();
                            btnAdd.Text = "Add New";
                        }
                        else MessageBox.Show("Failed to add", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

		private void btnRefresh_Click(object sender, EventArgs e)
		{
            if (btnAdd.Text.Equals("Cancel")) return;
            UpdateDataBinding();
        }

		private void btnExit_Click(object sender, EventArgs e) => Application.Exit();

		private void btnSearch_Click(object sender, EventArgs e)
		{
            if (btnAdd.Text == "Cancel") return;

            string searchTerm = tbSearch.Text.Trim();
            try
            {
                UpdateDataBinding(string.IsNullOrEmpty(searchTerm) ? null : _dbManager.SearchEmployees(searchTerm));
                DisplayPosition();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during search: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
