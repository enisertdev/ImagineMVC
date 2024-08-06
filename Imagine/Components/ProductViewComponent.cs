using Imagine.Business.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace Imagine.Components
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public ProductViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public string Invoke()
        {
           return _productService.GetAllProducts().Count().ToString();
        }
    }
}
