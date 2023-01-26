using Dapper;
using Ishraq.SavijSellApi.Models;
using Ishraq.SavijSellApi.Models.Api;
using Ishraq.SavijSellApi.Models.Domain;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace Ishraq.SavijSellApi.Repositories
{
	public class UsersRepository : IUsersRepository
	{
		private readonly DatabaseSettings _dbSettings;
		public UsersRepository(IOptions<DatabaseSettings> dbSettings)
		{
			_dbSettings = dbSettings.Value;
		}
		public async Task InsertUserAsync(UserSignUp user)
		{
			try
			{
				using (var connection = new SqlConnection(_dbSettings.ConnectionString))
				{
					var parameters = new DynamicParameters();
					parameters.Add("@FirstName", user.FirstName);
					parameters.Add("@LastName", user.LastName);
					parameters.Add("@Email", user.Email);
					parameters.Add("@Password", user.Password);
					parameters.Add("@PostalCode", user.PostalCode);
					parameters.Add("@Username", user.Username);

					await connection.ExecuteAsync("stp_Users_Insert", parameters, commandType: CommandType.StoredProcedure);

				}
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public async Task<User> GetUserByEmailAsync(TokenRequest login)
		{
			try
			{
				using (var connection = new SqlConnection(_dbSettings.ConnectionString))
				{
					var parameters = new DynamicParameters();

					parameters.Add("@Email", login.Email);

					var results = await connection.QueryAsync<User>("stp_Users_GetByEmail", parameters, commandType: CommandType.StoredProcedure);

					if (results != null)
					{
						return results.FirstOrDefault();
					}

					return null;

				}
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}
