using DavidRestaurant.Data.Entities;
using DavidRestaurant.Models.Ingredients;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidRestaurant.Services.Ingredients
{
    public class IngredientService : IIngredientService
    {
        private InventoryDbContext _context;
        public IngredientService(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateIngredient(IngredientCreate createDto)
        {
            Ingredient ingredient = new Ingredient()
            {
                IngredientName = createDto.IngredientName,
                AmountOfIngredient = createDto.AmountOfIngredient,
                PriceOfIngredient = createDto.PriceOfIngredient
            };
            _context.Ingredients.Add(ingredient);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteIngredient(int id)
        {
            Ingredient ingredient = await _context.Ingredients
                 .FirstOrDefaultAsync(x => x.Id == id);
            _context.Ingredients.Remove(ingredient);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<List<IngredientListItem>> GetAllIngredients()
        {
            var ingredients = await _context.Ingredients
                .Select(i => new IngredientListItem()
                {
                    Id = i.Id,
                    IngredientName = i.IngredientName,
                    AmountOfIngredient = i.AmountOfIngredient,
                    PriceOfIngredient = i.PriceOfIngredient
                }).ToListAsync();
            return ingredients;
        }

        public async Task<IngredientDetail> GetIngredientById(int id)
        {
            Ingredient ingredient = await _context.Ingredients
                 .FirstOrDefaultAsync(x => x.Id == id);


            IngredientDetail ingredientDetail = new IngredientDetail()
            {
                Id = ingredient.Id,
                IngredientName = ingredient.IngredientName,
                AmountOfIngredient = ingredient.AmountOfIngredient,
                PriceOfIngredient = ingredient.PriceOfIngredient,
            };
            return ingredientDetail;
        }

        public async Task<bool> UpdateIngredient(IngredientEdit model)
        {
            Ingredient ingredient = await _context.Ingredients.FirstAsync(I => I.Id == model.Id);

            ingredient.IngredientName = model.IngredientName;
            ingredient.AmountOfIngredient = model.AmountOfIngredient;
            ingredient.PriceOfIngredient = model.PriceOfIngredient;

            return await _context.SaveChangesAsync() == 1;

        }
    }
}
