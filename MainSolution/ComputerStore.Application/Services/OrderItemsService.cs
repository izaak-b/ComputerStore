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
    public class OrderItemsService : IOrderItemsService
    {
        private IOrderItemsRepository _repo;
        private IMapper _mapper;

        public OrderItemsService(IOrderItemsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void AddOrderItem(OrderItemViewModel orderItem)
        {
            var newOrderItem = _mapper.Map<OrderItemViewModel, OrderItem>(orderItem);
            _repo.AddOrderItem(newOrderItem);
        }
    }
}
