using Imagine.Business.Services.OrderService;
using Imagine.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Imagine.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            IEnumerable<Order> orders = _orderService.GetAllOrders();
             foreach(var order in orders)
            {
                if(order.OrderStatus == "Cancelled" && Int32.Parse(DateTime.Now.ToString("dd")) - Int32.Parse(order.LastUpdated.ToString("dd"))  > 3)
                {
                    _orderService.RemoveOrder(order);
                }
            }
            return View(orders);
           

        }

        public IActionResult EditOrderStatus(int id)
        {
            Order order = _orderService.GetOneOrder(o => o.Id == id);
            var orderStatues = Enum.GetValues(typeof(OrderStatus))
                .Cast<OrderStatus>()
                .Select(s => new {Id = (int)s, Name = s.ToString()})
                .ToList();
            ViewBag.orderstatus = orderStatues;
            return View(order);
        }

        [HttpPost]
        public IActionResult EditOrderStatus(Order order)
        {
            Order getOrder = _orderService.GetOneOrder(o=>o.Id == order.Id);
            getOrder.OrderStatus = order.OrderStatus;
            _orderService.UpdateOrder(getOrder);
            return RedirectToAction("Index","Dashboard");
        }
    }
}