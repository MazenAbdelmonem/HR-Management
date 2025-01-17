using HR_Management.API.Models.Domin;
using HR_Management.API.Models.DTO;
using HR_Management.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AddEmployeeRequestDto EmployeeRequestDto)
        {
            Employee employeeDomin = new Employee()
            {
                Role = EmployeeRequestDto.Role,
                DateOfJoining = DateTime.Now,
                Name = EmployeeRequestDto.Name,
                Department = EmployeeRequestDto.Department,
            };
            employeeDomin = await  employeeRepository.AddEmployee(employeeDomin);
            EmployeeDto employeeDto = new EmployeeDto()
            {
                employeeId = employeeDomin.employeeId,
                Name = employeeDomin.Name,
                Department = employeeDomin.Department,
                DateOfJoining = employeeDomin.DateOfJoining,
                Role = employeeDomin.Role,
            };
            return Ok(employeeDto);
        }
    }
}
