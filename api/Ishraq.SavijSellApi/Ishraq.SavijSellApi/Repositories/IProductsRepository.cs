using Ishraq.SavijSellApi.Models.Api;

namespace Ishraq.SavijSellApi.Repositories
{
    public interface IProductsRepository
    {
        List<Product> GetProducts();
        Product GetProduct(string id);
    }
}
