using CoffeeMachine.Services;
using FluentAssertions;

namespace CoffeeMachine.Tests.Service
{
    public class CounterServiceTests
    {
        [Fact]
        public void IsOutOfCoffee_ReturnFalseOnFirstCall()
        {
            //Arrange
            var counterService = new CounterService();

            //Act
            counterService.Increment();
            var result = counterService.IsOutOfCoffee();

            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsOutOfCoffee_ReturnFalseOnFourthCall()
        {
            //Arrange
            var counterService = new CounterService();

            //Act
            bool result = true;
            for (int i = 1; i <= 4; i++)
            {
                counterService.Increment();
                result = counterService.IsOutOfCoffee();
            }


            //Assert
            result.Should().BeFalse();

        }

        [Fact]
        public void IsOutOfCoffee_ReturnTrueOnFifthCall()
        {
            //Arrange
            var counterService = new CounterService();

            //Act
            bool result = false;
            for (int i = 1; i <= 5; i++)
            {
                counterService.Increment();
                result = counterService.IsOutOfCoffee();
            }


            //Assert 
            result.Should().BeTrue();

        }

        [Fact]
        public void IsOutOfCoffee_ReturnFalseOnSixthCall()
        {
            //Arrange
            var counterService = new CounterService();

            //Act
            bool result = true;
            for (int i = 1; i <= 6; i++)
            {
                counterService.Increment();
                result = counterService.IsOutOfCoffee();
            }


            //Assert 
            result.Should().BeFalse();

        }
    }
}
