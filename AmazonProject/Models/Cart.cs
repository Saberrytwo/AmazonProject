using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonProject.Models
{
    public class Cart
    {
        public List<CartLineItem> Items { get; set; } = new List<CartLineItem>();

        public void AddItem(Book bok, int qty)
        {
            CartLineItem line = Items
                .Where(b => b.Book.BookId == bok.BookId)
                .FirstOrDefault();
            if (line == null)
            {
                Items.Add(new CartLineItem
                {
                    Book = bok,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }
        public double CalculateTotal()
        {
            double sum = (double)Items.Sum(x => x.Quantity * x.Book.Price); //Had to go to x.Book.Price

            return sum;
        }
    }

    
    public class CartLineItem
    {
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
