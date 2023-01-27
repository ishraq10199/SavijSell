using Ishraq.SavijSell.Ui.Models;

namespace Ishraq.SavijSell.Ui.Repositories
{
	public interface IUserManagementRepository
	{
		Task SignUp(string firstName, string lastName, string email, string password, string username, string postalCode);
		Task<TokenResponse> Login(string email, string password);
	}
}
