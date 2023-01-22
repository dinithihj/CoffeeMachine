namespace CoffeeMachine.Services
{
    public interface ICounterService
    {
        void Increment();
        bool IsOutOfCoffee();
    }
}