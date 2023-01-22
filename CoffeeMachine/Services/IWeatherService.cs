namespace CoffeeMachine.Services
{
    public interface IWeatherService
    {
        Task<bool> IsTemperatureGraterThanThirty();
    }
}