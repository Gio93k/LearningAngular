using Microsoft.AspNetCore.Mvc;

namespace ArticoliWebService.Controllers
{
    [ApiController]
    [Route("api/saluti2")]
    public class Saluti2Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult getSaluti2()
        {
            return Ok("SAluti sono il primo webservice creato in dotnet core3");
        }


    }
}