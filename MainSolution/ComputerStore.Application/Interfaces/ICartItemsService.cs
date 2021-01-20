using ComputerStore.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerStore.Application.Interfaces
{
    public interface ICartItemsService
    {
        void AddCartItem(CartItemViewModel ci);
        void DeleteCartItem(Guid id);
        IQueryable<CartItemViewModel> GetCartItems(Guid id);
    }
}
