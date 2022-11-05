using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Services.ProdutService;
using Services.UploadImageService;
using Shared.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlowerShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        private IMapper _mapper;
        private IUploadImagesService _uploadImagesService;
        public ProductController(IProductService productService, IMapper mapper,
            IUploadImagesService uploadImagesService)
        {
            _productService = productService;
            _mapper = mapper;
            _uploadImagesService = uploadImagesService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CatalogProductsDto>>> Get()
        {
            var prod = _productService.GetProducts().Result;
            return Ok(_productService.GetProducts().Result.Select(product => _mapper.Map<CatalogProductsDto>(product)));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var prodcut = await _productService.GetProduct(id);
            if (prodcut == null)
                return BadRequest("No product with that id");

            return Ok(prodcut);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromForm]CreateProductDto newProduct)
        {
            
            if (!ModelState.IsValid)
                return BadRequest("Invalid properties");

            ICollection<string> paths = _uploadImagesService.UploadImages(newProduct.Files);
            var product = _mapper.Map<Product>(newProduct);

            product.ImagePaths = new List<Image>(); 
            foreach (var path in paths)
            {
                product.ImagePaths.Add(_mapper.Map<Image>(path));
            }

            await _productService.CreateProduct(product);
            return Ok();
            
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var product = _productService.GetProduct(id).Result;
            if (product == null)
                return NotFound("No product with that id");

            await _productService.DeleteProduct(id);
            return Ok();
        }

        /*
        [HttpGet("GetByCategories")]
        public async Task<ActionResult<ICollection<CatalogProductsDto>>> GetProductsByCategories([FromQuery] QueryProductsDto queryProductsDto)
        {

        }
        */
    }
}
