using HR_Management.API.Data;
using HR_Management.API.Models.Domin;
using Microsoft.EntityFrameworkCore;

namespace HR_Management.API.Repositories
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly HRManagementDbContext dbContext;

        public SQLEmployeeRepository(HRManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
       
        public async Task<Employee> AddEmployee(Employee employee)
        {
            await dbContext.AddAsync(employee);
            await dbContext.SaveChangesAsync();
            return employee;
        }
        public async Task<Employee?> UpdateEmployee(int id, Employee employee)
        {
            Employee existEmployee = await dbContext.Employees.FirstOrDefaultAsync(x => x.employeeId == id);
            if (existEmployee == null)
            {
                return null;
            }
            existEmployee.Name = employee.Name;
            existEmployee.Department = employee.Department;
            existEmployee.Role = employee.Role;
            await dbContext.SaveChangesAsync();
            return existEmployee;
        }

        public async Task<Employee?> DeleteEmployee(int id)
        {
            Employee employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.employeeId == id);
            if (employee == null)
            {
                return null;
            }
            dbContext.Remove(employee);
            await dbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<List<Employee>> GetAll()
        {
            return await dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            Employee employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.employeeId == id);
            if(employee == null)
            {
                return null;
            }
            return employee;
        }
    }
}
