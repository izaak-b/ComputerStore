using ComputerStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerStore.Domain.Interfaces
{
    public interface ICartItemsRepository
    {
        void AddCartItem(CartItem cartItem);
        void DeleteCartItem(CartItem cartItem);
        CartItem GetCartItem(Guid id);
        IQueryable<CartItem> GetCartItems(Guid id);
    }
}
