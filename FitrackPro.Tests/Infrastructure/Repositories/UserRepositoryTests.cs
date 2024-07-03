using System.Data;
using Core.Entities;
using Infrastructure.Repositories;
using Moq;
using Dapper;
using Infrastructure.Infra;

namespace Infrastructure.Tests.Repositories
{
    public class UserRepositoryTests
    {
        private readonly Mock<IDbConnection> _mockDbConnection;
        private readonly Mock<SqlConnectionFactory> _mockSqlConnectionFactory;
        private readonly UserRepository _userRepository;

        public UserRepositoryTests()
        {
            _mockDbConnection = new Mock<IDbConnection>();
            _mockSqlConnectionFactory = new Mock<SqlConnectionFactory>();
            _mockSqlConnectionFactory.Setup(factory => factory.CreateConnection()).Returns(_mockDbConnection.Object);
            _userRepository = new UserRepository(_mockSqlConnectionFactory.Object);
        }

        [Fact]
        public async Task GetUserByIdAsync_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var expectedUser = UserTestHelper.CreateUserInstance();

            _mockDbConnection
                .Setup(db => db.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>(), null, null, default))
                .ReturnsAsync(expectedUser);

            // Act
            var actualUser = await _userRepository.GetUserByIdAsync(userId);

            // Assert
            Assert.Equal(expectedUser, actualUser);
        }

        [Fact]
        public async Task AddUserAsync_ShouldExecuteInsertQuery()
        {
            // Arrange
            var user = UserTestHelper.CreateUserInstance();
            _mockDbConnection
                .Setup(db => db.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>(), null, null, default))
                .ReturnsAsync(1);

            // Act
            await _userRepository.AddUserAsync(user);

            // Assert
            _mockDbConnection.Verify(db => db.ExecuteAsync(It.IsAny<string>(), It.Is<object>(obj =>
                ((Guid)obj.GetType().GetProperty("Id").GetValue(obj)) == user.Id &&
                (string)obj.GetType().GetProperty("FirstName").GetValue(obj) == user.Person.FirstName &&
                (string)obj.GetType().GetProperty("LastName").GetValue(obj) == user.Person.LastName &&
                (string)obj.GetType().GetProperty("Email").GetValue(obj) == user.Person.Email &&
                (string)obj.GetType().GetProperty("PasswordHash").GetValue(obj) == user.PasswordHash
            ), null, null, default), Times.Once);
        }

        [Fact]
        public async Task UpdateUserAsync_ShouldExecuteUpdateQuery()
        {
            // Arrange
            var user = UserTestHelper.CreateUserInstance();

            _mockDbConnection
                .Setup(db => db.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>(), null, null, default))
                .ReturnsAsync(1);

            // Act
            await _userRepository.UpdateUserAsync(user);

            // Assert
            _mockDbConnection.Verify(db => db.ExecuteAsync(It.IsAny<string>(), It.Is<object>(obj =>
                ((Guid)obj.GetType().GetProperty("Id").GetValue(obj)) == user.Id &&
                (string)obj.GetType().GetProperty("FirstName").GetValue(obj) == user.Person.FirstName &&
                (string)obj.GetType().GetProperty("LastName").GetValue(obj) == user.Person.LastName &&
                (string)obj.GetType().GetProperty("Email").GetValue(obj) == user.Person.Email &&
                (string)obj.GetType().GetProperty("PasswordHash").GetValue(obj) == user.PasswordHash
            ), null, null, default), Times.Once);
        }

        [Fact]
        public async Task DeleteUserAsync_ShouldExecuteDeleteQuery()
        {
            // Arrange
            var userId = Guid.NewGuid();

            _mockDbConnection
                .Setup(db => db.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>(), null, null, default))
                .ReturnsAsync(1);

            // Act
            await _userRepository.DeleteUserAsync(userId);

            // Assert
            _mockDbConnection.Verify(db => db.ExecuteAsync(It.IsAny<string>(), It.Is<object>(obj =>
                ((Guid)obj.GetType().GetProperty("Id").GetValue(obj)) == userId
            ), null, null, default), Times.Once);
        }
    }
}
