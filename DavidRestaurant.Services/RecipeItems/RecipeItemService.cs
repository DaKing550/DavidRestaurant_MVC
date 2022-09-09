using DavidRestaurant.Data.Entities;
using DavidRestaurant.Models.RecipeItems;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidRestaurant.Services.RecipeItems
{
    public class RecipeItemService : IRecipeItemService
    {
        private InventoryDbContext _context;
        public RecipeItemService(InventoryDbContext context)
        {
            _context = context;
        }



        public async Task<bool> CreateRecipeItem(RecipeItemCreate model)
        {
            RecipeItem item = new RecipeItem()
            {
                AmountOfIngredient = model.AmountOfIngredient,
                MenuItemId = model.MenuItemId,
                IngredientId = model.IngredientId,
            };
            _context.RecipeItems.Add(item);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteRecipeItem(int id)
        {
            RecipeItem recipeItem = await _context.RecipeItems
                 .FirstOrDefaultAsync(x => x.Id == id);
            _context.RecipeItems.Remove(recipeItem);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<List<RecipeItemListItem>> GetAllRecipeItems()
        {

            List<RecipeItemListItem> recipeItems = await _context.RecipeItems
                .Select(r => new RecipeItemListItem()
                {
                    Id = r.Id,
                    AmountOfIngredient = r.AmountOfIngredient,
                    IngredientId = r.IngredientId,
                    MenuItemId = r.MenuItemId,


                }).ToListAsync();
            foreach (RecipeItemListItem item in recipeItems)
            {
                var ingredient = await _context.Ingredients.Where(i => i.Id == item.IngredientId).FirstOrDefaultAsync();
                var menuItem = await _context.MenuItems.Where(m => m.Id == item.MenuItemId).FirstOrDefaultAsync();

                item.Ingredient = ingredient;
                item.MenuItem = menuItem;

            }
            return recipeItems;
        }

        public async Task<RecipeItemDetail> GetRecipeItemById(int id)
        {
            RecipeItem recipeItem = await _context.RecipeItems
                 .FirstOrDefaultAsync(x => x.Id == id);
            var ingredientItem = await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == recipeItem.IngredientId);
            recipeItem.Ingredient = ingredientItem;

            var menuItem = await _context.MenuItems.FirstOrDefaultAsync(m => m.Id == recipeItem.MenuItemId);
            recipeItem.MenuItem = menuItem;

            RecipeItemDetail recipeItemDetail = new RecipeItemDetail()
            {
                Id = recipeItem.Id,
                AmountOfIngredient = recipeItem.AmountOfIngredient,
                Ingredient = recipeItem.Ingredient,
                IngredientId = recipeItem.IngredientId,
                MenuItem = recipeItem.MenuItem,
                MenuItemId = recipeItem.MenuItemId,


            };
            return recipeItemDetail;
        }

        public async Task<bool> UpdateRecipeItem(RecipeItemEdit model)
        {
            RecipeItem recipeItem = await _context.RecipeItems.FirstAsync(I => I.Id == model.Id);

            recipeItem.AmountOfIngredient = model.AmountOfIngredient;
            recipeItem.IngredientId = model.IngredientId;
            recipeItem.MenuItemId = model.MenuItemId;

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<RecipeItemCreate> BuildRecipeItemCreate()
        {
            var recipeItemCreate = new RecipeItemCreate();
            recipeItemCreate.MenuItems = await _context.MenuItems.ToListAsync();
            recipeItemCreate.Ingredients = await _context.Ingredients.ToListAsync();

            return recipeItemCreate;
        }
    }
}
