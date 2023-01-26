using Ishraq.SavijSellApi.Models.Api;
using Ishraq.SavijSellApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ishraq.SavijSellApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUsersService _usersService;

		public UsersController(IUsersService usersService)
		{
			_usersService = usersService;
		}

		[HttpPost]
		public async Task<IActionResult> Post(UserSignUp user)
		{
			// Service call
			await _usersService.InsertUserAsync(user);
			return NoContent();
		}
	}
}
