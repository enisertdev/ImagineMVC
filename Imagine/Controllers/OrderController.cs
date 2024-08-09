using System.Security.Claims;
using Imagine.Business.Services.OrderItemService;
using Imagine.Business.Services.OrderService;
using Imagine.Business.Services.UserService.UserService;
using Imagine.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Imagine.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderItemService _orderItemService;
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;

        public OrderController(IOrderItemService orderItemService, IUserService userService, IOrderService orderService)
        {
            _orderItemService = orderItemService;
            _userService = userService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            User user = _userService.GetUserByEmail(User.FindFirstValue(ClaimTypes.Email));
            if (user == null)
            {
                return Unauthorized();
            }
            IEnumerable<Order> getActiveOrders = _orderService.GetOrders(u => u.UserId == user.Id && u.OrderStatus == "Pending");
            if (getActiveOrders.Count() == 0)
            {
                ViewData["noActiveOrders"] = "You dont have any active orders";
                return View();
            }
            IEnumerable<OrderItem> orderItems = new List<OrderItem>();
            foreach (var order in getActiveOrders)
            {
                orderItems = _orderItemService.GetOrders(u => u.Order.UserId == order.UserId);
            }
            return View(orderItems);
        }
    }
}
