using HR_Management.API.Data;
using HR_Management.API.Models.Domin;
using Microsoft.EntityFrameworkCore;

namespace HR_Management.API.Repositories
{
    public class SQLLeaveRepository : ILeaveRepository
    {
        private readonly HRManagementDbContext dbContext;

        public SQLLeaveRepository(HRManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Leave?> CreatLeaveAsync(Leave leave)
        {
            if (await dbContext.Employees.FirstOrDefaultAsync(x => x.employeeId == leave.EmployeeId) == null)
            {
                return null;
            }
            await dbContext.Leaves.AddAsync(leave);
            await dbContext.SaveChangesAsync();
            return leave;
        }
        public async Task<List<Leave>> GetAllAsync()
        {
            List<Leave> leaves = await dbContext.Leaves.Include(a=>a.Employee).ToListAsync();
            return leaves;
            
        }

        public async Task<Leave?> GetLeaveByIdAsync(int id)
        {
            Leave leave = await dbContext.Leaves.Include(x => x.Employee).FirstOrDefaultAsync(a => a.Id == id);
            return leave;
        }

        public async Task<dynamic?> UpdateLeaveAsync(int id, Leave leave)
        {
            Leave existingleave = await dbContext.Leaves.Include(x => x.Employee).FirstOrDefaultAsync(a => a.Id == id);
            if (existingleave == null)
            {
                return existingleave;
            }
            if (await dbContext.Employees.FirstOrDefaultAsync(x => x.employeeId == leave.EmployeeId) == null)
            {
                return "Employee Not Found";
            }

            existingleave.StartDate = leave.StartDate;
            existingleave.EndDate = leave.EndDate;
            existingleave.Status = leave.Status;
            existingleave.EmployeeId = leave.EmployeeId;
            existingleave.LeaveType = leave.LeaveType;
            return existingleave;
        }
        public async Task<Leave>? DeleteLeaveAsync(int id)
        {
            Leave leave = await dbContext.Leaves.FirstOrDefaultAsync(a => a.Id == id);
            if (leave == null)
            {
                return leave;
            }
            dbContext.Leaves.Remove(leave);
            await dbContext.SaveChangesAsync();
            return leave;

        }
    }
}
