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
            IEnumerable<OrderItem> getActiveOrders = _orderItemService.GetOrders(o=> o.Order.UserId == user.Id);
            if (getActiveOrders.Count() == 0)
            {
                ViewData["noActiveOrders"] = "You dont have any active orders";
                return View();
            }
            IEnumerable<OrderItem> orderItems = new List<OrderItem>();
          /*  foreach (var order in getActiveOrders)
            {
                orderItems = _orderItemService.GetOrders(u => u.Order.UserId == order);
            }
          */
            return View(getActiveOrders);
        }

        public IActionResult CancelOrder(int id)
        {
            OrderItem orderItem = _orderItemService.GetOneOrderItem(id);
            Order getOrder = _orderService.GetOneOrder(o => o.Id == orderItem.OrderId);

            if (orderItem == null)
            {
                return NotFound();
            }
            _orderItemService.RemoveOrderItem(id);
            getOrder.OrderStatus = "Cancelled";
            _orderService.UpdateOrder(getOrder);
            return RedirectToAction("Index");
            
        }

    }
}
