using Microsoft.Extensions.DependencyInjection;
using serverT2.API.Filters;
using serverT2.API.Middleware;
using serverT2.Application;
using serverT2.Infrastructure;
using serverT2.Infrastructure.Extensions;
using serverT2.Infrastructure.Migration;
using System.ComponentModel;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers().AddJsonOptions(options=> options.JsonSerializerOptions.Converters.Add(new serverT2.API.Converters.StringConverter()));
builder.Services.AddMvc(options => options.Filters.Add(typeof(FilterExceptions)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddRouting(options => options.LowercaseUrls = true);
var app = builder.Build();
var supportedCultures = new[] { "en", "pt-BR", "pt-PT" };

var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("en")
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
migrateDatabase();

app.UseAuthorization();

app.MapControllers();

app.Run();



void migrateDatabase()
{
    if (builder.Configuration.IsUnitTestEnviroment())
        return;
    var connectionString = builder.Configuration.ConnetionString();
    var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
    DataBaseMigration.Migration(connectionString, serviceScope.ServiceProvider);
}

public partial class Program
{

}