namespace HR_Management.API.Models.DTO
{
    public class AddLeaveRequestDto
    {
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; } // Leave start date
        public DateTime EndDate { get; set; } // Leave end date
        public string LeaveType { get; set; } // Type of leave (annual, sick, etc.)
        public string Status { get; set; } // Leave status (approved, denied, etc.)
    }
}
