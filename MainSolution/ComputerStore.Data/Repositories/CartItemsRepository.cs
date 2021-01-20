using ComputerStore.Data.Context;
using ComputerStore.Domain.Interfaces;
using ComputerStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerStore.Data.Repositories
{
    public class CartItemsRepository : ICartItemsRepository
    {
        private ComputerStoreDbContext _context;

        public CartItemsRepository(ComputerStoreDbContext context)
        {
            _context = context;
        }

        public void AddCartItem(CartItem cartItem)
        {
            _context.CartItems.Add(cartItem);
            _context.SaveChanges();
        }

        public void DeleteCartItem(CartItem cartItem)
        {
            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();
        }

        public CartItem GetCartItem(Guid id)
        {
            return _context.CartItems.SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<CartItem> GetCartItems(Guid id)
        {
            return _context.CartItems.Where(x => x.CartId == id);
        }
    }
}
