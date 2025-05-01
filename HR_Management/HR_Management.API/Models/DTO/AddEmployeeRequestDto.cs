namespace HR_Management.API.Models.DTO
{
    public class AddEmployeeRequestDto
    {
        public string Name { get; set; } // Employee Name
        public string Role { get; set; } // Admin, HR, Manager, Employee
        public string Email { get; set; }
        public int? ManagerId { get; set; }  // Nullable
        public string Department { get; set; }
    }
}
