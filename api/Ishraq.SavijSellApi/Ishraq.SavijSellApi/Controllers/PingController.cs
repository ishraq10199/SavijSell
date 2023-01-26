using Microsoft.AspNetCore.Authorization;
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

		[HttpGet]
		[Route("/protectedping")]
        [Authorize]
		public IActionResult GetProtectedPing()
		{
			return Ok(new { Response = "Protected Pong" });
		}
	}
}
