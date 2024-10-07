using Dapper;
using GutCheck.Core.Entities;
using GutCheck.Core.Interfaces;
using GutCheck.Infrastructure.Data;
using System.Data;

namespace GutCheck.Infrastructure.Repositories
{
    public class WeightRecordRepository : Repository, IWeightRecordRepository
    {
        public WeightRecordRepository(DapperContext context) : base(context) { }

        public async Task<bool> InsertRecord(WeightRecord record)
        {
            if (record == null)
            {
                return false;
            }

            string query = "INSERT INTO WeightRecords (UserId, Weight, Date) VALUES (@UserId, @Weight, @Date)";
            object parameters = new
            {
                UserId = record.UserId,
                Weight = record.Weight,
                Date = record.Date.Date
            };

            using IDbConnection conn = DbContext.GetConnection();
            int affectedRows = await conn.ExecuteAsync(query, parameters);

            return affectedRows > 0;
        }
    }
}
