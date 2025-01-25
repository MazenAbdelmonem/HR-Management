using HR_Management.API.Models.Domin;

namespace HR_Management.API.Repositories
{
    public interface ILeaveRepository
    {
        Task<Leave> CreatLeaveAsync(Leave leave);
        Task<Leave>? GetLeaveByIdAsync(int id);
        Task<List<Leave>> GetAllAsync();
        Task<Leave>? UpdateLeaveAsync(int id, Leave leave);
        Task<Leave>? DeleteLeaveAsync(int id);
    }
}
