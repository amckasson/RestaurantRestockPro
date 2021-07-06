using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRestockPro.Data
{
    public class StockOrder
    {
        [Key]
        public int StockOrderId { get; set; }

        [Required]
        public string Manager { get; set; }

        [Required]
        public DateTimeOffset OrderCreated { get; set; }

        public DateTimeOffset OrderUpdated { get; set; }

        public decimal TotalCost { get; set; }

        public virtual List<Restock> Restocks { get; set; } = new List<Restock>();
    }
}
