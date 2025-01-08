namespace HR_Management.API.Models.Domin
{
    public class Employee
    {
        public int employeeId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }
        public DateTime DateOfJoining { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
    }
}
