namespace HR_Management.API.Models.DTO
{
    public class EmployeeDto
    {
        public int employeeId { get; set; }
        public string Name { get; set; } // Employee Name
        public string Role { get; set; } // Admin, HR, Manager, Employee
        public int? ManagerId { get; set; }  // Nullable
        public string Department { get; set; }
        public DateTime DateOfJoining { get; set; }
    }
}
