using Microsoft.Extensions.DependencyInjection;
using serverT2.Application.Services.AutoMapper;
using serverT2.Application.UseCases.User.Register;

namespace serverT2.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddAutoMapper(services);
            AddUseCases(services);
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
    }
}
