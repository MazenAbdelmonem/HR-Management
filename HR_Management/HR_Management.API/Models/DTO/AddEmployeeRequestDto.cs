﻿namespace HR_Management.API.Models.DTO
{
    public class AddEmployeeRequestDto
    {
        public string Name { get; set; } // Employee Name
        public string Role { get; set; }   // Job Title
        public string Department { get; set; }
    }
}
