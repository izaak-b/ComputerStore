using ComputerStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerStore.Domain.Interfaces
{
    public interface IOrderItemsRepository
    {
        void AddOrderItem(OrderItem orderItem);
        IQueryable<OrderItem> GetOrderItems(Guid id);
    }
}
