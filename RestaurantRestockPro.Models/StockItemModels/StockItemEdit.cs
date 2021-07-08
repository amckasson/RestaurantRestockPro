//using RestaurantRestockPro.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRestockPro.Models.StockItemModels
{
    public class StockItemEdit
    {
        public int StockItemId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsFood { get; set; }

        [Required]
        public ItemType ItemType { get; set; }

        //public virtual List<Restock> Restocks { get; set; }
    }
}

