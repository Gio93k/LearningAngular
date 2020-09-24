using Microsoft.AspNetCore.Mvc;

namespace ArticoliWebService.Controllers
{
    [ApiController]
    [Route("api/saluti")]
    public class SalutiController
    {
        [HttpGet]
        public string getsaluti()
        {
            return "stringa saluti";
        }
        [HttpGet("{Nome}")]
        public string getsaluti2(string Nome) => string.Format("Saluti, {0} sono il primo webserver ", Nome);
        
    }
}