using RestaurantRestockPro.Data;
using RestaurantRestockPro.Models.StockOrderModels;
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

        public StockOrderDetail GetStockOrderById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .StockOrders
                        .Single(e => e.StockOrderId == id);

                return
                    new StockOrderDetail()
                    {
                        StockOrderId = entity.StockOrderId,
                        Manager = entity.Manager,
                        OrderCreated = entity.OrderCreated,
                        OrderUpdated = entity.OrderUpdated
                    };
            }
        }

        public bool UpdateStockOrder(StockOrderEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .StockOrders
                        .Single(e => e.StockOrderId == model.StockOrderId);

                entity.Manager = model.Manager;
                entity.OrderUpdated = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteStockOrder(int stockOrderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .StockOrders
                        .Single(e => e.StockOrderId == stockOrderId);

                ctx.StockOrders.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
