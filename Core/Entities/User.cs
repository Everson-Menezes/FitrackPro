using Core.ValueObjects;
using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class User : Base
    {
        public string Username { get; private set; } = default!;
        public DateTime CreatedAt { get; private set; }
        public string PasswordHash { get; private set; } = default!;
        public Person Person { get; private set; } = default!;
        private readonly List<FoodEntry> _foodEntries = new List<FoodEntry>();
        public IReadOnlyCollection<FoodEntry> FoodEntries => _foodEntries.AsReadOnly();

        private User() { }

        public User(string username, string passwordHash, Person person)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
            PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));
            Person = person ?? throw new ArgumentNullException(nameof(person));
            CreatedAt = DateTime.Now;
        }

        public void AddFoodEntry(string foodName, NutrientInfo nutrients, DateTime entryDate)
        {
            var foodEntry = new FoodEntry(foodName, nutrients, entryDate);
            _foodEntries.Add(foodEntry);
        }

        public void RemoveFoodEntry(FoodEntry foodEntry)
        {
            _foodEntries.Remove(foodEntry);
        }

        public decimal TrackDailyCalories(DateTime date)
        {
            decimal totalCalories = 0;
            foreach (var entry in _foodEntries)
            {
                if (entry.EntryDate.Date == date.Date)
                {
                    totalCalories += entry.Nutrients.Calories;
                }
            }
            return totalCalories;
        }

        public decimal CalculateBMI()
        {
            if (Person.Height <= 0)
            {
                throw new InvalidOperationException("Height must be greater than zero.");
            }

            // Calculate BMI using the formula: weight (kg) / height (m)^2
            decimal bmi = Person.Weight / (Person.Height * Person.Height);
            return Math.Round(bmi, 2); // Round BMI to two decimal places for clarity
        }

        public void SetWeightGoal(decimal targetWeight)
        {            
            if (targetWeight <= 0)
            {
                throw new ArgumentException("Target weight must be greater than zero.", nameof(targetWeight));
            }

            Person.SetTargetWeight(targetWeight);
        }
    }
}
