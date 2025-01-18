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
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequestDto EmployeeRequestDto)
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
        [HttpGet]
        public async Task<IActionResult> GitAll()
        {
            List<Employee> EmployeesDomin = await employeeRepository.GetAll();
            List<EmployeeDto> EmployeesDto = new List<EmployeeDto>();
            foreach (Employee employee in EmployeesDomin)
            {
                EmployeeDto employeeDto = new EmployeeDto()
                {
                    employeeId = employee.employeeId,
                    Name = employee.Name,
                    Department = employee.Department,
                    Role = employee.Role,
                    DateOfJoining = employee.DateOfJoining
                };
                EmployeesDto.Add(employeeDto);
            }
            return Ok(EmployeesDto);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GitById([FromRoute] int id)
        {
            Employee employeeDomin  = await employeeRepository.GetById(id);
            if (employeeDomin == null)
            {
                return BadRequest("Not Fond");
            }

            EmployeeDto employeeDto = new EmployeeDto()
            {
                employeeId = employeeDomin.employeeId,
                Name = employeeDomin.Name,
                Department = employeeDomin.Department,
                Role = employeeDomin.Role,
                DateOfJoining = employeeDomin.DateOfJoining
            };

            return Ok(employeeDto);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, [FromBody] UpdateEmployeeRequestDto updateEmployeeRequestDto)
        {
            Employee employeeDmoin = new Employee()
            {
                Name = updateEmployeeRequestDto.Name,
                Department = updateEmployeeRequestDto.Department,
                Role = updateEmployeeRequestDto.Role
            };
            employeeDmoin = await employeeRepository.UpdateEmployee(id, employeeDmoin);
            if (employeeDmoin == null)
            {
                return BadRequest("Not found");
            }
            EmployeeDto employeeDto = new EmployeeDto()
            {
                employeeId = employeeDmoin.employeeId,
                Name = employeeDmoin.Name,
                Department = employeeDmoin.Department,
                Role = employeeDmoin.Role,
                DateOfJoining = employeeDmoin.DateOfJoining
            };
            return Ok(employeeDto);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            Employee employee = await employeeRepository.DeleteEmployee(id);
            if (employee == null)
            {
                return BadRequest("Not Found.");
            }
            EmployeeDto employeeDto = new EmployeeDto()
            {
                employeeId = employee.employeeId,
                Name = employee.Name,
                Department = employee.Department,
                Role = employee.Role,
                DateOfJoining = employee.DateOfJoining
            };
            return Ok(employeeDto);
        }
    }
}
