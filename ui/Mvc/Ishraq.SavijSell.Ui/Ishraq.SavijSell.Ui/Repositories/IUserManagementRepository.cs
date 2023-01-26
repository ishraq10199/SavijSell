namespace Ishraq.SavijSell.Ui.Repositories
{
	public interface IUserManagementRepository
	{
		Task SignUp(string firstName, string lastName, string email, string password, string username, string postalCode);
		Task<string> Login(string email, string password);
	}
}
