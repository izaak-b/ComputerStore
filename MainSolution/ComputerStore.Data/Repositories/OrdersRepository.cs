using ComputerStore.Data.Context;
using ComputerStore.Domain.Interfaces;
using ComputerStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Guid GetLastOrder(string email)
        {
            var order = _context.Orders.Where(x => x.MemberEmail == email).OrderByDescending(x => x.OrderDate).First();
            return order.Id;
        }
    }
}
