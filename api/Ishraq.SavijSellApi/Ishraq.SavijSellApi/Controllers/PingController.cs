using Ishraq.SavijSellApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ishraq.SavijSellApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGet]
        [Route("/ping")]
        public IActionResult Get()
        {
            return Ok(new {Response="Pong"});
        }
    }
}
