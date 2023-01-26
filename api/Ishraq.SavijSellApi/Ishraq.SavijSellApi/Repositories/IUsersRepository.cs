using Ishraq.SavijSellApi.Models.Api;
using Ishraq.SavijSellApi.Models.Domain;

namespace Ishraq.SavijSellApi.Repositories
{
	public interface IUsersRepository
	{
		Task InsertUserAsync(UserSignUp user);
		Task<User> GetUserByEmailAsync(TokenRequest login);

	}
}
