using ClientApi.Clients;
using ClientApi.Models;
using ClientApi.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

builder.Services.AddHttpClient<WeatherForecastClient>((serviceProvider, client) =>
{
    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + builder.Configuration["WeatherForecastService:Key"]);

    client.BaseAddress = new Uri(builder.Configuration["WeatherForecastService:Url"]);
});
builder.Services.AddScoped<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
