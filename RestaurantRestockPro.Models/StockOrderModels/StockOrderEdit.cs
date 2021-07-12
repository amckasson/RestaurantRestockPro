using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRestockPro.Models.StockOrderModels
{
    public class StockOrderEdit
    {
        public int StockOrderId { get; set; }

        public string Manager { get; set; }
        public int RestaurantId { get; set; }
    }
}
