using Dapper;
using GutCheck.Core.Entities;
using GutCheck.Infrastructure.Data;
using GutCheck.Infrastructure.Services;
using System.Data;

namespace GutCheck.DataMigrations
{
    internal class Program
    {
        const string GutCheckSqlConnection = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=GutCheck_Local;Integrated Security=True;Multiple Active Result Sets=True";
        const string SchemaSqlFilePath = "SQL/CreateSchema.sql";
        static async Task Main(string[] args)
        {
            DapperContext dbContext = new DapperContext(GutCheckSqlConnection);
            using IDbConnection conn = dbContext.GetConnection();

            await InitializeDatabaseSchema(conn);
            await AddUsersToDatabase(conn);
        }


        static async Task InitializeDatabaseSchema(IDbConnection conn)
        {
            try
            {
                string createSchemaSql = File.ReadAllText(SchemaSqlFilePath);
                await conn.ExecuteAsync(createSchemaSql);
                Console.WriteLine("Database SCHEMA created.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to read file: {SchemaSqlFilePath}");
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }
        }

        static async Task<bool> AddUsersToDatabase(IDbConnection conn)
        {
            User newUser = new User
            {
                Email = "danieleejohnson@gmail.com",
                Username = "djohnson",
                HashedPassword = "",
                Role = "Admin",
                IsConfirmed = true,
            };
            newUser.HashedPassword = AuthService.HashPassword("password");

            string insertSql = "INSERT INTO dbo.Users (Username, Email, HashedPassword, Role, IsConfirmed) VALUES (@Username, @Email, @HashedPassword, @Role, @IsConfirmed)";
            int rowsAffected = await conn.ExecuteAsync(insertSql, newUser);
            bool result = rowsAffected >= 1;

            if (result)
            {
                Console.WriteLine("Users successfully added to the database.");
            }

            return result;
        }
    }
}