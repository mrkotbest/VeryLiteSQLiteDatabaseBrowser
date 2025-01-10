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

        //public List<Employee> GetAllEmployees()
        //{
        //    const string query = "SELECT * FROM Employees ORDER BY AutoId ASC";
        //    var employees = new List<Employee>();

        //    using (var connection = GetConnection())
        //    using (var command = new SQLiteCommand(query, connection))
        //    using (var reader = command.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            employees.Add(new Employee
        //            {
        //                AutoId = Convert.ToInt32(reader["AutoId"]),
        //                FirstName = reader["FirstName"].ToString(),
        //                LastName = reader["LastName"].ToString(),
        //                JobTitle = reader["JobTitle"].ToString(),
        //                Email = reader["Email"].ToString(),
        //                Phone = reader["Phone"].ToString(),
        //                CreatedDate = reader["CreatedDate"].ToString(),
        //                ModifiedDate = reader["ModifiedDate"].ToString()
        //            });
        //        }
        //    }

        //    return employees;
        //}

        public bool AddEmployee(Employee employee)
        {
            const string query = "INSERT INTO Employees (FirstName, LastName, JobTitle, Email, Phone, CreatedDate, ModifiedDate) " +
                                 "VALUES (@FirstName, @LastName, @JobTitle, @Email, @Phone, @CreatedDate, @ModifiedDate)";

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

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
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

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteEmployee(int autoId)
        {
            const string query = "DELETE FROM Employees WHERE AutoId = @AutoId";

            using (var connection = GetConnection())
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@AutoId", autoId);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public DataTable SearchEmployees(string searchTerm)
        {
            const string query = "SELECT * FROM Employees WHERE FirstName LIKE @Keyword2 OR LastName LIKE @Keyword2 OR JobTitle LIKE @Keyword2 OR Email = @Keyword1 OR Phone LIKE @Keyword2 ORDER BY AutoId ASC";
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
