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

        public AddModel (IAmazonProjectRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";

        }
        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);
          
            cart.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });

        }
        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            cart.RemoveItem(cart.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
