using Flurl.Http;
using Flurl.Http.Configuration;
using Ishraq.SavijSell.Ui.Models;
using Microsoft.AspNetCore.Http;

namespace Ishraq.SavijSell.Ui.Repositories
{
	public class RepositoryBase
	{
		protected readonly IFlurlClient _flurlClient;
		protected readonly IHttpContextAccessor _httpContextAccessor;

		public RepositoryBase(IFlurlClientFactory flurlClientFactory, IHttpContextAccessor httpContextAccessor)
		{
			_flurlClient = flurlClientFactory.Get("http://localhost:5176");
			_httpContextAccessor = httpContextAccessor;

			_ = _flurlClient.BeforeCall(flurlCall =>
			{
				var token = _httpContextAccessor.HttpContext.Request.Cookies[Constants.XAccessToken];
				if (!string.IsNullOrWhiteSpace(token))
				{
					flurlCall.HttpRequestMessage.SetHeader("Authorization", $"bearer {token}");
				}
				else
				{
					flurlCall.HttpRequestMessage.SetHeader("Authorization", string.Empty);

				}
			});

		}
	}
}
