using System;
using System.Data;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserRepository(IConfiguration configuration)
        {
            _dbConnection = new SqlConnection(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            string sqlQuery = "SELECT * FROM Users WHERE Id = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<User>(sqlQuery, new { Id = id });
        }

        public async Task AddUserAsync(User user)
        {
            string sqlQuery = "INSERT INTO Users (Id, FirstName, LastName, Email, PasswordHash) VALUES (@Id, @FirstName, @LastName, @Email, @PasswordHash)";
            await _dbConnection.ExecuteAsync(sqlQuery, new { user.Id, user.Person.FirstName, user.Person.LastName, user.Person.Email, user.PasswordHash });
        }

        public async Task UpdateUserAsync(User user)
        {
            string sqlQuery = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PasswordHash = @PasswordHash WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sqlQuery, new { user.Person.FirstName, user.Person.LastName, user.Person.Email, user.PasswordHash, user.Id });
        }

        public async Task DeleteUserAsync(Guid id)
        {
            string sqlQuery = "DELETE FROM Users WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sqlQuery, new { Id = id });
        }
    }

    public interface IConfiguration
    {
    }
}
