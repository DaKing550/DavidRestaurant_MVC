using DavidRestaurant.Data.Entities;
using DavidRestaurant.Models.MenuItems;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidRestaurant.Services.MenuItems
{
    public class MenuItemService : IMenuItemService
    {
        private InventoryDbContext _context;
        public MenuItemService(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateMenuItem(MenuItemCreate model)
        {
            MenuItem menuItem = new MenuItem()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                TimesOrdered = model.TimesOrdered,
                RestaurantId = model.RestaurantId,

            };
            _context.MenuItems.Add(menuItem);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteMenuItem(int id)
        {
            MenuItem menuItem = await _context.MenuItems
                 .FirstOrDefaultAsync(x => x.Id == id);
            _context.MenuItems.Remove(menuItem);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<List<MenuItemListItem>> GetAllMenuItems()
        {
            List<MenuItemListItem> menuItems = await _context.MenuItems
                .Select(m => new MenuItemListItem()
                {
                    Id = m.Id,
                    Name = m.Name,
                    Description = m.Description,
                    TimesOrdered = m.TimesOrdered,
                    Price = m.Price

                }).ToListAsync();
            foreach (MenuItemListItem item in menuItems)
            {
                item.Cost = await FindCostOfMenuItem(item.Id);

            }
            return menuItems;
        }

        public async Task<MenuItemDetail> GetMenuItemById(int id)
        {
            MenuItem menuItem = await _context.MenuItems
                 .FirstOrDefaultAsync(x => x.Id == id);
            double cost = await FindCostOfMenuItem(id);

            MenuItemDetail menuItemDetail = new MenuItemDetail()
            {
                Id = menuItem.Id,
                Name = menuItem.Name,
                Description = menuItem.Description,
                Cost = cost,
                Price = menuItem.Price,
                TimesOrdered = menuItem.TimesOrdered,
                RestaurantId = menuItem.RestaurantId,

            };
            return menuItemDetail;
        }

        private async Task<double> FindCostOfMenuItem(int id)
        {
            List<RecipeItem> recipeItems = await _context.RecipeItems.Where(r => r.MenuItemId == id).ToListAsync();

            foreach (var item in recipeItems)
            {
                var ingredientItem = await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == item.IngredientId);
                item.Ingredient = ingredientItem;
            }
            var price = recipeItems.Select(r => r.AmountOfIngredient * r.Ingredient.PriceOfIngredient).Sum();
            return price;
        }

        public async Task<bool> UpdateMenuItem(MenuItemEdit model)
        {
            MenuItem menuItem = await _context.MenuItems.FirstAsync(I => I.Id == model.Id);

            menuItem.Name = model.Name;
            menuItem.Description = model.Description;
            menuItem.Price = model.Price;
            menuItem.TimesOrdered = model.TimesOrdered;
            menuItem.RestaurantId = model.RestaurantId;


            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<MenuItemCreate> BuildMenuItemCreate()
        {
            var menuItemCreate = new MenuItemCreate();
            menuItemCreate.Restaurants = await _context.Restaurants.ToListAsync();

            return menuItemCreate;
        }
    }
}
