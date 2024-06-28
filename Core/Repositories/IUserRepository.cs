using Core.Entities;

namespace Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid userId);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
    }
}
