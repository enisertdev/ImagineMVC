using System.Security.Claims;
using Imagine.Business.Services.EmailService;
using Imagine.Business.Services.OrderItemService;
using Imagine.Business.Services.OrderService;
using Imagine.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Imagine.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IEmailService _emailService;
        private readonly IOrderItemService _orderItemService;

        public OrderController(IOrderService orderService, IEmailService emailService, IOrderItemService orderItemService)
        {
            _orderService = orderService;
            _emailService = emailService;
            _orderItemService = orderItemService;
        }

        public IActionResult Index()
        {
            IEnumerable<Order> orders = _orderService.GetAllOrders();
            foreach (var order in orders)
            {
                if (order.OrderStatus == "Cancelled" && Int32.Parse(DateTime.Now.ToString("dd")) - Int32.Parse(order.LastUpdated.ToString("dd")) > 3)
                {
                    _orderService.RemoveOrder(order);
                }
            }
            return View(orders);


        }

        public IActionResult EditOrderStatus(int id)
        {
            Order order = _orderService.GetOneOrder(id);
            var orderStatues = Enum.GetValues(typeof(OrderStatus))
                .Cast<OrderStatus>()
                .Select(s => new { Id = (int)s, Name = s.ToString() })
                .ToList();
            ViewBag.orderstatus = orderStatues;
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> EditOrderStatus(Order order)
        {
            Order getOrder = _orderService.GetOneOrder(order.Id);
            OrderItem orderItem = _orderItemService.GetOneOrderItem(o => o.OrderId == order.Id);
            getOrder.OrderStatus = order.OrderStatus;
            _orderService.UpdateOrder(getOrder);
            string email = User.FindFirstValue(ClaimTypes.Email);

            await _emailService.SendOrderUpdatedEmailAsync(getOrder.User.Email, "Order Updated", getOrder, orderItem, orderItem.Id);
            return RedirectToAction("Index", "Dashboard");
        }

        public IActionResult RemoveOrder(int id)
        {
            Order order = _orderService.GetOneOrder(id);
            if (order != null)
            {
                _orderService.RemoveOrder(order);
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}