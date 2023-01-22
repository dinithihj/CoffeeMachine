namespace CoffeeMachine.Services
{
    public interface IDateTimeService
    {
        string GetCurrentDateTimeInISO8601();
        bool IsAprilFirst();
    }
}