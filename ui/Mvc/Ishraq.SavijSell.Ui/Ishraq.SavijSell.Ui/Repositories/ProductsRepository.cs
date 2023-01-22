using Ishraq.SavijSell.Ui.Models;
using Flurl;
using Flurl.Http;

namespace Ishraq.SavijSell.Ui.Repositories
{
    public class ProductsRepository:IProductsRepository
    {

        public async Task<List<Product>> GetProducts()
        {
            // API Call here
            var products = await "http://localhost:5176".AppendPathSegment("/api/Products").GetJsonAsync<List<Product>>();
            return products;
        }
        public async Task<Product> GetProductById(int id)
        {
            var product = await "http://localhost:5176".AppendPathSegment($"/api/Products/{id}").GetJsonAsync<Product>();
            return product;

        }
    }
}
