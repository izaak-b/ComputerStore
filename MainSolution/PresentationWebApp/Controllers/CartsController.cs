using ComputerStore.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationWebApp.Controllers
{
    public class CartsController : Controller
    {
        private readonly ICartItemsService _cartItemsService;
        private readonly ICartsService _cartsService;

        public CartsController(ICartItemsService cartItemsService, ICartsService cartsService)
        {
            _cartItemsService = cartItemsService;
            _cartsService = cartsService;
        }

        [Authorize]
        public IActionResult Index()
        {
            Guid cartId = _cartsService.GetCartId(User.Identity.Name);
            var cartItemsList = _cartItemsService.GetCartItems(cartId);
            return View(cartItemsList);
        }

        [Authorize]
        public IActionResult Remove(Guid id)
        {
            try
            {
                _cartItemsService.DeleteCartItem(id);
                TempData["feedback"] = "Product removed from cart";
            }
            catch(Exception ex)
            {
                TempData["warning"] = "Product not removed!";
            }
            return RedirectToAction("Index");
        }
    }
}
