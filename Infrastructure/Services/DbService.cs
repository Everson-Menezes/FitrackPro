using System.Threading.Tasks;
using Core.Interfaces;
using Dapper;
using System.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services
{
    public class DbService : IDbService
    {
        private readonly IDbConnection _dbConnection;

        public DbService(ISqlConnectionFactory sqlConnectionFactory)
        {
            _dbConnection = sqlConnectionFactory.CreateConnection();
        }

        public async Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null)
        {
            return await _dbConnection.QuerySingleOrDefaultAsync<T>(sql, param);
        }

        public async Task<int> ExecuteAsync(string sql, object param = null)
        {
            return await _dbConnection.ExecuteAsync(sql, param);
        }
    }
}
