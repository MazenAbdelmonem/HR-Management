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
            dynamic employeeDomin = new Employee()
            {
                Role = EmployeeRequestDto.Role,
                DateOfJoining = DateTime.Now,
                ManagerId = EmployeeRequestDto.ManagerId,
                Name = EmployeeRequestDto.Name,
                Email = EmployeeRequestDto.Email,
                Department = EmployeeRequestDto.Department,
            };
            var employeeDomin1 = await  employeeRepository.AddEmployee(employeeDomin);
            if(employeeDomin1 is string)
            {
                var x = employeeDomin1;
                return Ok(x);
            }
            EmployeeDto employeeDto = new EmployeeDto()
            {
                employeeId = employeeDomin1.employeeId,
                Name = employeeDomin1.Name,
                Email = employeeDomin1.Email,
                ManagerId = employeeDomin1.ManagerId,
                Department = employeeDomin1.Department,
                DateOfJoining = employeeDomin1.DateOfJoining,
                Role = employeeDomin1.Role,
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
                    ManagerId= employee.ManagerId,
                    DateOfJoining = employee.DateOfJoining
                };
                EmployeesDto.Add(employeeDto);
            }
            return Ok(EmployeesDto);
        }
        [HttpGet]
        [Route("by-id/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
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
                ManagerId = employeeDomin.ManagerId,
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
                Email = updateEmployeeRequestDto.Email,
                Role = updateEmployeeRequestDto.Role,
                ManagerId = updateEmployeeRequestDto.ManagerId
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
                ManagerId = employeeDmoin.ManagerId,
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
                ManagerId = employee.ManagerId,
                DateOfJoining = employee.DateOfJoining
            };
            return Ok(employeeDto);
        }
        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> SearchByName([FromQuery] string? name)
        {
            var employeesDomin = await employeeRepository.SearchByName(name);
            List<EmployeeDto> employeesDto = new List<EmployeeDto>();
            foreach(Employee employee in employeesDomin)
            {
                EmployeeDto employeeDto = new EmployeeDto()
                {
                    employeeId = employee.employeeId,
                    Name = employee.Name,
                    Department = employee.Department,
                    Role = employee.Role,
                    ManagerId = employee.ManagerId,
                    DateOfJoining = employee.DateOfJoining
                };
                employeesDto.Add(employeeDto);
            }
            return Ok(employeesDto);
        }
        [HttpGet]
        [Route("by-manager/{ManagerId}")]
        public async Task<IActionResult> GetTeamByManager([FromRoute] int ManagerId)
        {
            var employeesDomin = await employeeRepository.GetTeamByManager(ManagerId);
            if (employeesDomin.GetType() == typeof(string))
            {
                var employeeDto = employeesDomin;
                return Ok(employeeDto);
            }
            List<EmployeeDto> employeesDto = new List<EmployeeDto>();
            foreach (Employee employee in employeesDomin)
            {
                EmployeeDto employeeDto = new EmployeeDto()
                {
                    employeeId = employee.employeeId,
                    Name = employee.Name,
                    Department = employee.Department,
                    Role = employee.Role,
                    ManagerId = employee.ManagerId,
                    DateOfJoining = employee.DateOfJoining
                };
                employeesDto.Add(employeeDto);
            }
            return Ok(employeesDto);
        }
        [HttpGet]
        [Route("by-department/{Department}")]
        public async Task<IActionResult> GetTeamByDepartment([FromRoute] string Department)
        {
            var employeesDomin = await employeeRepository.GetTeamByDepartment(Department);
            List<EmployeeDto> employeesDto = new List<EmployeeDto>();
            foreach (Employee employee in employeesDomin)
            {
                EmployeeDto employeeDto = new EmployeeDto()
                {
                    employeeId = employee.employeeId,
                    Name = employee.Name,
                    Department = employee.Department,
                    Role = employee.Role,
                    ManagerId = employee.ManagerId,
                    DateOfJoining = employee.DateOfJoining
                };
                employeesDto.Add(employeeDto);
            }
            return Ok(employeesDto);
        }
    }
}
