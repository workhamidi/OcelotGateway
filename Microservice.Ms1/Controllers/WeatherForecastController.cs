using Microsoft.AspNetCore.Mvc;

namespace Microservices.Ms1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        [HttpGet("Get")]
        public string Get()
        {

            Console.WriteLine($"receive request - {HttpContext.Request.Headers["RequestId"]}");
            Console.WriteLine($"hel{HttpContext.Request.Headers["hel"]}");
            return "get";
        }
    }
}