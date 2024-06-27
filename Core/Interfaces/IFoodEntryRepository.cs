using Core.Entities;

namespace Core.Interfaces
{
    public interface IFoodEntryReadRepository
    {
        Task<IEnumerable<FoodEntry>> GetFoodEntriesByUserIdAsync(Guid userId);
        Task<FoodEntry> GetFoodEntryByIdAsync(Guid id);
    }
}
