using RestaurantRestockPro.Data;
using RestaurantRestockPro.Models.StockOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRestockPro.Services
{
    public class StockOrderService
    {
        private readonly Guid _userId;

        public StockOrderService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateStockOrder(StockOrderCreate model)
        {
            var entity =
                new StockOrder()
                {
                    Manager = model.Manager,
                    OrderCreated = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.StockOrders.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<StockOrderListItem> GetStockOrders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .StockOrders
                        .Select(e => new StockOrderListItem()
                        {
                            StockOrderId = e.StockOrderId,
                            Manager = e.Manager,
                            OrderCreated = e.OrderCreated
                        });
                return query.ToList();
            }
        }
    }
}
