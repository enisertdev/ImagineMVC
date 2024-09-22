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
            var allproducts = _productService.GetAllProducts().ToList();
            Product getHighestIdProduct = _productService.GetAllProducts().OrderBy(p => p.Id).LastOrDefault();
           Random rnd = new Random();
           if (allproducts.Count() < 5)
           {
               return View(allproducts);
           }
           while(products.Count < 4)
           {
                int number = rnd.Next(1,getHighestIdProduct.Id + 1);
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
