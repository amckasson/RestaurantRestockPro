using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRestockPro.Data
{
    public enum ItemType { Produce, Meat, Drygood, Other}
    public class StockItem
    {
        [Key]
        public int StockItemId { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public bool IsFood { get; set; }

        [Required]
        public ItemType ItemType { get; set; }
    }
}
