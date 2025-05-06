using HR_Management.API.Models.Domin;
using HR_Management.API.Models.DTO;
using HR_Management.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace HR_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRepository attendanceRepository;

        public AttendanceController(IAttendanceRepository attendanceRepository)
        {
            this.attendanceRepository = attendanceRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreatAttendance(AddAttendanceRequestDto addAttendanceRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Attendance attendanceDomin = new Attendance()
            {
                IsAbsent = addAttendanceRequestDto.IsAbsent,
                EmployeeId = addAttendanceRequestDto.EmployeeId,
                CheckInTime = addAttendanceRequestDto.CheckInTime,
                CheckOutTime = addAttendanceRequestDto.CheckOutTime,
                WorkingHours = 0,
                Date = DateTime.Now
            };
            if(addAttendanceRequestDto.WorkingHours != null)
            {
                attendanceDomin.WorkingHours = (double)addAttendanceRequestDto.WorkingHours;
            }

            attendanceDomin = await attendanceRepository.CreatAttendanceAsync(attendanceDomin);
            if(attendanceDomin == null)
            {
                return BadRequest("Employee Not Found");
            }

            AttendanceDto attendanceDto = new AttendanceDto()
            {
                Id = attendanceDomin.Id,
                Date = attendanceDomin.Date,
                Employee = attendanceDomin.Employee,
                CheckInTime = attendanceDomin.CheckInTime,
                CheckOutTime = attendanceDomin.CheckOutTime,
                WorkingHours = attendanceDomin.WorkingHours,
                IsAbsent = attendanceDomin.IsAbsent
            };
            return Ok(attendanceDto);
        }
        [HttpGet]
        public async Task<IActionResult> GitAll()
        {
            List<Attendance> attendancesDomin =  await attendanceRepository.GitAllAsync();
            List<AttendanceDto> attendancesDto = new List<AttendanceDto>();
            foreach(Attendance attendanceDomin in attendancesDomin)
            {
                AttendanceDto attendanceDto = new AttendanceDto()
                {
                    Id = attendanceDomin.Id,
                    Date = attendanceDomin.Date,
                    Employee = attendanceDomin.Employee,
                    CheckInTime = attendanceDomin.CheckInTime,
                    CheckOutTime = attendanceDomin.CheckOutTime,
                    WorkingHours = attendanceDomin.WorkingHours,
                    IsAbsent = attendanceDomin.IsAbsent
                };
                attendancesDto.Add(attendanceDto);
            }
            return Ok(attendancesDto);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GitBiId(int id)
        {
            Attendance attendanceDomin = await attendanceRepository.GitByIdAsync(id);
            if (attendanceDomin == null)
            {
                return BadRequest("Attendance record not found.");
            }
            AttendanceDto attendanceDto = new AttendanceDto()
            {
                Id = attendanceDomin.Id,
                Date = attendanceDomin.Date,
                Employee = attendanceDomin.Employee,
                IsAbsent = attendanceDomin.IsAbsent,
                WorkingHours = attendanceDomin.WorkingHours,
                CheckInTime = attendanceDomin.CheckInTime,
                CheckOutTime = attendanceDomin.CheckOutTime
            };
            return Ok(attendanceDto);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAttendance([FromRoute] int id, [FromBody] UpdateAttendanceReqeustDto updateAttendanceReqeustDto)
        {
            var attendanceDomin = new Attendance()
            {
                EmployeeId = updateAttendanceReqeustDto.EmployeeId,
                IsAbsent = updateAttendanceReqeustDto.IsAbsent,
                WorkingHours = (double)updateAttendanceReqeustDto.WorkingHours,
                CheckInTime = updateAttendanceReqeustDto.CheckInTime,
                CheckOutTime = updateAttendanceReqeustDto.CheckOutTime,
                Date = DateTime.UtcNow
            };
            var attendanceDomin1 = await attendanceRepository.UpdateAttendanceAsync(id, attendanceDomin);
            if (attendanceDomin1 == null)
            {
                return BadRequest("Attendance record not found.");
            }

            if (attendanceDomin1 is string)
            {
                var x = attendanceDomin1;
                return Ok(x);
            }
            AttendanceDto attendanceDto = new AttendanceDto()
            {
                Id = attendanceDomin1.Id,
                Date = attendanceDomin1.Date,
                Employee = attendanceDomin1.Employee,
                IsAbsent = attendanceDomin1.IsAbsent,
                WorkingHours = attendanceDomin1.WorkingHours,
                CheckInTime = attendanceDomin1.CheckInTime,
                CheckOutTime = attendanceDomin1.CheckOutTime
            };
            return Ok(attendanceDto);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAttendance([FromRoute] int id)
        {
            Attendance attendanceDomin = await attendanceRepository.DeleteAttendanceAsync(id);
            if (attendanceDomin == null)
            {
                return BadRequest("Attendance record not found.");
            }
            AttendanceDto attendanceDto = new AttendanceDto()
            {
                Id = attendanceDomin.Id,
                Date = attendanceDomin.Date,
                Employee = attendanceDomin.Employee,
                IsAbsent = attendanceDomin.IsAbsent,
                WorkingHours = attendanceDomin.WorkingHours,
                CheckInTime = attendanceDomin.CheckInTime,
                CheckOutTime = attendanceDomin.CheckOutTime
            };
            return Ok(attendanceDto);
        }
        [HttpGet]
        [Route("GitByEmployee/{id}")]
        public async Task<IActionResult> GitByEmployee([FromRoute]int id)
        {
            List<Attendance> attendancesDomin = await attendanceRepository.GetAttendanceByEmployeeId(id);
            if(attendancesDomin == null)
            {
                return BadRequest("Employee Not Found");
            }

            List<AttendanceDto> attendancesDto = new List<AttendanceDto>();
            foreach (Attendance attendanceDomin in attendancesDomin)
            {
                AttendanceDto attendanceDto = new AttendanceDto()
                {
                    Id = attendanceDomin.Id,
                    Date = attendanceDomin.Date,
                    Employee = attendanceDomin.Employee,
                    CheckInTime = attendanceDomin.CheckInTime,
                    CheckOutTime = attendanceDomin.CheckOutTime,
                    WorkingHours = attendanceDomin.WorkingHours,
                    IsAbsent = attendanceDomin.IsAbsent
                };
                attendancesDto.Add(attendanceDto);
            }
            return Ok(attendancesDto);
        }
    }
}