using Ishraq.SavijSellApi.Models.Api;
using Ishraq.SavijSellApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ishraq.SavijSellApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly IAuthenticationService _authenticationService;

		public AuthenticationController(IAuthenticationService authenticationService)
		{
			_authenticationService = authenticationService;
		}

		[HttpPost]
		[Route("/api/token")]
		[AllowAnonymous]
		public async Task<IActionResult> RequestToken(TokenRequest tokenRequest)
		{
			var token = await _authenticationService.RequestTokenAsync(tokenRequest);
			return Ok(token);
		}
	}
}
