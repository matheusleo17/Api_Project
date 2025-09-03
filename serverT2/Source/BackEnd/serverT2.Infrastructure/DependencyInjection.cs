using Microsoft.Extensions.DependencyInjection;
using serverT2.Domain.Repository.User;
using serverT2.Infrascruture.DataAccess;
using serverT2.Infrascruture.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using serverT2.Infrastructure.DataAccess;
using serverT2.Domain.Repository;
using Microsoft.Extensions.Configuration;

namespace serverT2.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            addRepositories(services);
            addDbContext(services);

        }
        
        private static void addDbContext(IServiceCollection services)
        {
            var connectionString = "";
            services.AddDbContext<AppDbContext>(dbContextOptions =>dbContextOptions.UseSqlServer(connectionString));
        }
        private static void addRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserWriteOnlyRespository, UserRepository>();
            services.AddScoped<IUserReadOnlyRespository, UserRepository>();
            services.AddScoped<IUnityOfWork, UnityOfWork>();
        }

    }
}
