using System;
using System.Collections.Generic;

#nullable disable

namespace Restaurant
{
    public partial class City
    {
        public City()
        {
            RestaurantInCities = new HashSet<RestaurantInCity>();
        }

        public int Id { get; set; }
        public string NameRus { get; set; }
        public string NameLatin { get; set; }
        public string PeopleCounty { get; set; }

        public virtual Restaurant IdNavigation { get; set; }
        public virtual ICollection<RestaurantInCity> RestaurantInCities { get; set; }
    }
}
