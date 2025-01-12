namespace HR_Management.API.Models.Domin
{
    public class Employee
    {
        public int employeeId { get; set; }
        public string Name { get; set; } // Employee Name
        public string Role { get; set; }   // Job Title
        public string Department { get; set; }  
        public DateTime DateOfJoining { get; set; }  //  Joining Date

        // Navigation Properties
        public ICollection<Attendance> Attendances { get; set; }
        public  ICollection<EmployeeRole> EmployeeRoles { get; set; }
    }
}
