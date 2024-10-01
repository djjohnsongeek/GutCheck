using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace GutCheck.Infrastructure.Data
{
    public class DapperContext
    {
        private readonly string? _connectionString;
        private const string DefaultConnectionName = "SqlConnection";

        public DapperContext(IConfiguration config)
        {
            _connectionString = config.GetConnectionString(DefaultConnectionName);
        }

        public DapperContext(string connString)
        {
            _connectionString = connString;
        }

        public IDbConnection CreateConnection()
        {
            if (_connectionString == null)
            {
                throw new NullReferenceException($"The connection string '{DefaultConnectionName}' could not be found.");
            }

            return new SqlConnection(_connectionString);
        }
    }
}
