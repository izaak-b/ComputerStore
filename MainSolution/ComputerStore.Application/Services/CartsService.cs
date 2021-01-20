using AutoMapper;
using ComputerStore.Application.Interfaces;
using ComputerStore.Application.ViewModels;
using ComputerStore.Domain.Interfaces;
using ComputerStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Application.Services
{
    public class CartsService : ICartsService
    {
        private ICartsRepository _repo;
        private IMapper _mapper;

        public CartsService(ICartsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public void AddCart(CartViewModel c)
        {
            var newCart = _mapper.Map<CartViewModel, Cart>(c);
            _repo.AddCart(newCart);
        }

        public Guid GetCartId(string email)
        {
            return _repo.GetCartId(email);
        }
    }
}
