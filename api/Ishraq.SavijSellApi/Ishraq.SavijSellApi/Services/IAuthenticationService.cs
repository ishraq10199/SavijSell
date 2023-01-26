using Ishraq.SavijSellApi.Models.Api;

namespace Ishraq.SavijSellApi.Services
{
	public interface IAuthenticationService
	{
		Task<TokenResponse> RequestTokenAsync(TokenRequest tokenRequest);
	}
}
