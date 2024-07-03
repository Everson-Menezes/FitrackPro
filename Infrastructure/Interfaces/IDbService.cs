
namespace Infrastructure.Interfaces
{
    public interface IDbService
    {
        Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null);
        Task<int> ExecuteAsync(string sql, object param = null);
    }
}