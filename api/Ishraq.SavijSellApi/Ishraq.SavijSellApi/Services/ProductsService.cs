using Ishraq.SavijSellApi.Models.Api;
using Ishraq.SavijSellApi.Repositories;

namespace Ishraq.SavijSellApi.Services
{
    public class ProductsService:IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public Product GetProduct(string id)
        {
            return _productsRepository.GetProduct(id);
        }

        public List<Product> GetProducts()
        {
            return _productsRepository.GetProducts();   
        }
    }
}
