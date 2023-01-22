using Ishraq.SavijSellApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ishraq.SavijSellApi.Controllers
{
    [Route("api/[controller]")] // .../api/Products
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productsService.GetProducts();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProduct(string id)
        {
            var product = _productsService.GetProduct(id);
            return Ok(product);
        }
    }
}
