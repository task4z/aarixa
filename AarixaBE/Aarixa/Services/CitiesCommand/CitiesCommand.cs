using Aarixa.Database;
using Aarixa.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Aarixa.Services.CitiesCommand
{
    public class CitiesCommand : ICitiesCommand
    {
        private readonly DatabaseConfig databaseConfig;

        public CitiesCommand(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task<IEnumerable<City>> Get()
        {
            using var connection = new SQLiteConnection(databaseConfig.Name);

            return await connection.QueryAsync<City>("SELECT Id, Name, PostalCode, Activities FROM City;");
        }

        public async Task Create(City city)
        {
            using var connection = new SQLiteConnection(databaseConfig.Name);

            await connection.ExecuteAsync("INSERT INTO City (Id, Name, PostalCode, Activities)" +
                "VALUES (@Id, @Name, @PostalCode, @Activities);", city);
        }

        public async Task Delete(int id)
        {
            using var connection = new SQLiteConnection(databaseConfig.Name);
            await connection.ExecuteAsync("DELETE FROM City " +
                "Where (Id) = (@Id);", new { Id = id });
        }

        public async Task Update(City city)
        {
            using var connection = new SQLiteConnection(databaseConfig.Name);

            await connection.ExecuteAsync(@"UPDATE City " +
                "SET (Name) = (@Name), (PostalCode) = (@PostalCode), (Activities) = (@Activities)" +
                "WHERE (Id) = (@Id);", city);
        }
    }
}