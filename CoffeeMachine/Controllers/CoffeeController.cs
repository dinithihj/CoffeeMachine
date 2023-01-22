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
        private readonly IWeatherService _weatherService;
        public CoffeeController(ICounterService counterService,
            IDateTimeService dateTimeService,
            IWeatherService weatherService)
        {
            _counterService = counterService;
            _dateTimeService = dateTimeService;
            _weatherService = weatherService;
        }

        [HttpGet("brew-coffee")]
        public async Task<IActionResult> BrewCoffee()
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


            if (await _weatherService.IsTemperatureGraterThanThirty())
            {
                return Ok(new CoffeeMachineResponseDto
                {
                    Message = Constants.IcedCoffeeReadyMessage,
                    Prepared = _dateTimeService.GetCurrentDateTimeInISO8601()
                });
            }
            else
            {
                return Ok(new CoffeeMachineResponseDto
                {
                    Message = Constants.HotCoffeeReadyMessage,
                    Prepared = _dateTimeService.GetCurrentDateTimeInISO8601()
                });
            }
        }

    }
}
