using AutoMapper;
using ComputerStore.Application.ViewModels;
using ComputerStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Application.AutoMapper
{
    public class DomainToViewModelProfile: Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Product, ProductViewModel>(); 
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Member, MemberViewModel>();
            CreateMap<Cart, CartViewModel>();
            CreateMap<CartItem, CartItemViewModel>();
            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderItem, OrderItemViewModel>();
        }
    }
}
