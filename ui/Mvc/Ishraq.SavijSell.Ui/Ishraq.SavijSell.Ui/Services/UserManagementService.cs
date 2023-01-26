using System.Web.Helpers;
using Ishraq.SavijSell.Ui.Repositories;

namespace Ishraq.SavijSell.Ui.Services
{
	public class UserManagementService : IUserManagementService
	{
		private readonly IUserManagementRepository _userManagementRepository;

		public UserManagementService(IUserManagementRepository userManagementRepository)
		{
			_userManagementRepository = userManagementRepository;
		}

		public async Task<string> Login(string email, string password)
		{
			return await _userManagementRepository.Login(email, password);
		}

		public async Task SignUp(string firstName, string lastName, string email, string password, string username, string postalCode)
		{
			var encryptedPassword = Crypto.HashPassword(password);
			await _userManagementRepository.SignUp(firstName, lastName, email, encryptedPassword, username, postalCode);
		}
	}
}
