using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRestockPro.Models.RestaurantModels
{
    public class RestaurantDetail
    {
        public int RestaurantId { get; set; }

        [Display(Name = "Restaurants Name")]
        public string RestaurantName { get; set; }

        [Display(Name = "Restaurants Location")]
        public string RestaurantLocation { get; set; }
    }
}
