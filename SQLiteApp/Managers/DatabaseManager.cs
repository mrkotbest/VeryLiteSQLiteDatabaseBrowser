using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace SQLiteApp
{
    public sealed class DatabaseManager
    {
        private readonly string _connectionString;

        public DatabaseManager()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString;
        }

        private SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            return connection;
        }

        public DataTable GetEmployeesDataTable()
        {
            const string query = "SELECT * FROM Employees ORDER BY AutoId ASC";
            var dataTable = new DataTable();

            using (var connection = GetConnection())
            using (var command = new SQLiteCommand(query, connection))
            using (var adapter = new SQLiteDataAdapter(command))
            {
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public Employee GetEmployeeById(int autoId)
        {
            const string query = "SELECT * FROM Employees WHERE AutoId = @AutoId";

            using (var connection = GetConnection())
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@AutoId", autoId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var id = reader.GetInt32(reader.GetOrdinal("AutoId"));
                        var firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                        var lastName = reader.GetString(reader.GetOrdinal("LastName"));
                        var jobTitle = reader.GetString(reader.GetOrdinal("JobTitle"));
                        var email = reader.GetString(reader.GetOrdinal("Email"));
                        var phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString(reader.GetOrdinal("Phone"));
                        var createdDate = reader.GetString(reader.GetOrdinal("CreatedDate"));
                        var modifiedDate = reader.GetString(reader.GetOrdinal("ModifiedDate"));
                        return new Employee(firstName, lastName, jobTitle, email, phone, createdDate, modifiedDate, id);
                    }
                }
            }
            return null;
        }

        public bool AddEmployee(Employee employee)
        {
            try
            {
                const string query = "INSERT INTO Employees (FirstName, LastName, JobTitle, Email, Phone, CreatedDate, ModifiedDate) " +
                                     "VALUES (@FirstName, @LastName, @JobTitle, @Email, @Phone, @CreatedDate, @ModifiedDate)";
                const string idQuery = "SELECT last_insert_rowid()";

                using (var connection = GetConnection())
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@JobTitle", employee.JobTitle);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@Phone", employee.Phone);
                    command.Parameters.AddWithValue("@CreatedDate", employee.CreatedDate);
                    command.Parameters.AddWithValue("@ModifiedDate", employee.ModifiedDate);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        using (var idCommand = new SQLiteCommand(idQuery, connection))
                        {
                            var newAutoId = Convert.ToInt32(idCommand.ExecuteScalar());
                            if (newAutoId > 0)
                            {
                                UndoManager.AddAction("Add Employee", () => DeleteEmployee(newAutoId));
                                return true;
                            }
                        }
                    }
                }
            }
            catch { throw; }

            return false;
        }

        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                var oldEmployee = GetEmployeeById(employee.AutoId) ?? throw new Exception("Employee not found");

                const string query = "UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, JobTitle = @JobTitle, Email = @Email, Phone = @Phone, ModifiedDate = @ModifiedDate " +
                                     "WHERE AutoId = @AutoId";

                using (var connection = GetConnection())
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AutoId", employee.AutoId);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@JobTitle", employee.JobTitle);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@Phone", employee.Phone);
                    command.Parameters.AddWithValue("@ModifiedDate", employee.ModifiedDate);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        UndoManager.AddAction("Update Employee", () => UpdateEmployee(oldEmployee));
                        return true;
                    }
                }
            }
            catch { throw; }

            return false;
        }

        public bool DeleteEmployee(int autoId)
        {
            try
            {
                var employee = GetEmployeeById(autoId) ?? throw new Exception("Employee not found");

                const string query = "DELETE FROM Employees WHERE AutoId = @AutoId";

                using (var connection = GetConnection())
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AutoId", autoId);
                    if (command.ExecuteNonQuery() > 0)
                    {
                        UndoManager.AddAction("Delete Employee", () => AddEmployee(employee));
                        return true;
                    }
                }
            }
            catch { throw; }

            return false;
        }

        public DataTable SearchEmployees(string searchTerm)
        {
            const string query = "SELECT * FROM Employees WHERE AutoId LIKE @Keyword2 OR FirstName LIKE @Keyword2 OR LastName LIKE @Keyword2 OR JobTitle LIKE @Keyword2 OR Email = @Keyword1 OR Phone LIKE @Keyword2 ORDER BY AutoId ASC";
            var dataTable = new DataTable();

            using (var connection = GetConnection())
            using (var command = new SQLiteCommand(query, connection))
            {
                string keyword = $"%{searchTerm}%";
                command.Parameters.AddWithValue("@Keyword1", searchTerm);
                command.Parameters.AddWithValue("@Keyword2", keyword);

                using (var adapter = new SQLiteDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }
    }
}
