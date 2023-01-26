using Flurl;
using Flurl.Http;
using Ishraq.SavijSell.Ui.Models;

namespace Ishraq.SavijSell.Ui.Repositories
{
	public class UserManagementRepository : IUserManagementRepository
	{
		public async Task<string> Login(string email, string password)
		{
			var userLogin = new UserLogin {
				Email = email,
				Password = password
			};

			var token = await "http://localhost:5176".AppendPathSegment("api/token").PostJsonAsync(userLogin).ReceiveJson<string>();

			return token;
		}

		public async Task SignUp(string firstName, string lastName, string email, string password, string username, string postalCode)
		{
			var userSignUp = new UserSignUp
			{
				FirstName = firstName,
				LastName = lastName,
				Email = email,
				Password = password,
				Username = username,
				PostalCode = postalCode
			};

			await "http://localhost:5176".AppendPathSegment("api/Users").PostJsonAsync(userSignUp);
		}
	}
}
