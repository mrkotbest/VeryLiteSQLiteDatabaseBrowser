namespace SQLiteApp
{
    public sealed class Employee
    {
        public int AutoId { get; set; } = 0;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }

        public Employee(string firstName, string lastName, string jobTitle, string email, string phone, string createdDate, string modifiedDate, int autoId = -1)
        {
            FirstName = firstName;
            LastName = lastName;
            JobTitle = jobTitle;
            Email = email;
            Phone = phone;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            AutoId = autoId;
        }
    }
}
