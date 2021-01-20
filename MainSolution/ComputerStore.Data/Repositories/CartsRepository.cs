using ComputerStore.Data.Context;
using ComputerStore.Domain.Interfaces;
using ComputerStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerStore.Data.Repositories
{
    public class CartsRepository : ICartsRepository
    {
        private ComputerStoreDbContext _context;

        public CartsRepository(ComputerStoreDbContext context)
        {
            _context = context;
        }

        public void AddCart(Cart c)
        {
            _context.Carts.Add(c);
            _context.SaveChanges();
        }

        public Guid GetCartId(string email)
        {
            var cart = _context.Carts.SingleOrDefault(x => x.MemberEmail == email);
            return cart.Id;
        }
    }
}
