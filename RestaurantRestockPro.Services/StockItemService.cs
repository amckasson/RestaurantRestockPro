using RestaurantRestockPro.Data;
using RestaurantRestockPro.Models.StockItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRestockPro.Services
{
    public class StockItemService
    {
        private readonly Guid _userId;

        public StockItemService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateStockItem(StockItemCreate model)
        {
            var entity =
                new StockItem()
                {
                    Name = model.Name,
                    Price = model.Price,
                    IsFood = model.IsFood,
                    //ItemType = model.ItemType
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.StockItems.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<StockItemListItem> GetStockItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .StockItems
                        .Select(e => new StockItemListItem()
                        {
                            StockItemId = e.StockItemId,
                            Name = e.Name,
                        });
                return query.ToList();
            }
        }
    }
}
