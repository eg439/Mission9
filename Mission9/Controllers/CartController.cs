using Microsoft.AspNetCore.Mvc;
using Mission9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Controllers
{
    public class CartController : Controller
    {
        public ICartRepository repo { get; set; }
        private Basket basket { get; set; }
        public CartController(ICartRepository temp, Basket b)
        {
            repo = temp;
            basket = b;

        }
        [HttpGet]
        public IActionResult Checkout()
        {
            return View( new FinalCart());
        }
        [HttpPost]
        public IActionResult Checkout(FinalCart cart)
        {
            if (basket.Items.Count() == 0 )
            {
                ModelState.AddModelError("", "Sorry your basket is empty! ");
            }        
            if (ModelState.IsValid)
            {
                cart.Lines = basket.Items.ToArray();
                repo.SaveCart(cart);
                basket.ClearBasekt();

                return RedirectToPage("/Confirmation");
            }
            else
            {
                return View();
            }
        }

    }
}
