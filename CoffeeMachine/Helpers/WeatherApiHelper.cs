using CoffeeMachine.Dto;
using Newtonsoft.Json;

namespace CoffeeMachine.Helpers
{
    public interface IWeatherApiHelper
    {
        Task<WeatherResponseDto> GetWeatherData();
    }

    public class WeatherApiHelper : IWeatherApiHelper
    {
        public async Task<WeatherResponseDto> GetWeatherData()
        {
            string url = $"{Constants.WeatherServiceURL}?" +
                               $"latitude={Constants.AucklandLatitude}" +
                               $"&longitude={Constants.AucklandLongitude}" +
                               $"&current_weather=true";

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    WeatherResponseDto? weatherResponseDto = JsonConvert.DeserializeObject<WeatherResponseDto>(apiResponse);
                    return weatherResponseDto;
                }
            }
        }
    }
}
