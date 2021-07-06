using RestaurantRestockPro.Data;
using RestaurantRestockPro.Models.Restock;
using RestaurantRestockPro.Models.StockItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRestockPro.Services
{
    public class RestockService
    {
        private readonly Guid _userId;

        public RestockService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRestock(RestockCreate model)
        {
            var entity =
                new Restock()
                {
                    StockItemId = model.StockItemId,
                    StockOrderId = model.StockOrderId,
                    Quantity = model.Quantity
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Restocks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RestockListItem> GetRestock()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Restocks.ToArray();
                return query.Select(
                    e =>
                        new RestockListItem
                        {
                            RestockId = e.RestockId,
                            StockItemId = e.StockItemId,
                            StockItem = new StockItemListItem
                            {
                                Name = e.StockItem.Name,
                                StockItemId = e.StockItem.StockItemId
                            },
                            StockOrderId = e.StockOrderId,
                            StockOrder = new Models.StockOrder.StockOrderListItem
                            {
                                Manager = e.StockOrder.Manager,
                                StockOrderId = e.StockOrder.StockOrderId
                            }
                        }
                    ).ToArray();
            }
        }

        public RestockDetail GetRestockById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Restocks.Single(e => e.RestockId == id);
                return new RestockDetail
                {
                    RestockId = entity.RestockId,
                    Quantity = entity.Quantity,
                    StockItemId = entity.StockItemId,
                    StockItem = new StockItemListItem
                    {
                        StockItemId = entity.StockItem.StockItemId,
                        Name = entity.StockItem.Name,
                    },
                    StockOrderId = entity.StockOrderId,
                    StockOrder = new Models.StockOrder.StockOrderListItem
                    {
                        StockOrderId = entity.StockOrder.StockOrderId,
                        Manager = entity.StockOrder.Manager
                    }
                };
            }
        }

    }
}
