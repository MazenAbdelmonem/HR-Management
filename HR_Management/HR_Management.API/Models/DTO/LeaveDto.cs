using HR_Management.API.Models.Domin;

namespace HR_Management.API.Models.DTO
{
    public class LeaveDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; } // Leave start date
        public DateTime EndDate { get; set; } // Leave end date
        public string LeaveType { get; set; } // Type of leave (annual, sick, etc.)
        public string Status { get; set; } // Leave status (approved, denied, etc.)

        // Navigation Properties
        public Employee Employee { get; set; }
    }
}
