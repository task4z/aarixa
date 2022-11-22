using Aarixa.Database;
using Aarixa.Services.CitiesCommand;
using Dapper;
using System.Data.SQLite;

namespace Aarixa
{
    public static class Startup
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ICitiesCommand, CitiesCommand>();
        }

        public static void SetupDb(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton(new DatabaseConfig { Name = connectionString });
            using var connection = new SQLiteConnection(connectionString);

            var table = connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND name = 'City';");
            var tableName = table.FirstOrDefault();
            if (!string.IsNullOrEmpty(tableName) && tableName == "City")
                return;

            connection.Execute("Create Table City (" +
                "Id int INTEGER PRIMARY KEY NOT NULL," +
                "Name VARCHAR(200) NOT NULL," +
                "PostalCode VARCHAR(10) NULL," +
                "Activities VARCHAR(1000) NULL);");
        }
    }
}
