namespace Core.ValueObjects
{
    public class NutrientInfo
    {
        public decimal Calories { get; private set; }
        public decimal Protein { get; private set; }
        public decimal Carbohydrates { get; private set; }
        public decimal Fats { get; private set; }

        // Private constructor for EF Core and serialization
        private NutrientInfo() { }

        public NutrientInfo(decimal calories, decimal protein, decimal carbohydrates, decimal fats)
        {
            ValidateNutrientValue(calories, nameof(calories));
            ValidateNutrientValue(protein, nameof(protein));
            ValidateNutrientValue(carbohydrates, nameof(carbohydrates));
            ValidateNutrientValue(fats, nameof(fats));

            Calories = calories;
            Protein = protein;
            Carbohydrates = carbohydrates;
            Fats = fats;
        }

        private void ValidateNutrientValue(decimal value, string propertyName)
        {
            if (value < 0)
            {
                throw new ArgumentException($"{propertyName} must be non-negative.", propertyName);
            }
        }
    }
}
