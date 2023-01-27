using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ishraq.SavijSellApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Admin was called!");
        }
    }
}
