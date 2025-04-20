using HR_Management.API.Models.Domin;
using Microsoft.EntityFrameworkCore;

namespace HR_Management.API.Data
{
    public class HRManagementDbContext  : DbContext
    {
       public HRManagementDbContext(DbContextOptions<HRManagementDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        

    }
}
