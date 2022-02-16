using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonProject.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumBooks {get; set;}
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }
        //Figure out how many total pages will be needed, have to cast it as a double to deal with half pages, and then back to an int
        public int TotalPages => (int) Math.Ceiling((double) TotalNumBooks / BooksPerPage);
    }
}
