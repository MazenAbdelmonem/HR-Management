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
            Employee existingEmployee = await dbContext.Employees.FirstOrDefaultAsync(x => x.employeeId == id);
            if (existingEmployee == null)
            {
                return null;
            }
            existingEmployee.Name = employee.Name;
            existingEmployee.Department = employee.Department;
            existingEmployee.Role = employee.Role;
            await dbContext.SaveChangesAsync();
            return existingEmployee;
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
        public async Task<List<Employee>> SearchByName(string? name)
        {
            var employee = dbContext.Employees.AsQueryable();
            if (string.IsNullOrWhiteSpace(name) == false)
            {
                
                employee = employee.Where(x => x.Name.Contains(name));
                
            }
            return await employee.ToListAsync();

        }
    }
}
