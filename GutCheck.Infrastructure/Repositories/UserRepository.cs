using Dapper;
using GutCheck.Core.Entities;
using GutCheck.Core.Interfaces;
using GutCheck.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace GutCheck.Infrastructure.Repositories
{
	public class UserRepository : Repository, IUserRepository
	{
		public UserRepository(DapperContext context) : base(context) { }

		public async Task<User?> GetUserByUsername(string username)
		{
			string sqlQuery = "SELECT * FROM Users WHERE Username = @Username";
			using IDbConnection conn = DbContext.GetConnection();
			return await conn.QueryFirstOrDefaultAsync<User>(sqlQuery, new { Username = username });
		}
	}
}
