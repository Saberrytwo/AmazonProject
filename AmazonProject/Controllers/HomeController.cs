using AmazonProject.Models;
using AmazonProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonProject.Controllers
{
    public class HomeController : Controller
    {
        private IAmazonProjectRepository repo;
        public HomeController (IAmazonProjectRepository temp)
        {
            repo = temp; //Now we are not referring to context directly in the controller, now it is contacting the interface
        }
        public IActionResult Index(string Category, int pageNum = 1) //Obvi we can't just call it page bc ASP thinks that means something specific
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == Category || Category == null)
                .OrderBy(b => b.Title) //This way it orders by title, and then displays the 10 per page that we want it to
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = (Category == null ? repo.Books.Count() : repo.Books.Where(x => x.Category == Category).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum

                }
            };

            return View(x);
        }
    }
}
