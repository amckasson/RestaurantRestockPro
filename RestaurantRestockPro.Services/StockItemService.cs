using RestaurantRestockPro.Data;
using RestaurantRestockPro.Models.RestockModels;
using RestaurantRestockPro.Models.StockItemModels;
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
                    ItemType = (int)model.ItemType,

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
                            ItemType = (ItemType)e.ItemType,
                           
                        });

                        
                return query.ToList();
            }
        }

        public StockItemDetail GetStockItemById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .StockItems
                        .Single(e => e.StockItemId == id);

                return
                    new StockItemDetail()
                    {
                        StockItemId = entity.StockItemId,
                        Name = entity.Name,
                        Price = entity.Price,
                        IsFood = entity.IsFood,
                        ItemType = (ItemType)entity.ItemType,

                       // Restocks = entity.Restocks.Select(e => new Restock()
                       // {
                          //  Quantity = e.Quantity
                       // }).ToList()
                    };
                
               
            }
        }

        public bool UpdateStockItem(StockItemEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .StockItems
                        .Single(e => e.StockItemId == model.StockItemId);

                entity.Name = model.Name;
                entity.Price = model.Price;
                entity.IsFood = model.IsFood;
                entity.ItemType = (int)model.ItemType;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteStockItem(int stockItemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .StockItems
                        .Single(e => e.StockItemId == stockItemId);

                ctx.StockItems.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
