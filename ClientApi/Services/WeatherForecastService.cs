using ClientApi.Clients;
using ClientApi.Models;

namespace ClientApi.Services
{
    public class WeatherForecastService
    {
        private readonly WeatherForecastClient _weatherForecastClient;
        public WeatherForecastService(WeatherForecastClient weatherForecastClient) 
        { 
            _weatherForecastClient = weatherForecastClient;
        }

        public List<WeatherForecast> GetInfo()
        {
            return _weatherForecastClient.GetInfoAsync().Result;
        }
    }
}
