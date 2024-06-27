using System;
using Xunit;
using Core.Entities;
using Core.Enums;

namespace Core.Tests.Entities
{
    public class PersonTests
    {
        [Fact]
        public void SetFirstName_ValidName_SetsFirstName()
        {
            // Arrange
            var person = new Person();

            // Act
            person.SetFirstName("John");

            // Assert
            Assert.Equal("John", person.FirstName);
        }

        [Fact]
        public void SetFirstName_InvalidName_ThrowsArgumentException()
        {
            // Arrange
            var person = new Person();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => person.SetFirstName(""));
        }

        [Fact]
        public void SetDateOfBirth_ValidDate_SetsDateOfBirth()
        {
            // Arrange
            var person = new Person();
            var validDate = new DateTime(1990, 1, 1);

            // Act
            person.SetDateOfBirth(validDate);

            // Assert
            Assert.Equal(validDate, person.DateOfBirth);
        }

        [Fact]
        public void SetDateOfBirth_FutureDate_ThrowsArgumentException()
        {
            // Arrange
            var person = new Person();
            var futureDate = DateTime.Now.AddYears(1);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => person.SetDateOfBirth(futureDate));
        }

        [Fact]
        public void SetEmail_ValidEmail_SetsEmail()
        {
            // Arrange
            var person = new Person();
            var validEmail = "test@example.com";

            // Act
            person.SetEmail(validEmail);

            // Assert
            Assert.Equal(validEmail, person.Email);
        }

        [Fact]
        public void SetEmail_InvalidEmail_ThrowsArgumentException()
        {
            // Arrange
            var person = new Person();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => person.SetEmail("invalidemail"));
        }

        private Person CreatePersonInstance()
        {
            return new Person("John", "Doe", new DateTime(1990, 1, 1), Gender.Male, 1.8m, 75, "john.doe@example.com", "123456789", 70);
        }
    }
}
