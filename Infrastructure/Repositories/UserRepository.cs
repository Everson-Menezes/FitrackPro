using Core.Entities;
using Core.Interfaces;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly IDbService _dbService;

        public UserRepository(ISqlConnectionFactory sqlConnectionFactory, IDbService dbService)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _dbService = dbService;
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            string sqlQuery = "SELECT * FROM Users WHERE Id = @Id";
            return await _dbService.QuerySingleOrDefaultAsync<User>(sqlQuery, new { Id = id });
        }

        public async Task AddUserAsync(User user)
        {
            string sqlQuery = "INSERT INTO Users (Id, FirstName, LastName, Email, PasswordHash) VALUES (@Id, @FirstName, @LastName, @Email, @PasswordHash)";
            await _dbService.ExecuteAsync(sqlQuery, new { user.Id, user.Person.FirstName, user.Person.LastName, user.Person.Email, user.PasswordHash });
        }

        public async Task UpdateUserAsync(User user)
        {
            string sqlQuery = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PasswordHash = @PasswordHash WHERE Id = @Id";
            await _dbService.ExecuteAsync(sqlQuery, new { user.Person.FirstName, user.Person.LastName, user.Person.Email, user.PasswordHash, user.Id });
        }

        public async Task DeleteUserAsync(Guid id)
        {
            string sqlQuery = "DELETE FROM Users WHERE Id = @Id";
            await _dbService.ExecuteAsync(sqlQuery, new { Id = id });
        }
    }
}
