using HR_Management.API.Models.Domin;

namespace HR_Management.API.Repositories
{
    public interface IAttendanceRepository
    {
        Task<Attendance?> CreatAttendanceAsync(Attendance attendance);
        Task<List<Attendance>> GitAllAsync();
        Task<Attendance?> GitByIdAsync(int id);
        Task<dynamic?> UpdateAttendanceAsync(int id, Attendance attendance);
        Task<Attendance?> DeleteAttendanceAsync(int id);
        Task<List<Attendance>?> GetAttendanceByEmployeeId(int id);
    }
}
