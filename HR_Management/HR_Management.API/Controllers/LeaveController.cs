using HR_Management.API.Models.Domin;
using HR_Management.API.Models.DTO;
using HR_Management.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveRepository leaveRepository;

        public LeaveController(ILeaveRepository leaveRepository)
        {
            this.leaveRepository = leaveRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreatLeave([FromBody] AddLeaveRequestDto addLeaveRequestDto)
        {
            Leave leaveDomin = new Leave()
            {
                EmployeeId = addLeaveRequestDto.EmployeeId,
                LeaveType = addLeaveRequestDto.LeaveType,
                StartDate = addLeaveRequestDto.StartDate,
                EndDate = addLeaveRequestDto.EndDate,
                Status = addLeaveRequestDto.Status
            };
            leaveDomin = await leaveRepository.CreatLeaveAsync(leaveDomin);
            LeaveDto leaveDto = new LeaveDto()
            {
                Id = leaveDomin.Id,
                EmployeeId = leaveDomin.EmployeeId,
                LeaveType = leaveDomin.LeaveType,
                StartDate = leaveDomin.StartDate,
                EndDate = leaveDomin.EndDate,
                Employee = leaveDomin.Employee,
                Status = leaveDomin.Status
            };
            return Ok(leaveDto);
        }
        [HttpGet]
        public async Task<IActionResult> GitAll()
        {
            List<Leave> leavesDomin = await leaveRepository.GetAllAsync();
            List<LeaveDto> leavesDto = new List<LeaveDto>();
            foreach (Leave leaveDomin in leavesDomin)
            {
                LeaveDto leaveDto = new LeaveDto()
                {
                    Id = leaveDomin.Id,
                    EmployeeId = leaveDomin.EmployeeId,
                    LeaveType = leaveDomin.LeaveType,
                    StartDate = leaveDomin.StartDate,
                    EndDate = leaveDomin.EndDate,
                    Employee = leaveDomin.Employee,
                    Status = leaveDomin.Status
                };
                leavesDto.Add(leaveDto);
            }
            return Ok(leavesDto);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GitLeaveByid([FromRoute] int id)
        {
            Leave leaveDomin = await leaveRepository.GetLeaveByIdAsync(id);
            if (leaveDomin == null)
            {
                return BadRequest("Leave record not found.");
            }
            LeaveDto leavingDto = new LeaveDto()
            {
                Id = leaveDomin.Id,
                EmployeeId = leaveDomin.EmployeeId,
                LeaveType = leaveDomin.LeaveType,
                StartDate = leaveDomin.StartDate,
                EndDate = leaveDomin.EndDate,
                Employee = leaveDomin.Employee,
                Status = leaveDomin.Status,
            };
            return Ok(leavingDto);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateLeave([FromRoute] int id, [FromBody] UpdateLeaveReqeustDto updateLeaveReqeustDto)
        {
            Leave leaveDomin = new Leave()
            {
                EmployeeId = updateLeaveReqeustDto.EmployeeId,
                LeaveType = updateLeaveReqeustDto.LeaveType,
                StartDate = updateLeaveReqeustDto.StartDate,
                EndDate = updateLeaveReqeustDto.EndDate,
                Status = updateLeaveReqeustDto.Status
            };
            leaveDomin = await leaveRepository.UpdateLeaveAsync(id, leaveDomin);
            if (leaveDomin == null)
            {
                return BadRequest("Leave record not found.");
            }
            LeaveDto leavingDto = new LeaveDto()
            {
                Id = leaveDomin.Id,
                EmployeeId = leaveDomin.EmployeeId,
                LeaveType = leaveDomin.LeaveType,
                StartDate = leaveDomin.StartDate,
                EndDate = leaveDomin.EndDate,
                Employee = leaveDomin.Employee,
                Status = leaveDomin.Status,
            };
            return Ok(leavingDto);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteLeave([FromRoute] int id)
        {
            Leave leaveDomin = await leaveRepository.DeleteLeaveAsync(id);
            if (leaveDomin == null)
            {
                return BadRequest("Leave record not found.");
            }
            LeaveDto leavingDto = new LeaveDto()
            {
                Id = leaveDomin.Id,
                EmployeeId = leaveDomin.EmployeeId,
                LeaveType = leaveDomin.LeaveType,
                StartDate = leaveDomin.StartDate,
                EndDate = leaveDomin.EndDate,
                Employee = leaveDomin.Employee,
                Status = leaveDomin.Status,
            };
            return Ok(leavingDto);
        }
    }
}
