using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AmazonProject.Models
{
    public partial class Book
    {
        [Key]
        [Required]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Isbn { get; set; } //Used a string for Isbn because it has the dash in it
        public string Classification { get; set; }
        public string Category { get; set; }
        public int PageCount { get; set; }
        public decimal Price { get; set; }
    }
}
