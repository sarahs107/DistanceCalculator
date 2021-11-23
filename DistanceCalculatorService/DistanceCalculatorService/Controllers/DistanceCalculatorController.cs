using DistanceCalculatorService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace DistanceCalculatorService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DistanceCalculatorController : ControllerBase
    {
        private IDistanceCalculatorService _distanceCalculatorService;
        private readonly ILogger<DistanceCalculatorController> _logger;

        public DistanceCalculatorController(ILogger<DistanceCalculatorController> logger, IDistanceCalculatorService distanceCalculatorService)
        {
            _logger = logger;
            _distanceCalculatorService = distanceCalculatorService;
        }

        

        [HttpGet("{latitude:double:range(-90,90)}/{longitude:double:range(-180,180)}/{otherlatitude:double:range(-90,90)}/{otherlongitude:double:range(-180,180)}")]
        public IActionResult Get(double latitude, double longitude, double otherlatitude, double otherlongitude, CalculationType calcType = CalculationType.Haversine, UnitOfDistance unitOfDistance = UnitOfDistance.Km)
        {
            try
            {
                var distance = _distanceCalculatorService.CalculateDistance(latitude, longitude, otherlatitude, otherlongitude, calcType, unitOfDistance);
                return Ok(distance);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = e.Message });

            }
        }
    }
}
