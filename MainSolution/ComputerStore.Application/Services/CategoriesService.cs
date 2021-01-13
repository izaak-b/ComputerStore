using AutoMapper;
using AutoMapper.QueryableExtensions;
using ComputerStore.Application.Interfaces;
using ComputerStore.Application.ViewModels;
using ComputerStore.Domain.Interfaces;
using ComputerStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerStore.Application.Services
{
    public class CategoriesService : ICategoriesService
    {
        private ICategoriesRepository _repo;
        private IMapper _mapper;

        public CategoriesService(ICategoriesRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IQueryable<CategoryViewModel> GetCategories()
        {
            var categories = _repo.GetCategories().ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider);
            return categories;
        }
    }
}
