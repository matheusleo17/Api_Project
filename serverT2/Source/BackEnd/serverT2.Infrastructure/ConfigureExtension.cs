using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;


namespace serverT2.Infrastructure.Extensions;

public static class ConfigurationExtension
{
    public static bool IsUnitTestEnviroment(this IConfiguration configurarion) => configurarion.GetValue<bool>("InMemoryTest");

    public static string ConnetionString(this IConfiguration configurarion)
    {

            return configurarion.GetConnectionString("DefaultConnection")!;
    }
}