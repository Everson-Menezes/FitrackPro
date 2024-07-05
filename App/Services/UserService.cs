using App.DTOs;
using App.Interfaces;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace App.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<UserDto> GetUserByIdAsync(Guid userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {userId} not found.");
            }

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                CreatedAt = user.CreatedAt,
                // Add other properties as needed
            };
        }

        public async Task CreateUserAsync(CreateUserDto createUserDto)
        {
            if (createUserDto == null) throw new ArgumentNullException(nameof(createUserDto));

            var person = new Person(
                createUserDto.Person.FirstName,
                createUserDto.Person.LastName,
                createUserDto.Person.DateOfBirth,
                createUserDto.Person.Gender,
                createUserDto.Person.Height,
                createUserDto.Person.Weight,
                createUserDto.Person.Email,
                createUserDto.Person.PhoneNumber,
                createUserDto.Person.TargetWeight
            );

            var user = new User(createUserDto.Username, createUserDto.PasswordHash, person);

            await _userRepository.AddUserAsync(user);
        }

        public async Task<decimal> TrackDailyCaloriesAsync(Guid userId, DateTime date)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {userId} not found.");
            }

            return user.TrackDailyCalories(date);
        }

        public async Task<decimal> CalculateBMIAsync(Guid userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {userId} not found.");
            }

            return user.CalculateBMI();
        }

        public async Task SetWeightGoalAsync(Guid userId, decimal targetWeight)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {userId} not found.");
            }

            user.SetWeightGoal(targetWeight);
            await _userRepository.UpdateUserAsync(user);
        }

        public Task<UserDto> UpdateByIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
