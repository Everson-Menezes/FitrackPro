using Core.ValueObjects;

namespace Core.Entities
{
    public class FoodEntry : Base
    {
        public string FoodName { get; private set; } = default!;
        public NutrientInfo Nutrients { get; private set; } = default!;
        public DateTime EntryDate { get; private set; }

        // Private constructor for EF Core and serialization
        private FoodEntry() { }

        public FoodEntry(string foodName, NutrientInfo nutrients, DateTime entryDate)
        {
            FoodName = foodName ?? throw new ArgumentNullException(nameof(foodName));
            Nutrients = nutrients ?? throw new ArgumentNullException(nameof(nutrients));
            EntryDate = entryDate;
        }

        public void UpdateNutrients(NutrientInfo newNutrients)
        {
            Nutrients = newNutrients ?? throw new ArgumentNullException(nameof(newNutrients));
        }

        public override bool Equals(object obj)
        {
            if (obj is FoodEntry other)
            {
                return FoodName == other.FoodName && Nutrients.Equals(other.Nutrients) && EntryDate == other.EntryDate;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FoodName, Nutrients, EntryDate);
        }
    }
}
