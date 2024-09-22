using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Interfaces;

namespace Imagine.Business.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
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
