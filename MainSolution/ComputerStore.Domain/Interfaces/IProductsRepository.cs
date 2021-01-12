using ComputerStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerStore.Domain.Interfaces
{
    public interface IProductsRepository
    {
        IQueryable<Product> GetProducts();
        Product GetProduct(Guid id);
        Guid AddProduct(Product p);
    }
}
