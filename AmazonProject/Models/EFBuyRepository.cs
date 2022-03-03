using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonProject.Models
{
    public class EFBuyRepository : IBuyRepository
    {
        private BookstoreContext context;
        public EFBuyRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Buy> Buys => context.Buys.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveBuy(Buy buy)
        {
            context.AttachRange(buy.Lines.Select(x => x.Book));
            if (buy.itemId == 0)
            {
                context.Buys.Add(buy);
            }
            context.SaveChanges();
        }
    }
}
