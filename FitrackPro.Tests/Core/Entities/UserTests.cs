using Core.Entities;
using Core.Enums;
using Core.ValueObjects;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests.Core.Entities
{
    public class UserTests
    {
        [Fact]
        public void AddFoodEntry_ValidEntry_AddsEntryToList()
        {
            // Arrange
            var user = CreateUserInstance();
            var nutrients = new NutrientInfo(200, 20, 50, 10);
            var entryDate = DateTime.Now;

            // Act
            user.AddFoodEntry("Apple", nutrients, entryDate);

            // Assert
            Assert.Single(user.FoodEntries);
        }

        [Fact]
        public void RemoveFoodEntry_ExistingEntry_RemovesEntryFromList()
        {
            // Arrange
            var user = CreateUserInstance();
            var nutrients = new NutrientInfo(200, 20, 50, 10);
            var entryDate = DateTime.Now;
            var foodEntry = new FoodEntry("Apple", nutrients, entryDate);
            user.AddFoodEntry(foodEntry.FoodName, foodEntry.Nutrients, foodEntry.EntryDate);

            // Act
            user.RemoveFoodEntry(foodEntry);

            // Assert
            Assert.DoesNotContain(foodEntry, user.FoodEntries);
        }

        [Fact]
        public void TrackDailyCalories_EntriesOnGivenDate_CalculatesTotalCalories()
        {
            // Arrange
            var user = CreateUserInstance();
            var nutrients1 = new NutrientInfo(200, 20, 50, 10);
            var nutrients2 = new NutrientInfo(300, 30, 60, 15);
            var date = DateTime.Now.Date;
            user.AddFoodEntry("Apple", nutrients1, date);
            user.AddFoodEntry("Banana", nutrients2, date);

            // Act
            decimal totalCalories = user.TrackDailyCalories(date);

            // Assert
            Assert.Equal(500, totalCalories);
        }

        [Fact]
        public void CalculateBMI_ValidHeightAndWeight_CalculatesBMI()
        {
            // Arrange
            var user = CreateUserInstance();

            // Act
            decimal bmi = user.CalculateBMI();

            // Assert
            Assert.Equal(23.15m, bmi); // Example BMI calculation based on sample data
        }

        [Fact]
        public void SetWeightGoal_ValidWeight_SetsTargetWeight()
        {
            // Arrange
            var user = CreateUserInstance();
            decimal targetWeight = 70;

            // Act
            user.SetWeightGoal(targetWeight);

            // Assert
            Assert.Equal(targetWeight, user.Person.TargetWeight);
        }

        private User CreateUserInstance()
        {
            var user = UserTestHelper.CreateUserInstance();
            return user;
        }
    }
}
