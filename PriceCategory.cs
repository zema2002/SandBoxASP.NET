using System;
using System.Collections.Generic;

#nullable disable

namespace Restaurant
{
    public partial class PriceCategory
    {
        public int Id { get; set; }
        public string NameRus { get; set; }
        public string NameLatin { get; set; }
        public string PriceCategory1 { get; set; }
        public string AverageCheck { get; set; }
        public int? RestaurantId { get; set; }

        public virtual Restaurant IdNavigation { get; set; }
        public virtual RestaurantName Restaurant { get; set; }
    }
}
