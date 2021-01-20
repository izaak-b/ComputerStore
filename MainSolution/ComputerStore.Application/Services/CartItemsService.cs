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
    public class CartItemsService : ICartItemsService
    {
        private ICartItemsRepository _repo;
        private IMapper _mapper;

        public CartItemsService(ICartItemsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void AddCartItem(CartItemViewModel ci)
        {
            var newCartItem = _mapper.Map<CartItemViewModel, CartItem>(ci);
            _repo.AddCartItem(newCartItem);
        }

        public void DeleteCartItem(Guid id)
        {
            var cartItemToDelete = _repo.GetCartItem(id);
            if (cartItemToDelete != null) _repo.DeleteCartItem(cartItemToDelete);
        }

        public IQueryable<CartItemViewModel> GetCartItems(Guid id)
        {
            var cartItems = _repo.GetCartItems(id).ProjectTo<CartItemViewModel>(_mapper.ConfigurationProvider);
            return cartItems;
        }
    }
}
