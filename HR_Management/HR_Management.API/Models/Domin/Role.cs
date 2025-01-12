namespace HR_Management.API.Models.Domin
{
    public class Role
    {
        public int Id { get; set; } 
        public string Name { get; set; } // Role  Name (Admin, Manager, Employee)

        // Navigation Properties
        public ICollection<EmployeeRole> EmployeeRoles { get; set; } 
    }
}
