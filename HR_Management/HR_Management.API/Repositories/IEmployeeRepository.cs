using HR_Management.API.Models.Domin;

namespace HR_Management.API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<dynamic> AddEmployee(Employee employee);
        Task<dynamic?> UpdateEmployee(int id, Employee employee);
        Task<Employee?> DeleteEmployee(int id);
        Task<dynamic?> GetTeamByManager(int managerId);
        Task<List<Employee>?> GetTeamByDepartment(string Department);
        Task<Employee?> GetById(int id);
        Task<List<Employee>> SearchByName(string? name);
        Task<List<Employee>> GetAll();

    }
}
