using AmazonProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonProject
{    //RECAP: We created a view component that inherits from the view component, created a little dataset,
    //and then created the correct query and set it equal to a variable which we will then pass to our view
    //The view will be created in the next video
    //RECAP of VIEW: We need to create the folder structure it is looking for in vc:types in the Views folder...
    //Views-Shared/Home-Components-Types-Default.Cshtml
    public class TypesViewComponent : ViewComponent //Inherits from VC from Microsoft netcore
    {
        private IAmazonProjectRepository repo { get; set; }
        public TypesViewComponent (IAmazonProjectRepository temp)
        {
            repo = temp;
        }
        public IViewComponentResult Invoke() //Invoke method means we're going to return something
        {
            ViewBag.SelectedType = RouteData?.Values["Category"]; //? means its nullable

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return View(types);

        }
    }
}
