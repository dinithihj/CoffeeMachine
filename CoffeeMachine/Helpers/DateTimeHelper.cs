namespace CoffeeMachine.Helpers
{
    public interface IDateTimeHelper
    {
        DateTime GetDateTimeNow();
    }

    public class DateTimeHelper : IDateTimeHelper
    {
        public DateTime GetDateTimeNow()
        {
            return DateTime.Now;
        }
    }
}
