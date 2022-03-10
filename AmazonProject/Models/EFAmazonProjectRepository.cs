using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonProject.Models
{
    public class EFAmazonProjectRepository : IAmazonProjectRepository //Implement an instance of the IAmazonProject Repository
    {
        private BookstoreContext context { get; set; }
        public EFAmazonProjectRepository (BookstoreContext temp)
        {
            context = temp; //this is just doing what we used to do in the controller
        }
        public IQueryable<Book> Books => context.Books;

        public void SaveBook(Book b)
        {
            context.SaveChanges();
        }

        public void CreateBook(Book b)
        {
            context.Add(b);
            context.SaveChanges();
        }

        public void DeleteBook(Book b)
        {
            context.Remove(b);
            context.SaveChanges();
        }
    }
}
