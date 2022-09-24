using System;
using System.Collections.Generic;

#nullable disable

namespace Restaurant
{
    public partial class RestaurantName
    {
        public RestaurantName()
        {
            PriceCategories = new HashSet<PriceCategory>();
            RestaurantInCities = new HashSet<RestaurantInCity>();
            Restaurants = new HashSet<Restaurant>();
        }

        public int Id { get; set; }
        public string NameRus { get; set; }
        public string NameLatin { get; set; }

        public virtual ICollection<PriceCategory> PriceCategories { get; set; }
        public virtual ICollection<RestaurantInCity> RestaurantInCities { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
