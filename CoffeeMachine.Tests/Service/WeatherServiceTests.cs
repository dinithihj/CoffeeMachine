using CoffeeMachine.Dto;
using CoffeeMachine.Helpers;
using CoffeeMachine.Services;
using FakeItEasy;
using FluentAssertions;

namespace CoffeeMachine.Tests.Service
{
    public class WeatherServiceTests
    {
        private IWeatherApiHelper _weatherApiHelper;
        private WeatherService _weatherService;
        public WeatherServiceTests()
        {
            //Dependancies
            _weatherApiHelper = A.Fake<IWeatherApiHelper>();

            //SUT
            _weatherService = new WeatherService(_weatherApiHelper);
        }

        [Fact]
        public async void IsTemperatureGraterThanThirty_ReturnTrueWhenTemperatureGraterThanThirty()
        {
            //Arrange 
            WeatherResponseDto weatherResponseDto = new WeatherResponseDto();
            CurrentWeather currentWeather = new CurrentWeather { temperature = 31 };
            weatherResponseDto.current_weather = currentWeather;

            A.CallTo(() => _weatherApiHelper.GetWeatherData()).Returns(weatherResponseDto);

            //Act
            var result = await _weatherService.IsTemperatureGraterThanThirty();

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async void IsTemperatureGraterThanThirty_ReturnFalseWhenTemperatureLessThanThirty()
        {
            //Arrange 
            WeatherResponseDto weatherResponseDto = new WeatherResponseDto();
            CurrentWeather currentWeather = new CurrentWeather { temperature = 25 };
            weatherResponseDto.current_weather = currentWeather;

            A.CallTo(() => _weatherApiHelper.GetWeatherData()).Returns(weatherResponseDto);

            //Act
            var result = await _weatherService.IsTemperatureGraterThanThirty();

            //Assert
            result.Should().BeFalse();
        }


    }
}
