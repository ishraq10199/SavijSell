using Ishraq.SavijSellApi.Models;
using Ishraq.SavijSellApi.Models.Api;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

namespace Ishraq.SavijSellApi.Services
{
	public class AuthenticationService : IAuthenticationService
	{
		private readonly IUsersService _usersService;
		private readonly CryptoSettings _cryptoSettings;

		/*
			var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
			var bytes = new byte[ 256 / 8 ];
			rng.GetBytes(bytes);
		    Console.WriteLine(Convert.ToBase64String(bytes));
		 */

		public AuthenticationService(IUsersService usersService, IOptions<CryptoSettings> cryptoSettings)
		{
			_usersService = usersService;
			_cryptoSettings = cryptoSettings.Value;
		}

		public async Task<TokenResponse> RequestTokenAsync(TokenRequest tokenRequest)
		{
			var user = await _usersService.LoginUserAsync(tokenRequest);
			if (user != null)
			{
				var claims = new List<Claim> { 
					new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
					new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
					new Claim(ClaimTypes.Name, user.Username),
					new Claim(ClaimTypes.Email, user.Email)
				};
				var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_cryptoSettings.JwtSigningKey));
				var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
				var token = new JwtSecurityToken
				(
					issuer: "localhost:5176",
					audience: "localhost:5176",
					claims: claims,
					expires: DateTime.Now.AddMinutes(30),
					signingCredentials: creds
				);

				return new TokenResponse {
					Token = new JwtSecurityTokenHandler().WriteToken(token)
				};
			}

			throw new AuthenticationException();

		}
	}
}
