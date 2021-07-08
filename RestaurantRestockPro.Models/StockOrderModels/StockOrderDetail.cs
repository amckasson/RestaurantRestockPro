using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRestockPro.Models.StockOrderModels
{
    public class StockOrderDetail
    {
        public int StockOrderId { get; set; }

        public string Manager { get; set; }

        [Display(Name="Order Created")]
        public DateTimeOffset OrderCreated { get; set; }

        [Display(Name ="Order Modified")]
        public DateTimeOffset? OrderUpdated { get; set; }

        public decimal TotalCost { get; set; }

        //public virtual List<Restock> Restocks { get; set; }
    }
}
