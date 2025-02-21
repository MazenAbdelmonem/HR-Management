﻿using HR_Management.API.Models.Domin;

namespace HR_Management.API.Repositories
{
    public interface IAttendanceRepository
    {
        Task<Attendance> CreatAttendanceAsync(Attendance attendance);
        Task<List<Attendance>> GitAllAsync();
        Task<Attendance>? GitByIdAsync(int id);
        Task<Attendance>? UpdateAttendanceAsync(int id, Attendance attendance);
        Task<Attendance>? DeleteAttendanceAsync(int id);
    }
}
