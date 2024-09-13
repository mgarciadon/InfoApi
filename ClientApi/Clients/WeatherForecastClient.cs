using ClientApi.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace ClientApi.Clients
{
    public class WeatherForecastClient
    {
        private readonly HttpClient _client;
        private readonly IMemoryCache _cache;
        public const string WEATHER_FORECAST_CACHE = "WeatherForecastCache";

        public WeatherForecastClient(HttpClient client, IMemoryCache cache)
        {
            _client = client;
            _cache = cache;
        }

        public async Task<List<WeatherForecast?>> GetInfoAsync()
        {
            if (_cache.TryGetValue(WEATHER_FORECAST_CACHE, out List< WeatherForecast>? cachedResponse))
            {
                return cachedResponse;
            }

            var response = await _client.GetStringAsync("/WeatherForecast/GetWeatherForecast");
            var forecasts = JsonSerializer.Deserialize<List<WeatherForecast>>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            };

            _cache.Set(WEATHER_FORECAST_CACHE, forecasts, cacheEntryOptions);

            return forecasts;

        }
    }
}
