using RestaurantRestockPro.Data;
using RestaurantRestockPro.Models.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRestockPro.Services
{
    public class RestaurantService
    {
        private readonly Guid _userId;

        public RestaurantService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRestaurant(RestaurantCreate model)
        {
            var entity =
                new Restaurant()
                {
                    OwnerId = _userId,
                    RestaurantName = model.RestaurantName,
                    RestaurantLocation = model.RestaurantLocation
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Restaurants.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RestaurantListItem> GetRestaurants()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Restaurants
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new RestaurantListItem
                                {
                                    RestaurantId = e.RestaurantId,
                                    RestaurantName = e.RestaurantName
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
