using CoffeeMachine.Helpers;
using CoffeeMachine.Services;
using FakeItEasy;
using FluentAssertions;

namespace CoffeeMachine.Tests.Service
{
    public class DateTimeServiceTests
    {
        private DateTimeService _dateTimeService;
        private IDateTimeHelper _dateTimeHelper;
        public DateTimeServiceTests()
        {
            //Dependancies
            _dateTimeHelper = A.Fake<IDateTimeHelper>();

            //SUT
            _dateTimeService = new DateTimeService(_dateTimeHelper);
        }


        [Fact]
        public void GetCurrentDateTimeInISO8601_ReturnCorrectFormat()
        {
            //Arrange
            var currentDateTimeInISO8601 = "2023-01-22T16:25:30+13:00";
            DateTime fakeDateTime = new DateTime(2023, 1, 22, 16, 25, 30, DateTimeKind.Local);
            A.CallTo(() => _dateTimeHelper.GetDateTimeNow()).Returns(fakeDateTime);

            //Act
            var result = _dateTimeService.GetCurrentDateTimeInISO8601();

            //Assert
            result.Should().Be(currentDateTimeInISO8601);
        }

        [Fact]
        public void IsAprilFirst_ReturnTrueOnAprilFirst()
        {
            //Arrange
            DateTime fakeDateTime = new DateTime(2022, 4, 1);
            A.CallTo(() => _dateTimeHelper.GetDateTimeNow()).Returns(fakeDateTime);

            //Act
            var result = _dateTimeService.IsAprilFirst();

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsAprilFirst_ReturnFalseOnMayFirst()
        {
            //Arrange
            DateTime fakeDateTime = new DateTime(2022, 5, 1);
            A.CallTo(() => _dateTimeHelper.GetDateTimeNow()).Returns(fakeDateTime);

            //Act
            var result = _dateTimeService.IsAprilFirst();

            //Assert
            result.Should().BeFalse();
        }
    }
}
