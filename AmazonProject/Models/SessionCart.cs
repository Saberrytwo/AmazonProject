using AmazonProject.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AmazonProject.Models
{
    public class SessionCart : Cart
    {
        public static Cart  GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; //nullable
            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart(); //If it is null, then do the thing on the right

            cart.Session = session;
            return cart;
        }

        [JsonIgnore] //We are just overriding the methods from the cart class/model
        public ISession Session { get; set; }
        public override void AddItem(Book bok, int qty)
        {
            base.AddItem(bok, qty);
            Session.SetJson("Cart", this); //this basically just refers to the current instance of the class
        }
        public override void RemoveItem(Book bok)
        {
            base.ClearCart();
            Session.Remove("Cart");

        }
        public override void ClearCart()
        {
            base.ClearCart();
            Session.Remove("Cart");
        }
    }
}
