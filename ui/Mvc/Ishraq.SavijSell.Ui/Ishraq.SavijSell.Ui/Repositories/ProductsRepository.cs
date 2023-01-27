using Ishraq.SavijSell.Ui.Models;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;

namespace Ishraq.SavijSell.Ui.Repositories
{
    public class ProductsRepository: RepositoryBase, IProductsRepository
    {
        

		public ProductsRepository(IFlurlClientFactory flurlClientFactory, 
                                  IHttpContextAccessor httpContextAccessor):
                                    base(flurlClientFactory, httpContextAccessor)
		{}

		public async Task<List<Product>> GetProducts()
        {
            // API Call here
            var products = await _flurlClient.Request("/api/Products")
                                    .GetJsonAsync<List<Product>>();
            return products;
        }
        public async Task<Product> GetProductById(int id)
        {
            var product = await _flurlClient.Request($"/api/Products/{id}")
                                    .GetJsonAsync<Product>();
            return product;

        }
    }
}
