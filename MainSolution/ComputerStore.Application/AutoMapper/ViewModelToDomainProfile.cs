using AutoMapper;
using ComputerStore.Application.ViewModels;
using ComputerStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Application.AutoMapper
{
    public class ViewModelToDomainProfile: Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<ProductViewModel, Product>();
            CreateMap<CategoryViewModel, Category>();
            CreateMap<MemberViewModel, Member>();
            CreateMap<CartViewModel, Cart>();
            CreateMap<CartItemViewModel, CartItem>();
        }
    }
}
