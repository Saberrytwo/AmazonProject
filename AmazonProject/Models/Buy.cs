using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonProject.Models
{
    public class Buy
    {
        [Key]
        [BindNever] //Not going to be tied to the form, ever
        public int itemId { get; set; }

        [BindNever]
        public ICollection<CartLineItem> Lines { get; set; }
        [Required(ErrorMessage = "Please enter a name: ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the first address line")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "Please enter a city name: ")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter a state")]
        public string State { get; set; }
        public string Zip { get; set; }
        [Required(ErrorMessage = "Please enter a country: ")]
        public string Country { get; set; }
    }
}
