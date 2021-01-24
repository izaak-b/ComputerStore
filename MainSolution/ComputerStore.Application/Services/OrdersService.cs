using AutoMapper;
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
    public class OrdersService: IOrdersService
    {
        private IOrdersRepository _repo;
        private IOrderItemsRepository _orderItemsRepo;
        private ICartsRepository _cartsRepo;
        private ICartItemsRepository _cartItemsRepo;
        private IMapper _mapper;

        public OrdersService(IOrdersRepository repo, IOrderItemsRepository orderItemsRepo, ICartsRepository cartsRepo, ICartItemsRepository cartItemsRepo, IMapper mapper)
        {
            _repo = repo;
            _orderItemsRepo = orderItemsRepo;
            _cartsRepo = cartsRepo;
            _cartItemsRepo = cartItemsRepo;
            _mapper = mapper;
        }

        public void AddOrder(OrderViewModel o)
        {
            var newOrder = _mapper.Map<OrderViewModel, Order>(o);
            _repo.AddOrder(newOrder);
        }

        public void Checkout(string email)
        {
            Guid orderId = Guid.NewGuid();
            Order o = new Order();
            o.Id = orderId;
            o.MemberEmail = email;
            o.OrderDate = DateTime.UtcNow;
            _repo.AddOrder(o);

            var cartId = _cartsRepo.GetCartId(email);
            var cartItems = _cartItemsRepo.GetCartItems(cartId).ToList();

            foreach (CartItem cartItem in cartItems)
            {
                OrderItem orderItem = new OrderItem();
                orderItem.OrderId = orderId;
                orderItem.ProductId = cartItem.ProductId;
                orderItem.Quantity = cartItem.Quantity;
                _orderItemsRepo.AddOrderItem(orderItem);
                _cartItemsRepo.DeleteCartItem(cartItem);
            }

        }

        public Guid GetLastOrder(string email)
        {
            return _repo.GetLastOrder(email);
        }
    }
}
