using CoffeeMachine.Helpers;

namespace CoffeeMachine.Services
{
    public class DateTimeService : IDateTimeService
    {
        private IDateTimeHelper _dateTimeHelper;
        public DateTimeService(IDateTimeHelper dateTimeHelper)
        {
            _dateTimeHelper = dateTimeHelper;
        }

        public string GetCurrentDateTimeInISO8601()
        {
            return _dateTimeHelper.GetDateTimeNow().ToString("yyyy-MM-ddTHH:mm:ssK");
        }

        public bool IsAprilFirst()
        {
            if (_dateTimeHelper.GetDateTimeNow().Month == 4 && _dateTimeHelper.GetDateTimeNow().Day == 1)
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
