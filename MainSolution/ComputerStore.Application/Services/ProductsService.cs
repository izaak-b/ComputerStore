﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using ComputerStore.Application.Interfaces;
using ComputerStore.Application.ViewModels;
using ComputerStore.Data.Repositories;
using ComputerStore.Domain.Interfaces;
using ComputerStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerStore.Application.Services
{
    public class ProductsService : IProductsService
    {
        private IProductsRepository _productsRepo;
        private IMapper _mapper;
        public ProductsService(IProductsRepository productsRepo, IMapper mapper)
        {
            _productsRepo = productsRepo;
            _mapper = mapper;
        }

        public void AddProduct(ProductViewModel product)
        {
            /*var newProduct = _mapper.Map<ProductViewModel, Product>(product);
            _productsRepo.AddProduct(newProduct);*/

            Product newProduct = new Product()
            {
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.Category.Id,
                ImageUrl = product.ImageUrl
            };

            _productsRepo.AddProduct(newProduct);
        }

        public void DeleteProduct(Guid id)
        {
            var pToDelete = _productsRepo.GetProduct(id);

            if (pToDelete != null)
            {
                _productsRepo.DeleteProduct(pToDelete);
            }
        }

        public ProductViewModel GetProduct(Guid id)
        {
            var product = _productsRepo.GetProduct(id);
            var result = _mapper.Map<Product, ProductViewModel>(product);
            return result;
        }

        public IQueryable<ProductViewModel> GetProducts()
        {
            var products = _productsRepo.GetProducts().ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider);
            return products;
        }

        public IQueryable<ProductViewModel> GetProducts(int category)
        {
            var products = _productsRepo.GetProducts(category);
            var result = _mapper.Map<IQueryable<Product>, IQueryable<ProductViewModel>>(products);
            return result;
        }
    }
}
