using ComputerStore.Data.Context;
using ComputerStore.Domain.Interfaces;
using ComputerStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerStore.Data.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private ComputerStoreDbContext _context;
        public ProductsRepository(ComputerStoreDbContext context)
        {
            _context = context;
        }

        public Guid AddProduct(Product p)
        {
            _context.Products.Add(p);
            _context.SaveChanges();
            return p.Id;
        }

        public Product GetProduct(Guid id)
        {
            return _context.Products.SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<Product> GetProducts()
        {
            return _context.Products;
        }

        public IQueryable<Product> GetProducts(int category)
        {
            return _context.Products.Where(x => x.CategoryId == category);
        }
    }
}
