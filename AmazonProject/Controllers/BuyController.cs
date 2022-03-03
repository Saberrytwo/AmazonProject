using AmazonProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonProject.Controllers
{
    public class BuyController : Controller
    {
        private IBuyRepository repo { get; set; }
        private Cart cart { get; set; }
        public BuyController(IBuyRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Buy());
        }
        [HttpPost]
        public IActionResult Checkout(Buy buy)
        {
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                buy.Lines = cart.Items.ToArray();
                repo.SaveBuy(buy);
                cart.ClearCart();
                return RedirectToPage("/BuyCompleted");

            }
            else
            {
                return View();
            }

        }
    }
}
