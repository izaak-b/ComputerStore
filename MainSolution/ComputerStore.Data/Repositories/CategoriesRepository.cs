using ComputerStore.Data.Context;
using ComputerStore.Domain.Interfaces;
using ComputerStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerStore.Data.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        ComputerStoreDbContext _context;

        public CategoriesRepository(ComputerStoreDbContext context)
        {
            _context = context;
        }

        public IQueryable<Category> GetCategories()
        {
            return _context.Categories;
        }
    }
}
