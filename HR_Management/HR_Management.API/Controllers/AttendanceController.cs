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
    }
}
