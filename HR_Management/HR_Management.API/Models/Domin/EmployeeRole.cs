namespace HR_Management.API.Models.Domin
{
    public class EmployeeRole
    {
        public int EmployeeId { get; set; } 
        public int RoleId { get; set; } 

        // Navigation Properties
        public Employee Employee { get; set; }
        public Role Role { get; set; }
    }
}
