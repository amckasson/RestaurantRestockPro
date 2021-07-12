using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRestockPro.Models.StockOrderModels
{
    public class StockOrderCreate
    {
        public string Manager { get; set; }
        
        [Required]
        public int RestaurantId { get; set; }
    }
}
