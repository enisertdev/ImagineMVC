using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Imagine.Business.Services.CartService;
using Imagine.Business.Services.EmailService;
using Imagine.Business.Services.OrderItemService;
using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Interfaces;

namespace Imagine.Business.Services.OrderService
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;
        private readonly ICartService _cartService;
        private readonly IOrderItemService _orderItemService;
        private readonly IEmailService _emailService;

        public OrderService(IOrderRepository orderRepository, ICartService cartService, IOrderItemService orderItemService, IEmailService emailService)
        {
            _orderRepository = orderRepository;
            _cartService = cartService;
            _orderItemService = orderItemService;
            _emailService = emailService;
        }

        public async Task CreateOrdersAsync(User user)
        {
            var items = _cartService.GetMany(i => i.User.Id == user.Id).ToList();
            foreach (var item in items)
            {
               var trackingNumber = GenerateUniqueTrackingNumber();
               var order = CreateOrder(user, item, trackingNumber);

               var orderItem = _orderItemService.CreateOrderItem(order, item);
               await _emailService.SendOrderEmailAsync(user.Email, "Order Has Been Created", order, orderItem.Id);
            }
        }
        public int GenerateUniqueTrackingNumber()
        {
            Random rnd = new Random();
            int trackingNumber = rnd.Next(1, Int32.MaxValue);
            int orderCount = GetOrders(o => o.TrackingNumber == trackingNumber.ToString()).Count();

            while (orderCount > 0)
            {
                trackingNumber = rnd.Next(1, Int32.MaxValue);
                orderCount = GetOrders(o => o.TrackingNumber == trackingNumber.ToString()).Count();
            }

            return trackingNumber;
        }

        public Order CreateOrder(User user, Cart cartItem, int trackingNumber)
        {

            Order order = new Order
            {
                UserId = user.Id,
                OrderTime = DateTime.Now,
                OrderStatus = OrderStatus.Pending.ToString(),
                TotalAmount = cartItem.Quantity * cartItem.Product.Price,
                PaymentMethod = PaymentMethod.CreditCard.ToString(),
                OrderAddress = user.Address,
                TrackingNumber = trackingNumber.ToString(),
                LastUpdated = DateTime.Now
            };
            Create(order);
            return order;
        }

        public void Create(Order order)
        {
            _orderRepository.Add(order);
        }

        public IEnumerable<Order> GetOrders(Expression<Func<Order, bool>> filter)
        {
           return _orderRepository.GetOrders(filter);
        }

        public Order GetOneOrder(int id)
        {
            return _orderRepository.GetOneOrder(id);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.Update(order);
        }
        public void RemoveOrder(Order order)
        {
            _orderRepository.RemoveOrder(order);
        }

    }
}
