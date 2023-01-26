using Ishraq.SavijSellApi.Models.Api;
using Ishraq.SavijSellApi.Models.Domain;
using Ishraq.SavijSellApi.Repositories;
using System.Security.Authentication;
using System.Web.Helpers;

namespace Ishraq.SavijSellApi.Services
{
	public class UsersService : IUsersService
	{
		private readonly IUsersRepository _usersRepository;

		public UsersService(IUsersRepository usersRepository)
		{
			_usersRepository = usersRepository;
		}

		public async Task InsertUserAsync(UserSignUp user)
		{
			user.Password = Crypto.HashPassword(user.Password);
			await _usersRepository.InsertUserAsync(user);
		}

		public async Task<User> LoginUserAsync(TokenRequest login)
		{
			var user = await _usersRepository.GetUserByEmailAsync(login);

			if (user == null)
			{
				throw new AuthenticationException();
			}

			var isValid = Crypto.VerifyHashedPassword(user.Password, login.Password);

			if (!isValid)
			{
				// Call auth service here
				throw new AuthenticationException();
			}

			return user;
		}
	}
}
