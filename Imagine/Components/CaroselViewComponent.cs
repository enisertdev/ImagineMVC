using Imagine.Business.Services.ProductService;
using Imagine.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Imagine.Components
{
    public class CaroselViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public CaroselViewComponent(IProductService productService)
        {
            _productService = productService;
        }
        public IViewComponentResult Invoke()
        {
            var products = new List<Product>();
           Random rnd = new Random();
           while (products.Count < 4)
           {
                int number = rnd.Next(1,40);
                var product = _productService.GetProduct(p => p.Id == number);
                if (product != null && !products.Contains(product))
                {
                    products.Add(product);
                }
           }


           return View(products);
        }
    }
}
