using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonProject.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AmazonProject
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration temp)
        {
            Configuration = temp;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<BookstoreContext>(options =>
           {
       

               options.UseSqlite(Configuration["ConnectionStrings:BookstoreDBConnection"]);

           });
            services.AddScoped<IAmazonProjectRepository, EFAmazonProjectRepository>(); //Each Httprequest gets its own repository object
            services.AddScoped<IBuyRepository, EFBuyRepository>();
            
            services.AddRazorPages(); //Adds razor pages

            services.AddDistributedMemoryCache();
            services.AddSession(); //Basically setting up the ability to use a session
            services.AddScoped<Cart>(x => SessionCart.GetCart(x));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //Provides access to the HTTP context

            services.AddServerSideBlazor(); //To be able to use blazor pages
            services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //tells the program to use the files in the wwwroot folder
            app.UseStaticFiles();
            app.UseSession(); //Implement the use of session
            app.UseRouting();



            app.UseEndpoints(endpoints =>
            {//endpoints are executed in order

                endpoints.MapControllerRoute("categorypage",
                "{Category}/Page{pageNum}",
                 new { Controller = "Home", action = "Index" }); //This handles when they pass in the Category of books they want,
                                                                 //which we want to handle first, so we have that endpoint first

                endpoints.MapControllerRoute(
                    name: "Paging",
                    pattern: "Page{pageNum}",
                    defaults: new { Controller = "Home", action = "Index", pageNum=1 });

                endpoints.MapControllerRoute("category",
                "{Category}",
                new { Controller = "Home", action = "Index", pageNum = 1 });


                endpoints.MapDefaultControllerRoute(); // Follows the  controller, then action, etc.

                endpoints.MapRazorPages(); //Lets us use Razor Pages

                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index"); //If it can't find a page that is linked/doesn't need anything, go to this page -- index

            });
        }
    }
}
