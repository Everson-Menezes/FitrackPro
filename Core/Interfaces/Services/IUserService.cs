
using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(Guid userId);
        Task CreateUserAsync(User user);
        Task<decimal> TrackDailyCaloriesAsync(Guid userId, DateTime date);
        Task<decimal> CalculateBMIAsync(Guid userId);
        Task SetWeightGoalAsync(Guid userId, decimal targetWeight);
        Task<User> UpdateByIdAsync(Guid userId);
    }
}
