using Microsoft.Extensions.DependencyInjection;
using serverT2.Application.Services.AutoMapper;
using serverT2.Application.UseCases.User.Register;
using serverT2.Application.Services.Criptography;
using Microsoft.Extensions.Configuration;
using serverT2.Domain.Security.Cryptography;

namespace serverT2.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            AddAutoMapper(services);
            AddUseCases(services);
            AddCriptography(services, configuration);
        }
        private static void AddUseCases( IServiceCollection services)
        {
            services.AddScoped<IRegisterUseCase, RegisterUserUseCase>();
        }
        private static void AddAutoMapper (IServiceCollection services)
        {
            services.AddScoped(option=>  new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());

            }).CreateMapper());
        }
        private static void AddCriptography(this IServiceCollection services, IConfiguration configuration)
        {
            var additionalKey = configuration.GetSection("Settings:Password:AdditionalKey").Value;
            services.AddScoped(option => new PasswordCryptography(additionalKey));
        }
    }
}
