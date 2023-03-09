using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission9.Infrastructure;
using Mission9.Models;

namespace Mission9.Pages
{
    public class CartModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }

        public CartModel (IBookstoreRepository temp)
        {
            repo = temp;
        }
        // instance of the basket
        public Basket basketgang { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            basketgang = HttpContext.Session.GetJson<Basket>("basketgang") ?? new Basket();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Books b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basketgang = HttpContext.Session.GetJson<Basket>("basketgang") ?? new Basket();

            basketgang.AddItem(b, 1);

            HttpContext.Session.SetJson("basketgang", basketgang);
            // makes it so you can go back to the page you were on 
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
