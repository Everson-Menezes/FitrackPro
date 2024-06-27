using Core.Entities;
using Core.ValueObjects;
using System;
using Xunit;

namespace Core.Tests.Entities
{
    public class FoodEntryTests
    {
        [Fact]
        public void FoodEntry_AddFoodEntry_Successful()
        {
            // Arrange
            var nutrients = new NutrientInfo(300, 25, 40, 15);
            var entryDate = DateTime.Now;

            // Act
            var foodEntry = new FoodEntry("Apple", nutrients, entryDate);

            // Assert
            Assert.Equal("Apple", foodEntry.FoodName);
            Assert.Equal(nutrients, foodEntry.Nutrients);
            Assert.Equal(entryDate, foodEntry.EntryDate);
        }

        [Fact]
        public void FoodEntry_UpdateNutrients_Successful()
        {
            // Arrange
            var initialNutrients = new NutrientInfo(300, 25, 40, 15);
            var updatedNutrients = new NutrientInfo(350, 30, 45, 20);
            var entryDate = DateTime.Now;
            var foodEntry = new FoodEntry("Banana", initialNutrients, entryDate);

            // Act
            foodEntry.UpdateNutrients(updatedNutrients);

            // Assert
            Assert.Equal(updatedNutrients, foodEntry.Nutrients);
        }
    }
}
