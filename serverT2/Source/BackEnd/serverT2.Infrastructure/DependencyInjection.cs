using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using serverT2.Domain.Repository;
using serverT2.Domain.Repository.User;
using serverT2.Domain.Security.Cryptography;
using serverT2.Infrascruture.DataAccess;
using serverT2.Infrascruture.DataAccess.Repository;
using serverT2.Infrastructure.DataAccess;
using serverT2.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace serverT2.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            addRepositories(services);
            addDbContext(services, configuration);
            AddFluentMigrator(services, configuration);

            if (configuration.IsUnitTestEnviroment())
                return;

        }
        
        private static void addDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.ConnetionString();
            services.AddDbContext<AppDbContext>(dbContextOptions =>dbContextOptions.UseSqlServer(connectionString));
        }
        private static void addRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserWriteOnlyRespository, UserRepository>();
            services.AddScoped<IUserReadOnlyRespository, UserRepository>();
            services.AddScoped<IUnityOfWork, UnityOfWork>();
        }
        private static void AddFluentMigrator(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.ConnetionString();

            services.AddFluentMigratorCore().ConfigureRunner(options =>
            {
                options
                .AddSqlServer()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(Assembly.Load("ServerT2.Infrastructure")).For.All();
            });
        }



    }
}
