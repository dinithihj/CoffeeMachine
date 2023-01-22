using CoffeeMachine.Dto;
using CoffeeMachine.Helpers;

namespace CoffeeMachine.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherApiHelper _weatherApiHelper;
        public WeatherService(IWeatherApiHelper weatherApiHelper)
        {
            _weatherApiHelper = weatherApiHelper;
        }
        public async Task<bool> IsTemperatureGraterThanThirty()
        {
            WeatherResponseDto? weatherResponseDto = await _weatherApiHelper.GetWeatherData();
            if (weatherResponseDto != null && weatherResponseDto.current_weather.temperature > 30)
                return true;
            else
                return false;
        }
    }
}
