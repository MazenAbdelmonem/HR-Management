using HR_Management.API.Models.Domin;

namespace HR_Management.API.Repositories
{
    public interface ILeaveRepository
    {
        Task<Leave> CreatLeaveAsync(Leave leave);
        Task<Leave>? GetLeaveByIdAsync(int id);
        Task<Leave> GetAllAsync();
        Task<Leave>? GUpdateLeaveAsync(int id, Leave leave);
        Task<Leave>? DeleteLeaveAsync(int id);
    }
}
