using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace SQLiteApp
{
	public partial class MainForm : Form
	{
		private static readonly string _dbPath = Application.StartupPath + "\\" + "EmployeesDb.db;";
		private static readonly string _connectionString = "Data Source=" + _dbPath + "Version=3;New=False;Compress=True;";
		
		private static readonly SQLiteConnection _cnn = new SQLiteConnection(_connectionString);
		private static SQLiteCommand _cmd = new SQLiteCommand(string.Empty, _cnn);
		private static string _sql;

		private static string _dbCommand = string.Empty;
		private static BindingSource _bindingSource;

		public MainForm() => InitializeComponent();

		private void MainForm_Load(object sender, EventArgs e)
		{
			this.tbAutoId.Enabled = false;

			OpenConnection();
			UpdateDataBinding();
			CloseConnection();
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			CloseConnection();
			Application.Exit();
		}

		private void OpenConnection()
		{
			if (_cnn.State == ConnectionState.Closed) _cnn.Open();
			//MessageBox.Show("The connection is: " + _cnn.State.ToString());
		}

		private void CloseConnection()
		{
			if (_cnn.State == ConnectionState.Open) _cnn.Close();
			//MessageBox.Show("The connection is: " + _cnn.State.ToString());
		}

		private void UpdateDataBinding(SQLiteCommand command = null)
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

				_dbCommand = "SELECT";
				_sql = "SELECT * FROM Employees ORDER BY AutoId ASC";

				if (command == null) _cmd.CommandText = _sql;
				else _cmd = command;

				SQLiteDataAdapter adapter = new SQLiteDataAdapter(_cmd);
				DataSet dataSet = new DataSet();
				adapter.Fill(dataSet, "Employees");

				_bindingSource = new BindingSource();
				_bindingSource.DataSource = dataSet.Tables["Employees"];

				// Simple Data Binding
				tbAutoId.DataBindings.Add("Text", _bindingSource, "AutoId");
				tbFirstName.DataBindings.Add("Text", _bindingSource, "FirstName");
				tbLastName.DataBindings.Add("Text", _bindingSource, "LastName");
				tbJobTitle.DataBindings.Add("Text", _bindingSource, "JobTitle");
				tbEmail.DataBindings.Add("Text", _bindingSource, "Email");
				tbPhone.DataBindings.Add("Text", _bindingSource, "Phone");

				mainGrid.Enabled = true;
				mainGrid.DataSource = _bindingSource;

				mainGrid.AutoResizeColumns((DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnsMode.AllCells);
				mainGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

				mainGrid.Columns[0].Width = 70;	// AutoId Column

				DisplayPosition();
			}
			catch (Exception ex)
			{
				MessageBox.Show("DataBinding Error: " + ex.Message.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void DisplayPosition()
		{
			tssPosition.Text = "Position: " + Convert.ToString(_bindingSource.Position + 1) + "/" + _bindingSource.Count.ToString();
		}

		private void AddCommandParameters()
		{
			_cmd.Parameters.Clear();
			_cmd.CommandText = _sql;

			_cmd.Parameters.AddWithValue("FirstName", tbFirstName.Text.Trim());
			_cmd.Parameters.AddWithValue("LastName", tbLastName.Text.Trim());
			_cmd.Parameters.AddWithValue("JobTitle", tbJobTitle.Text.Trim());
			_cmd.Parameters.AddWithValue("Email", tbEmail.Text.Trim());
			_cmd.Parameters.AddWithValue("Phone", tbPhone.Text.Trim());

			if (_dbCommand.ToUpper() == "UPDATE") _cmd.Parameters.AddWithValue("AutoId", tbAutoId.Text.Trim());
		}

		#region Movements
		private void btnMoveFirst_Click(object sender, EventArgs e)
		{
			_bindingSource?.MoveFirst();
			DisplayPosition();
		}

		private void btnMovePrevious_Click(object sender, EventArgs e)
		{
			_bindingSource?.MovePrevious();
			DisplayPosition();
		}

		private void btnMoveNext_Click(object sender, EventArgs e)
		{
			_bindingSource?.MoveNext();
			DisplayPosition();
		}

		private void btnMoveLast_Click(object sender, EventArgs e)
		{
			_bindingSource?.MoveLast();
			DisplayPosition();
		}
		#endregion

		#region GridFunctions
		private void mainGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			try { DisplayPosition(); }
			catch (Exception ex)
			{
				MessageBox.Show("CellMouseClick Error: " + ex.Message.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region CRUD Operations
		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (btnAdd.Text == "Cancel") return;

			if (tbAutoId.Text.Trim() == string.Empty || string.IsNullOrEmpty(tbAutoId.Text.Trim()))
			{
				MessageBox.Show("Please Select an Item from the List", "SQLite (DELETE)", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			OpenConnection();

			try
			{
				if (MessageBox.Show("ID: " + tbAutoId.Text.Trim() + " - Do you want to Delete Selected Record?", "SQLite (DELETE)",
						MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

				_dbCommand = "DELETE";
				_sql = "DELETE FROM Employees WHERE AutoId = @AutoId";

				_cmd.Parameters.Clear();
				_cmd.CommandText = _sql;
				_cmd.Parameters.AddWithValue("AutoId", tbAutoId.Text.Trim());

				int executeResult = _cmd.ExecuteNonQuery();
				if (executeResult == 1)
				{
					MessageBox.Show("SQL " + _dbCommand + "Query has been executed successfully", "SQLite (DELETE)", MessageBoxButtons.OK, MessageBoxIcon.Information);
					UpdateDataBinding();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("btnDelete Error: " + ex.Message.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				_dbCommand = string.Empty;
				CloseConnection();
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
				else
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
				MessageBox.Show("btnAdd Error: " + ex.Message.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(tbFirstName.Text.Trim()) ||
				string.IsNullOrEmpty(tbLastName.Text.Trim()) ||
				string.IsNullOrEmpty(tbJobTitle.Text.Trim()) ||
				string.IsNullOrEmpty(tbEmail.Text.Trim()))
			{
				MessageBox.Show("Please Fill in the Required Fields!", "Add New Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			OpenConnection();

			try
			{
				if (btnAdd.Text == "Add New")
				{
					if (tbAutoId.Text.Trim() == "" || string.IsNullOrEmpty(tbAutoId.Text.Trim()))
					{
						MessageBox.Show("Please Select an Item");
						return;
					}

					if (MessageBox.Show("ID: " + tbAutoId.Text.Trim() + " - Do you want to Update Selected Record?", "SQLite (UPDATE)",
						MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

					_dbCommand = "UPDATE";
					_sql = "UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, JobTitle = @JobTitle, Email = @Email, Phone = @Phone WHERE AutoId = @AutoId";

					AddCommandParameters();
				}
				else if (btnAdd.Text.Equals("Cancel"))
				{
					DialogResult result;
					result = MessageBox.Show("Do you want to Add a New Employee Record?", "SQLite (INSERT)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

					if (result == DialogResult.Yes)
					{
						_dbCommand = "INSERT";
						_sql = "INSERT INTO Employees(FirstName, LastName, JobTitle, Email, Phone) VALUES(@FirstName, @LastName, @JobTitle, @Email, @Phone)";
						AddCommandParameters();
					}
					else return;
				}

				int executeResult = _cmd.ExecuteNonQuery();
				if (executeResult == -1) MessageBox.Show("Data was not Saved!", "Failed to Save Data", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				else
				{
					MessageBox.Show("SQL " + _dbCommand + "Query has been executed successfully", "SQLite (SAVE)", MessageBoxButtons.OK, MessageBoxIcon.Information);
					UpdateDataBinding();
					btnAdd.Text = "Add New";
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("btnSave Error: " + ex.Message.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				_dbCommand = string.Empty;
				CloseConnection();
			}
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			if (btnAdd.Text.Equals("Cancel")) return;
			UpdateDataBinding();
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			CloseConnection();
			Application.Exit();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			if (btnAdd.Text == "Cancel") return;

			OpenConnection();

			try
			{
				if (string.IsNullOrEmpty(tbSearch.Text.Trim()))
				{
					UpdateDataBinding();
					return;
				}

				_sql = "SELECT * FROM Employees WHERE FirstName LIKE @Keyword2 OR LastName LIKE @Keyword2 OR JobTitle LIKE @Keyword2 OR Email = @Keyword1 OR Phone LIKE @Keyword2 ORDER BY AutoId ASC";

				_cmd.CommandType = CommandType.Text;
				_cmd.CommandText = _sql;
				_cmd.Parameters.Clear();

				string keyword = string.Format("%{0}%", tbSearch.Text);

				_cmd.Parameters.AddWithValue("Keyword1", tbSearch.Text);
				_cmd.Parameters.AddWithValue("Keyword2", keyword);

				UpdateDataBinding(_cmd);
			}
			catch (Exception ex)
			{
				MessageBox.Show("btnSearch Error: " + ex.Message.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				CloseConnection();
				tbSearch.Focus();
			}
		}
		#endregion
	}
}
