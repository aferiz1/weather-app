using Microsoft.EntityFrameworkCore;
using WeatherAPI.Models;
using WeatherAPI.Repositories;
using WeatherAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()    
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>
    (x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddScoped<IWeatherSnapshotsRepository, WeatherSnapshotsRepository>();

builder.Services.AddHttpClient<IWeatherService, OpenWeatherService>();
builder.Services.AddScoped<ICityRepository, CityRepository>();

builder.Services.AddHostedService<WeatherBackgroundService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();