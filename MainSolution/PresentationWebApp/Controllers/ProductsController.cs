using ComputerStore.Application.Interfaces;
using ComputerStore.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly ICategoriesService _categoriesService;
        private readonly ICartsService _cartsService;
        private readonly ICartItemsService _cartItemsService;
        private readonly IWebHostEnvironment _env;
        public ProductsController(IProductsService productsService, ICategoriesService categoriesService, ICartsService cartsService, ICartItemsService cartItemsService, IWebHostEnvironment env)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
            _cartsService = cartsService;
            _cartItemsService = cartItemsService;
            _env = env;
        }

        public IActionResult Index()
        {
            var list = _productsService.GetProducts();
            return View(list);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var listOfCategories = _categoriesService.GetCategories();
            ViewBag.Categories = listOfCategories;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(ProductViewModel data, IFormFile f)
        {
            try
            {
                if (f != null)
                {
                    if (f.Length > 0)
                    {
                        string newFileName = Guid.NewGuid() + System.IO.Path.GetExtension(f.FileName);
                        string newFileNameWithAbsolutePath = _env.WebRootPath + @"\Images\" + newFileName;
                        using (var stream = System.IO.File.Create(newFileName))
                        {
                            f.CopyTo(stream);
                        }

                        data.ImageUrl = @"\Images\" + newFileName;
                    }
                }

                _productsService.AddProduct(data);

                TempData["feedback"] = "Product added successfully";
            }
            catch (Exception ex)
            {
                //log error
                TempData["warning"] = "Product was not added!";
            }

            var listOfCategories = _categoriesService.GetCategories();
            ViewBag.Categories = listOfCategories;
            return View(data);
        }

        public IActionResult Details(Guid id)
        {
            var product = _productsService.GetProduct(id);
            return View(product);
        }

        public IActionResult AddToCart(Guid prodId)
        {
            var cartItem = new CartItemViewModel()
            {
                CartId = _cartsService.GetCartId(User.Identity.Name),
                ProductId = prodId,
                Quantity = 1
            };
            _cartItemsService.AddCartItem(cartItem);
            TempData["feedback"] = "Product added to cart";
            return RedirectToAction("Index");
        }
    }
}
