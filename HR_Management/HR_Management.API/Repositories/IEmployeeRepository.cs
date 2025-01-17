using HR_Management.API.Models.Domin;

namespace HR_Management.API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee?> UpdateEmployee(int id, Employee employee);
        Task<Employee?> DeleteEmployee(int id);
        Task<Employee?> GetById(int id);
        Task<List<Employee>> GetAll();

    }
}
