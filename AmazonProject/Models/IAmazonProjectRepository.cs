using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonProject.Models
{
    public interface IAmazonProjectRepository
    {
        IQueryable<Book> Books { get; } //Using IQueryable instead of a list, will allow us to do more later on
    }
}
