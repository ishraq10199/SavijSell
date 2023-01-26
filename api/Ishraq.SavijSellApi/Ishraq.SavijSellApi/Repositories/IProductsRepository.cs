using Ishraq.SavijSellApi.Models.Api;

namespace Ishraq.SavijSellApi.Repositories
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(string id);
    }
}
