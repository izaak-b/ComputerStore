using ComputerStore.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerStore.Application.Interfaces
{
    public interface ICategoriesService
    {
        IQueryable<CategoryViewModel> GetCategories();
    }
}
