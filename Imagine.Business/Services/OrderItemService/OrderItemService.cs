using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Interfaces;

namespace Imagine.Business.Services.OrderItemService
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public void Create(OrderItem item)
        {
            _orderItemRepository.Add(item);
        }

        public OrderItem GetOneOrderItemById(int id)
        {
            return _orderItemRepository.GetOneOrderItemById(id);
        }
        public OrderItem GetOneOrderItem(Expression<Func<OrderItem, bool>> filter)
        {
            return _orderItemRepository.GetOneOrderItem(filter);
        }

        public IEnumerable<OrderItem> GetOrders(Expression<Func<OrderItem, bool>> filter)
        {
           return _orderItemRepository.GetOrders(filter);
        }

        public void RemoveOrderItem(int id)
        {
            OrderItem getOrderItem = _orderItemRepository.GetOneOrderItemById(id);
            if (getOrderItem != null)
            {
                _orderItemRepository.Remove(getOrderItem);
            }
        }

        public OrderItem CreateOrderItem(Order order, Cart cartItem)
        {
            OrderItem orderItem = new OrderItem
            {
                OrderId = order.Id,
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity,
                UnitPrice = cartItem.Product.Price,
                TotalPrice = cartItem.Quantity * cartItem.Product.Price
            };
            Create(orderItem);
            return orderItem;
        }
    }
}
