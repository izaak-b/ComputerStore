using ComputerStore.Data.Context;
using ComputerStore.Domain.Interfaces;
using ComputerStore.Domain.Models;
using System;
using System.Collections.Generic;
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
    }
}
