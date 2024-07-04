using App.DTOs;

namespace App.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(Guid userId);
        Task CreateUserAsync(CreateUserDto createUserDto);
        Task<decimal> TrackDailyCaloriesAsync(Guid userId, DateTime date);
        Task<decimal> CalculateBMIAsync(Guid userId);
        Task SetWeightGoalAsync(Guid userId, decimal targetWeight);
        Task<UserDto> UpdateByIdAsync(Guid userId);
    }
}
