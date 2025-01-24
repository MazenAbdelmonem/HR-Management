using HR_Management.API.Models.Domin;
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
    }
}
