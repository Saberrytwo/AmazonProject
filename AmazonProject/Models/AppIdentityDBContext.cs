using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonProject.Models
{
    public class AppIdentityDBContext : IdentityDbContext
    {
        public AppIdentityDBContext(DbContextOptions options) : base(options)
        {
        }
    }
}
