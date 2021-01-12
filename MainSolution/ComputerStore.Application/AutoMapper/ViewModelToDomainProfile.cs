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
        //Converts Application(view models) >>> Domain(classes)
        public ViewModelToDomainProfile()
        {
            CreateMap<ProductViewModel, Product>();
            CreateMap<CategoryViewModel, Category>();
            //CreateMap<MemberViewModel, Member>();
        }
    }
}
