using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Interfaces;

namespace Imagine.Business.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public void AddItem(Product product, int userId, int quantity = 1)
        {
            var item = GetItem(i => i.ProductId == product.Id && i.UserId == userId);
            if (item == null)
            {
                _cartRepository.Add(new Cart() { Product = product, UserId = userId, Quantity = quantity });
            }
            else
            {
                item.Quantity += quantity;
                _cartRepository.Update(item);
            }
        }

        public IEnumerable<Cart> GetAllItems()
        {
            return _cartRepository.GetAll();
        }

        public Cart GetItem(Expression<Func<Cart, bool>> filter)
        {
           return _cartRepository.Get(filter);
        }

        public IEnumerable<Cart> GetMany(Expression<Func<Cart, bool>> filter)
        {
            return _cartRepository.GetManyItems(filter);
        }

        public void RemoveItem(Cart item)
        {
            _cartRepository.Remove(item);
        }

        public void UpdateItem(Cart item)
        {
            _cartRepository.Update(item);
        }
    }
}
