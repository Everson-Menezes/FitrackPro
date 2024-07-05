using Core.Entities;

namespace Core.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person> GetByIdAsync(Guid personId);
        Task<IEnumerable<Person>> GetAllAsync();
        Task AddAsync(Person person);
        Task UpdateAsync(Person person);
        Task DeleteAsync(Guid personId);
    }
}
