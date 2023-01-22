namespace CoffeeMachine.Services
{
    public sealed class CounterService : ICounterService
    {
        private int counter = 0;

        public void Increment()
        {
            counter++;
        }
        public bool IsOutOfCoffee()
        {
            if (counter % 5 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
