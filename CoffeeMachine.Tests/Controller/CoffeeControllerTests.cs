using CoffeeMachine.Controllers;
using CoffeeMachine.Dto;
using CoffeeMachine.Services;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMachine.Tests.Controller
{
    public class CoffeeControllerTests
    {
        private ICounterService _counterService;
        private IDateTimeService _dateTimeService;
        private CoffeeController _coffeeController;
        public CoffeeControllerTests()
        {
            //Dependencies
            _counterService = A.Fake<ICounterService>();
            _dateTimeService = A.Fake<IDateTimeService>();

            //SUT
            _coffeeController = new CoffeeController(_counterService, _dateTimeService);
        }

        [Fact]
        public void BrewCoffee_ReturnOKOnFirstCall()
        {
            //Arrange

            //Act
            var result = _coffeeController.BrewCoffee();

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = (OkObjectResult)result;
            okResult.Value.Should().BeOfType<CoffeeMachineResponseDto>();
            var dtoResult = (CoffeeMachineResponseDto)okResult.Value;
            dtoResult.Message.Should().BeEquivalentTo("Your piping hot coffee is ready");

        }

        [Fact]
        public void BreCoffee_Return503StatusCodeOnFifthCall()
        {
            //Arrange
            IActionResult result = null;
            A.CallTo(() => _counterService.IsOutOfCoffee()).Returns(true);

            //Act 
            result = _coffeeController.BrewCoffee();


            //Assert
            result.Should().BeOfType<ObjectResult>();
            var objectResult = (ObjectResult)result;
            objectResult.StatusCode.Should().Be(503);
        }

        [Fact]
        public void BreCoffee_Return418OnAprilFirst()
        {
            //Arrange
            IActionResult result = null;
            A.CallTo(() => _dateTimeService.IsAprilFirst()).Returns(true);

            //Act 
            result = _coffeeController.BrewCoffee();


            //Assert
            result.Should().BeOfType<ObjectResult>();
            var objectResult = (ObjectResult)result;
            objectResult.StatusCode.Should().Be(418);
        }
    }
}
