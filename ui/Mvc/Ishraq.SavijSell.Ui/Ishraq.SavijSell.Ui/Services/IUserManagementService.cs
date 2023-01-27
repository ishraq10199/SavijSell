using Ishraq.SavijSell.Ui.Models;

namespace Ishraq.SavijSell.Ui.Services
{
	public interface IUserManagementService
	{
		Task SignUp(string firstName, string lastName, string email, string password, string username, string postalCode);
		Task<TokenResponse> Login (string email, string password);
	}
}
