using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRestockPro.Models.Restaurant
{
    public class RestaurantCreate
    {
        [Required]
        [Display(Name = "Restaurants Name")]
        public string RestaurantName { get; set; }

        [Display(Name = "Restaurants Location")]
        public string RestaurantLocation { get; set; }
    }
}
