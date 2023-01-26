using Ishraq.SavijSellApi.Models.Api;
using Ishraq.SavijSellApi.Models.Domain;

namespace Ishraq.SavijSellApi.Services
{
	public interface IUsersService
	{
		Task InsertUserAsync(UserSignUp user);
		Task<User> LoginUserAsync(TokenRequest login);
	}
}
