using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Restaurant
{
    
    public partial class Product
    {
        public Product()
        {
            Restaurants = new HashSet<Restaurant>();
        }
        [Key]
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }
        public string NameRus { get; set; }
        public string NameLatin { get; set; }
        public int? RestaurantId { get; set; }
        public byte[] ProductPicture { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
