using ComputerStore.Data.Context;
using ComputerStore.Domain.Interfaces;
using ComputerStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerStore.Data.Repositories
{
    public class OrderItemsRepository : IOrderItemsRepository
    {
        private ComputerStoreDbContext _context;

        public OrderItemsRepository(ComputerStoreDbContext context)
        {
            _context = context;
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
            _context.SaveChanges();
        }

        public IQueryable<OrderItem> GetOrderItems(Guid id)
        {
            return _context.OrderItems.Where(x => x.OrderId == id);
        }
    }
}
