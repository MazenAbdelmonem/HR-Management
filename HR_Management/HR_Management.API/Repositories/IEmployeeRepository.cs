using HR_Management.API.Models.Domin;

namespace HR_Management.API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee> DeleteEmployee(Employee employee);
        Task<Employee> GetById(int id);
        Task<Employee> GetAll();

    }
}
