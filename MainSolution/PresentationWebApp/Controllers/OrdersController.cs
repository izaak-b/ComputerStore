using ComputerStore.Application.Interfaces;
using ComputerStore.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationWebApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService _ordersService;
        private readonly IOrderItemsService _orderItemsService;

        public OrdersController(IOrdersService ordersService, IOrderItemsService orderItemsService)
        {
            _ordersService = ordersService;
            _orderItemsService = orderItemsService;
        }

        [Authorize]
        public IActionResult LastOrder()
        {
            Guid orderId = _ordersService.GetLastOrder(User.Identity.Name);
            var orderItemsList = _orderItemsService.GetOrderItems(orderId);
            return View(orderItemsList);
        }

        [Authorize]
        public IActionResult Checkout()
        {
            try
            {
                _ordersService.Checkout(User.Identity.Name);
                TempData["feedback"] = "Products have been checked out!";
                return RedirectToAction("LastOrder");
            }
            catch (Exception ex)
            {
                TempData["warning"] = "Checkout failed!";
            }

            return RedirectToAction("Index", "Carts");
        }
    }
}
