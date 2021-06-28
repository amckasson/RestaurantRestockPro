using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRestockPro.Data
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }
        
        [Required]
        public Guid OwnerId { get; set; }
        
        [Required]
        [Display(Name = "Restaurants Name")]
        public string RestaurantName { get; set; }
        
        [Required]
        [Display(Name = "Restaurants Location")]
        public string RestaurantLocation { get; set; }
    }
}
