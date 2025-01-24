using HR_Management.API.Data;
using HR_Management.API.Models.Domin;
using Microsoft.EntityFrameworkCore;

namespace HR_Management.API.Repositories
{
    public class SQLAttendanceRepository : IAttendanceRepository
    {
        private readonly HRManagementDbContext dbContext;

        public SQLAttendanceRepository(HRManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Attendance> CreatAttendanceAsync(Attendance attendance)
        {
            await dbContext.AddAsync(attendance);
            await dbContext.SaveChangesAsync();
            return attendance;
        }

        public async Task<Attendance>? DeleteAttendanceAsync(int id)
        {
            Attendance attendance = await dbContext.Attendances.FirstOrDefaultAsync(x => x.Id == id);
            if (attendance == null)
            {
                return attendance;
            }

            dbContext.Attendances.Remove(attendance);
            await dbContext.SaveChangesAsync();
            return attendance;
        }

        public async Task<List<Attendance>> GitAllAsync()
        {
            List<Attendance> attendances = await dbContext.Attendances.Include(x=>x.Employee).ToListAsync();
            return attendances;
        }

        public async Task<Attendance>? GitByIdAsync(int id)
        {
            Attendance attendance = await dbContext.Attendances.FirstOrDefaultAsync(x => x.Id == id);
            return attendance;
        }

        public async Task<Attendance>? UpdateAttendanceAsync(int id, Attendance attendance)
        {
            Attendance existingattendance = await dbContext.Attendances.FirstOrDefaultAsync(x => x.Id == id);
            if (existingattendance == null)
            {
                return attendance;
            }
            existingattendance.EmployeeId  = attendance.EmployeeId;
            existingattendance.WorkingHours = attendance.WorkingHours;
            existingattendance.IsAbsent = attendance.IsAbsent;
            existingattendance.CheckInTime = attendance.CheckInTime;
            existingattendance.CheckOutTime = attendance.CheckOutTime;
            await dbContext.SaveChangesAsync();
            return attendance;

        }
    }
}
