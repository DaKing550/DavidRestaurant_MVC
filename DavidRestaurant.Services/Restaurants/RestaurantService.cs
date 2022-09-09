using DavidRestaurant.Data.Entities;
using DavidRestaurant.Models.Restaurants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidRestaurant.Services.Restaurants
{
    public class RestaurantService : IRestaurantService
    {
        private InventoryDbContext _context;
        public RestaurantService(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateRestaurant(RestaurantCreate model)
        {
            Restaurant restaurant = new Restaurant()
            {
                Name = model.Name,
                Location = model.Location,
            };
            _context.Restaurants.Add(restaurant);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteRestaurant(int id)
        {
            Restaurant restaurant = await _context.Restaurants
                 .FirstOrDefaultAsync(x => x.Id == id);
            _context.Restaurants.Remove(restaurant);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<List<RestaurantListItem>> GetAllRestaurants()
        {
            List<RestaurantListItem> restaurants = await _context.Restaurants
                .Select(r => new RestaurantListItem
                {
                    Id = r.Id,
                    Name = r.Name,
                    Location = r.Location
                }).ToListAsync();
            return restaurants;
        }

        public async Task<RestaurantDetail> GetRestaurantById(int id)
        {
            Restaurant restaurant = await _context.Restaurants
                 .FirstOrDefaultAsync(x => x.Id == id);


            RestaurantDetail RestaurantDetail = new RestaurantDetail()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Location = restaurant.Location
            };
            return RestaurantDetail;
        }

        public async Task<bool> UpdateRestaurant(RestaurantEdit model)
        {
            Restaurant restaurant = await _context.Restaurants.FirstAsync(I => I.Id == model.Id);

            restaurant.Name = model.Name;
            restaurant.Location = model.Location;

            return await _context.SaveChangesAsync() == 1;
        }
    }
}
