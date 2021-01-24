using ComputerStore.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerStore.Application.Interfaces
{
    public interface IOrderItemsService
    {
        void AddOrderItem(OrderItemViewModel orderItem);
        IQueryable<OrderItemViewModel> GetOrderItems(Guid id);
    }
}
