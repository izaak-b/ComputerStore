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
        //Converts Domain(classes) >>> Application(view models)
        public DomainToViewModelProfile()
        {
            CreateMap<Product, ProductViewModel>(); //.ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name)); (when they are different name)
            //Informing Automapper library that we are mapping Product onto ProductViewModel

            CreateMap<Category, CategoryViewModel>();

            //CreateMap<Member, MemberViewModel>();
        }
    }
}
