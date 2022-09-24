using System;
using System.Collections.Generic;

#nullable disable

namespace Restaurant
{
    public partial class Restaurant
    {
        public int Id { get; set; }
        public string NameRus { get; set; }
        public string NameLatin { get; set; }
        public int? CityId { get; set; }
        public int? PriceCategoryId { get; set; }
        public int? ProductId { get; set; }
        public int? RestaurantName { get; set; }

        public virtual Product Product { get; set; }
        public virtual RestaurantName RestaurantNameNavigation { get; set; }
        public virtual City City { get; set; }
        public virtual PriceCategory PriceCategory { get; set; }
    }
}
