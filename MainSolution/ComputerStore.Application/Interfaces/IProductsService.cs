using ComputerStore.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerStore.Application.Interfaces
{
    public interface IProductsService
    {
        IQueryable<ProductViewModel> GetProducts();
        IQueryable<ProductViewModel> GetProducts(int category);
        ProductViewModel GetProduct(Guid id);
        void AddProduct(ProductViewModel product);
    }
}
