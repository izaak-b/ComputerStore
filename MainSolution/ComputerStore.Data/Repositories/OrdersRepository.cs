using ComputerStore.Data.Context;
using ComputerStore.Domain.Interfaces;
using ComputerStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Data.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private ComputerStoreDbContext _context;

        public OrdersRepository(ComputerStoreDbContext context)
        {
            _context = context;
        }

        public void AddOrder(Order o)
        {
            _context.Orders.Add(o);
            _context.SaveChanges();
        }
    }
}
