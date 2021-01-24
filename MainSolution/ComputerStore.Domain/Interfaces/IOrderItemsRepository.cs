using ComputerStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Domain.Interfaces
{
    public interface IOrderItemsRepository
    {
        void AddOrderItem(OrderItem orderItem);
    }
}
