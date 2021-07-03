﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRestockPro.Models.StockItem
{
    public class StockItemDetail
    {
        public int StockItemId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsFood { get; set; }

        public int ItemType { get; set; }
    }
}