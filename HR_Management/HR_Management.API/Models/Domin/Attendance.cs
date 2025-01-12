namespace HR_Management.API.Models.Domin
{
    public class Attendance
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; } 
        public DateTime Date { get; set; } // Date of attendance
        public DateTime? CheckInTime { get; set; } // Entry time
        public DateTime? CheckOutTime { get; set; } // Check out time
        public bool IsAbsent { get; set; } 
        public double WorkingHours { get; set; } 

        // Navigation Properties
        public Employee Employee { get; set; } // علاقة مع الموظف
    }
}
