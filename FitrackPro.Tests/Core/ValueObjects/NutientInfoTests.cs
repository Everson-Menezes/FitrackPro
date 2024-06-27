using Core.ValueObjects;
using System;
using Xunit;

namespace Core.Tests.ValueObjects
{
    public class NutrientInfoTests
    {
        [Fact]
        public void NutrientInfo_Initialization_Successful()
        {
            // Arrange
            decimal calories = 300;
            decimal protein = 25;
            decimal carbohydrates = 40;
            decimal fats = 15;

            // Act
            var nutrientInfo = new NutrientInfo(calories, protein, carbohydrates, fats);

            // Assert
            Assert.Equal(calories, nutrientInfo.Calories);
            Assert.Equal(protein, nutrientInfo.Protein);
            Assert.Equal(carbohydrates, nutrientInfo.Carbohydrates);
            Assert.Equal(fats, nutrientInfo.Fats);
        }

        [Theory]
        [InlineData(-100, 20, 30, 10)]
        [InlineData(300, -10, 30, 10)]
        [InlineData(300, 20, -5, 10)]
        [InlineData(300, 20, 30, -2)]
        public void NutrientInfo_Initialization_WithInvalidValues_ShouldThrowException(decimal calories, decimal protein, decimal carbohydrates, decimal fats)
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => new NutrientInfo(calories, protein, carbohydrates, fats));
        }
    }
}
