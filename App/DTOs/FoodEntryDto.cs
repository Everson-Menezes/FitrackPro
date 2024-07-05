namespace App.DTOs
{
    public class FoodEntryDto
    {
        public string FoodName { get; set; } = default!;
        public NutrientInfoDto Nutrients { get; set; } = default!;
        public DateTime EntryDate { get; set; }
    }
}
