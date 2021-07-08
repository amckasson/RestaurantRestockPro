using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRestockPro.Models.RestockModels
{
    public class RestockCreate
    {
        [Required]
        public int StockItemId { get; set; }
        
        [Required]
        public int StockOrderId { get; set; }
        
        public int Quantity { get; set; }

    }
}
