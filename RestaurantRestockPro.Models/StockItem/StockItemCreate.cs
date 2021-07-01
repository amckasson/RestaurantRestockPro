using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRestockPro.Models.StockItem
{
    public enum ItemType { Produce, Meat, Drygood, Other }
    public class StockItemCreate
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsFood { get; set; }

        public ItemType ItemType { get; set; }
    }
}
