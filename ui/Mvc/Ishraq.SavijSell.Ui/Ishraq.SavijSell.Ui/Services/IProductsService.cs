using Ishraq.SavijSell.Ui.Models;

namespace Ishraq.SavijSell.Ui.Services
{
    public interface IProductsService
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProductById(int id);
    }
}
