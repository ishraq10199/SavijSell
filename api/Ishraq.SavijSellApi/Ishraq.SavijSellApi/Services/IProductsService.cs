using Ishraq.SavijSellApi.Models.Api;

namespace Ishraq.SavijSellApi.Services
{
    public interface IProductsService
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(string id);

    }
}
