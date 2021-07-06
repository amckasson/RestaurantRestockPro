using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRestockPro.Data
{
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
        public int ItemType { get; set; }

        public virtual List<Restock> Restocks { get; set; } = new List<Restock>();
    }
}
