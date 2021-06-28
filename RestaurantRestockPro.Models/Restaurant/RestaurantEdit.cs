using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRestockPro.Models.Restaurant
{
    public class RestaurantEdit
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantLocation { get; set; }
    }
}
