using ComputerStore.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Application.Interfaces
{
    public interface IOrdersService
    {
        void AddOrder(OrderViewModel o);
        void Checkout(string email);
        Guid GetLastOrder(string email);
    }
}
