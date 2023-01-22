using Ishraq.SavijSellApi.Models.Api;

namespace Ishraq.SavijSellApi.Services
{
    public interface IProductsService
    {
        List<Product> GetProducts();
        Product GetProduct(string id);

    }
}
