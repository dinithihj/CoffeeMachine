using CoffeeMachine.Dto;
using CoffeeMachine.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMachine.Controllers
{
    [Route("/")]
    [ApiController]
    public class CoffeeController : Controller
    {
        private readonly ICounterService _counterService;
        private readonly IDateTimeService _dateTimeService;
        public CoffeeController(ICounterService counterService, IDateTimeService dateTimeService)
        {
            _counterService = counterService;
            _dateTimeService = dateTimeService;
        }

        [HttpGet("brew-coffee")]
        public IActionResult BrewCoffee()
        {
            _counterService.Increment();

            if (_counterService.IsOutOfCoffee())
            {
                return StatusCode(503, null);
            }

            if (_dateTimeService.IsAprilFirst())
            {
                return StatusCode(418, null);
            }

            var response = new CoffeeMachineResponseDto
            {
                Message = Constants.HotCoffeeReadyMessage,
                Prepared = _dateTimeService.GetCurrentDateTimeInISO8601()
            };
            return Ok(response);
        }

    }
}
