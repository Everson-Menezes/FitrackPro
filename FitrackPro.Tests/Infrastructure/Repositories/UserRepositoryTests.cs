using Core.Entities;
using Infrastructure.Repositories;
using Moq;
using Infrastructure.Interfaces;

namespace Infrastructure.Tests.Repositories
{
    public class UserRepositoryTests
    {
        private readonly Mock<IDbService> _mockDbService;
        private readonly Mock<ISqlConnectionFactory> _mockSqlConnectionFactory;
        private readonly UserRepository _userRepository;

        public UserRepositoryTests()
        {
            _mockDbService = new Mock<IDbService>();
            _mockSqlConnectionFactory = new Mock<ISqlConnectionFactory>();
            _userRepository = new UserRepository(_mockSqlConnectionFactory.Object, _mockDbService.Object);
        }

        [Fact]
        public async Task GetUserByIdAsync_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var expectedUser = UserTestHelper.CreateUserInstance();

            _mockDbService
                .Setup(db => db.QuerySingleOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>()))
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
            _mockDbService
                .Setup(db => db.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
                .ReturnsAsync(1);

            // Act
            await _userRepository.AddUserAsync(user);

            // Assert
            _mockDbService.Verify(db => db.ExecuteAsync(It.IsAny<string>(), It.Is<object>(obj =>
                ((Guid)obj.GetType().GetProperty("Id").GetValue(obj)) == user.Id &&
                (string)obj.GetType().GetProperty("FirstName").GetValue(obj) == user.Person.FirstName &&
                (string)obj.GetType().GetProperty("LastName").GetValue(obj) == user.Person.LastName &&
                (string)obj.GetType().GetProperty("Email").GetValue(obj) == user.Person.Email &&
                (string)obj.GetType().GetProperty("PasswordHash").GetValue(obj) == user.PasswordHash
            )), Times.Once);
        }

        [Fact]
        public async Task UpdateUserAsync_ShouldExecuteUpdateQuery()
        {
            // Arrange
            var user = UserTestHelper.CreateUserInstance();

            _mockDbService
                .Setup(db => db.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
                .ReturnsAsync(1);

            // Act
            await _userRepository.UpdateUserAsync(user);

            // Assert
            _mockDbService.Verify(db => db.ExecuteAsync(It.IsAny<string>(), It.Is<object>(obj =>
                ((Guid)obj.GetType().GetProperty("Id").GetValue(obj)) == user.Id &&
                (string)obj.GetType().GetProperty("FirstName").GetValue(obj) == user.Person.FirstName &&
                (string)obj.GetType().GetProperty("LastName").GetValue(obj) == user.Person.LastName &&
                (string)obj.GetType().GetProperty("Email").GetValue(obj) == user.Person.Email &&
                (string)obj.GetType().GetProperty("PasswordHash").GetValue(obj) == user.PasswordHash
            )), Times.Once);
        }

        [Fact]
        public async Task DeleteUserAsync_ShouldExecuteDeleteQuery()
        {
            // Arrange
            var userId = Guid.NewGuid();

            _mockDbService
                .Setup(db => db.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
                .ReturnsAsync(1);

            // Act
            await _userRepository.DeleteUserAsync(userId);

            // Assert
            _mockDbService.Verify(db => db.ExecuteAsync(It.IsAny<string>(), It.Is<object>(obj =>
                ((Guid)obj.GetType().GetProperty("Id").GetValue(obj)) == userId
            )), Times.Once);
        }
    }
}
