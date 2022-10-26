using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Services.ProdutService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlowerShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _productService.GetProducts();
        }
        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            return await _productService.GetProduct(id);
        }

        [HttpPost]
        public async Task Create([FromBody]Product product)
        {
            await _productService.CreateProduct(product);
        }
    }
}
