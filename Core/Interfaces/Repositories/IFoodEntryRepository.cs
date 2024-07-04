using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IFoodEntryReadRepository
    {
        Task<IEnumerable<FoodEntry>> GetFoodEntriesByUserIdAsync(Guid userId);
        Task<FoodEntry> GetFoodEntryByIdAsync(Guid id);
    }
}
