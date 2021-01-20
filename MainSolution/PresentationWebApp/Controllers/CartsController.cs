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
        public IActionResult Index(Guid id)
        {
            var cartItemsList = _cartItemsService.GetCartItems(id);
            return View(cartItemsList);
        }

        [Authorize]
        public IActionResult Redirect()
        {
            Guid id = _cartsService.GetCartId(User.Identity.Name);
            return RedirectToAction("Index", new { id = id });
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
            return RedirectToAction("Redirect");
        }
    }
}
