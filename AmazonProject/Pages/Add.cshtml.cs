using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonProject.Infrastructure;
using AmazonProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AmazonProject.Pages
{
    public class AddModel : PageModel
    {
        private IAmazonProjectRepository repo {get; set;}

        public AddModel (IAmazonProjectRepository temp)
        {
            repo = temp;
        }

        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);


            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart(); //?? is the null coalescing operator
            cart.AddItem(b, 1);

            HttpContext.Session.SetJson("cart", cart);

            return RedirectToPage(new { ReturnUrl = returnUrl });

        }
    }
}
