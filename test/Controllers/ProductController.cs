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


        [HttpGet("all")]
        public IActionResult GetAllProducts()
        { 
            var products = _productService.GetAllProductsWithCategory(); 

            return Ok(products);
        }
    }
}
