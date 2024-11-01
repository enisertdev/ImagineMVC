using System.Security.Claims;
using Imagine.Business.Services.EmailService;
using Imagine.Business.Services.OrderItemService;
using Imagine.Business.Services.OrderService;
using Imagine.Business.Services.UserService;
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
        private readonly IEmailService _emailService;

        public OrderController(IOrderItemService orderItemService, IUserService userService, IOrderService orderService, IEmailService emailService)
        {
            _orderItemService = orderItemService;
            _userService = userService;
            _orderService = orderService;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            User user = _userService.GetUserByEmail(User.FindFirstValue(ClaimTypes.Email));
            if (user == null)
            {
                return Unauthorized();
            }

            IEnumerable<OrderItem> getActiveOrders = _orderItemService.GetOrders(o => o.Order.UserId == user.Id);

            List<OrderItem> orderItems = new List<OrderItem>();

            foreach (var order in getActiveOrders)
            {
                if (order.Order.OrderStatus != "Cancelled")
                {
                    orderItems.Add(order);
                }
            }

            if (!orderItems.Any())
            {
                ViewData["noActiveOrders"] = "You dont have any active orders";
                return View();
            }
            return View(orderItems);
        }

        public async Task<IActionResult> CancelOrder(int id)
        {
            User user = _userService.GetUserByEmail(User.FindFirstValue(ClaimTypes.Email));
            OrderItem orderItem = _orderItemService.GetOneOrderItemById(id);
            Order getOrder = _orderService.GetOneOrder(orderItem.OrderId);

            if (orderItem == null)
            {
                return NotFound();
            }

            getOrder.OrderStatus = "Cancelled";

            _orderService.UpdateOrder(getOrder);

            await _emailService.SendOrderCancelledEmailAsync(user.Email,"Order Cancelled", getOrder, orderItem.Id);

            return RedirectToAction("Index");


        }

        public IActionResult OrderDetails(int id)
        {
            OrderItem orderItem = _orderItemService.GetOneOrderItemById(id);
            return View(orderItem);
        }

    }
}
