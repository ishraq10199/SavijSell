using Ishraq.SavijSell.Ui.Models;

namespace Ishraq.SavijSell.Ui.Repositories
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProductById(int id);
    }
}
