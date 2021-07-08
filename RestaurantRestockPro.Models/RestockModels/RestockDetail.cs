using RestaurantRestockPro.Models.StockItemModels;
using RestaurantRestockPro.Models.StockOrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRestockPro.Models.RestockModels
{
    public class RestockDetail
    {
        public int RestockId { get; set; }
        public int Quantity { get; set; }
        public int StockItemId { get; set; }
        public StockItemListItem StockItem { get; set; }

        public int StockOrderId { get; set; }
        public StockOrderListItem StockOrder { get; set; }
    }
}
