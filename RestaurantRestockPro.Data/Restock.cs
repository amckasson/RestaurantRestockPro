using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRestockPro.Data
{
    public class Restock
    {
        public int RestockId { get; set; }

        public int StockOrderId { get; set; }

        public virtual StockOrder StockOrder { get; set; }

        public int StockItemId { get; set; }

        public virtual StockItem StockItem { get; set; }

        public int Quantity { get; set; }
    }
}
