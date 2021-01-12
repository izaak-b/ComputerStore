using AutoMapper;
using ComputerStore.Application.AutoMapper;
using ComputerStore.Application.Interfaces;
using ComputerStore.Application.Services;
using ComputerStore.Data.Context;
using ComputerStore.Data.Repositories;
using ComputerStore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ComputerStore.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ComputerStoreDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductsService, ProductsService>();

            /*services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<ICategoriesService, CategoriesService>();

            /*services.AddScoped<IMembersRepository, MembersRepository>();
            services.AddScoped<IMembersService, MembersService>();*/

            services.AddAutoMapper(typeof(AutoMapperConfiguration));
            AutoMapperConfiguration.RegisterMappings();
        }
    }
}
