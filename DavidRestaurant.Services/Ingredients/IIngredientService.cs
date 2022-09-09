using DavidRestaurant.Models.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidRestaurant.Services.Ingredients
{
    public interface IIngredientService
    {
        Task<bool> CreateIngredient(IngredientCreate model);
        Task<List<IngredientListItem>> GetAllIngredients();
        Task<IngredientDetail> GetIngredientById(int id);
        Task<bool> UpdateIngredient(IngredientEdit model);
        Task<bool> DeleteIngredient(int id);
    }
}
