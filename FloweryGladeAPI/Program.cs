using FloweryGladeAPI;
using FloweryGladeAPI.Entities;
using Microsoft.Extensions.DependencyInjection;
using NLog.Web;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// section SERVICES
builder.Services.AddControllers();
//builder.Services.AddSingleton<>();
//builder.Services.AddScoped<>();

// NLog : Setup NLog for Dependency Injection(DI)
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.Host.UseNLog();

//builder.Services.AddTransient<IWeatherForecastService,WeatherForecastService>();


builder.Services.AddScoped<FloweryGladeSeeder>();
builder.Services.AddDbContext<FlowerShopDbContext>();
builder.Services.AddAutoMapper(typeof(Program));
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

//builder.Services.AddScoped<FloweryGladeSeeder>();


//-------------------------------------------------------------------------------
//section CONFIGURE
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<FloweryGladeSeeder>();
seeder.Seed();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
