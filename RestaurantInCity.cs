using System;
using System.Collections.Generic;

#nullable disable

namespace Restaurant
{
    public partial class RestaurantInCity
    {
        public int Id { get; set; }
        public string NameRus { get; set; }
        public string NameLatin { get; set; }
        public int? RestaurantNameId { get; set; }
        public int? CityId { get; set; }
        public int? Available { get; set; }

        public virtual City City { get; set; }
        public virtual RestaurantName RestaurantName { get; set; }
    }
}
