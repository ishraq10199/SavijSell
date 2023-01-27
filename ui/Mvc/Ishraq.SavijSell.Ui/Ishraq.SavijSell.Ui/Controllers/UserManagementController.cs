using Ishraq.SavijSell.Ui.Models;
using Ishraq.SavijSell.Ui.Services;
using Ishraq.SavijSell.Ui.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ishraq.SavijSell.Ui.Controllers
{
    public class UserManagementController : Controller
    {
		private readonly IUserManagementService _userManagementService;

		public UserManagementController(IUserManagementService userManagementService)
		{
			_userManagementService = userManagementService;
		}

		public IActionResult Index()
        {
            return View();
        }

		public IActionResult ConfirmationReminder()
		{
			return View("ConfirmationReminder");
		}

		public IActionResult SignUp()
		{
            var viewModel = new SignUpViewModel();

			return View("SignUp", viewModel);
		}
		[HttpPost]
		[ActionName("SignUpPostAsync")]
		public async Task<IActionResult> SignUpPostAsync(SignUpViewModel viewModel)
		{
			await _userManagementService.SignUp(viewModel.FirstName, viewModel.LastName,
												viewModel.Email, viewModel.Password, viewModel.Username,
												viewModel.PostalCode);
			//await Task.CompletedTask;
			return RedirectToAction("ConfirmationReminder");
		}

		[HttpPost]
		[ActionName("LoginPostAsync")]
		public async Task<IActionResult> LoginPostAsync(LoginViewModel viewModel)
		{
			var tokenRespose = await _userManagementService.Login(viewModel.Email, viewModel.Password);
			Response.Cookies.Append(
				Constants.XAccessToken,
				tokenRespose.Token,
				new CookieOptions{
					HttpOnly = true,
					SameSite = SameSiteMode.Strict
				}
			);
			return RedirectToAction("Index", "Products");
		}
	}
}
