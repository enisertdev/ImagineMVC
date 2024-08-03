using Imagine.Business.Services;
using Imagine.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using X.PagedList.Extensions;

namespace Imagine.Components.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;


        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index(int page = 1, int pageSize = 4)
        {
            IEnumerable<Product> products = _productService.GetAllProductsWithCategory();
            IPagedList<Product> model = products.ToPagedList(page, pageSize);
            return View(model);
        }

        public IActionResult Details(int id)
        {
            Product product = _productService.GetProductWithCategory(id);
            return View(product);
        }

    }
}
