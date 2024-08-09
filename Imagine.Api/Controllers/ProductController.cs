using Imagine.Business.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace Imagine.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public IActionResult GetAllProducts()
        { 
            var products = _productService.GetAllProductsWithCategory(); 

            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            return Ok(_productService.GetProductWithCategory(id));
        }
    }
}
