using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using FluentMigrator.Runner;

namespace serverT2.Infrastructure.Migration
{
    public static class DataBaseMigration
    {
        public static void Migration(string connectionString, IServiceProvider serviceProvider)
        {
            EnsureDataBaseCreated(connectionString);
            MigrateDataBase(serviceProvider);
        }

        private static void EnsureDataBaseCreated(string connectionString)
        {
          var optionsBuilder = new SqlConnectionStringBuilder(connectionString);

            var databaseName = optionsBuilder.InitialCatalog;

            optionsBuilder.Remove("DataBase");

            using var connection = new SqlConnection(optionsBuilder.ConnectionString);

            var parameters = new DynamicParameters();

            parameters.Add("Name", databaseName);

            var records = connection.Query("SELECT * FROM sys.databases where name =@name", parameters);
            if (!records.Any())
            {
                connection.Execute($"CREATE DATABASE [{databaseName}]");
            }


        }
        private static void MigrateDataBase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.ListMigrations();
            runner.MigrateUp();
        }
    }
}
