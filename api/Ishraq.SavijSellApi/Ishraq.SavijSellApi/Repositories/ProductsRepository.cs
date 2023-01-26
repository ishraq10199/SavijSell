using Dapper;
using Ishraq.SavijSellApi.Models;
using Ishraq.SavijSellApi.Models.Api;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace Ishraq.SavijSellApi.Repositories
{
    public class ProductsRepository:IProductsRepository
    {
        public readonly DatabaseSettings _databaseSettings;

		public ProductsRepository(IOptions<DatabaseSettings> databaseSettings)
		{
			_databaseSettings = databaseSettings.Value;
		}

		public async Task<Product> GetProduct(string id)
        {
            var idNumber = Convert.ToInt32(id);
            var products = await GetProducts();

            return products.FirstOrDefault(p => p.Id == idNumber);
        }
        public async Task<List<Product>> GetProducts()
        {
            try
            {
                using(var connection = new SqlConnection(_databaseSettings.ConnectionString))
                {
                    var results = await connection.QueryAsync<Product>("stp_Items_Get",
                                                        param: null,
                                                        commandType: CommandType.StoredProcedure);
                    if (results != null)
                    {
                        return results.ToList();
                    }

                    return null;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
