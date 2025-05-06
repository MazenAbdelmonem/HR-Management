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
        public async Task<Attendance?> CreatAttendanceAsync(Attendance attendance)
        {
            if(await dbContext.Employees.FirstOrDefaultAsync(x => x.employeeId == attendance.EmployeeId) == null)
            {
                return null;
            }
            await dbContext.AddAsync(attendance);
            await dbContext.SaveChangesAsync();
            return attendance;
        }

        public async Task<Attendance?> DeleteAttendanceAsync(int id)
        {
            Attendance attendance = await dbContext.Attendances.Include(a => a.Employee).FirstOrDefaultAsync(x => x.Id == id);
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

        public async Task<Attendance?> GitByIdAsync(int id)
        {
            Attendance attendance = await dbContext.Attendances.Include(x => x.Employee).FirstOrDefaultAsync(x => x.Id == id);
            return attendance;
        }

        public async Task<dynamic?> UpdateAttendanceAsync(int id, Attendance attendance)
        {

            Attendance existingattendance = await dbContext.Attendances.Include(x => x.Employee).FirstOrDefaultAsync(x => x.Id == id);
            if (existingattendance == null)
            {
                return existingattendance;
            }
            if (await dbContext.Employees.FirstOrDefaultAsync(x => x.employeeId == attendance.EmployeeId) == null)
            {
                return "Employee Not Found";
            }

            
            existingattendance.EmployeeId  = attendance.EmployeeId;
            existingattendance.WorkingHours = attendance.WorkingHours;
            existingattendance.IsAbsent = attendance.IsAbsent;
            existingattendance.CheckInTime = attendance.CheckInTime;
            existingattendance.CheckOutTime = attendance.CheckOutTime;
            await dbContext.SaveChangesAsync();
            return existingattendance;

        }
        public async Task<List<Attendance>?> GetAttendanceByEmployeeId(int id)
        {
            Employee employee = await dbContext.Employees.FirstOrDefaultAsync(x=>x.employeeId==id);
            if (employee == null)
            {
                return null;
            }
            List<Attendance> attendances = await dbContext.Attendances
            .Include(a => a.Employee)
            .Where(x => x.EmployeeId == id)
            .ToListAsync();
            return attendances;
        }
    }
}
