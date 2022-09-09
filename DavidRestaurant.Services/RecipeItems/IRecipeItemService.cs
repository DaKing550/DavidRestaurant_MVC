using DavidRestaurant.Models.RecipeItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidRestaurant.Services.RecipeItems
{
    public interface IRecipeItemService
    {
        Task<bool> CreateRecipeItem(RecipeItemCreate model);
        Task<List<RecipeItemListItem>> GetAllRecipeItems();
        Task<RecipeItemDetail> GetRecipeItemById(int id);
        Task<bool> UpdateRecipeItem(RecipeItemEdit model);
        Task<bool> DeleteRecipeItem(int id);

        Task<RecipeItemCreate> BuildRecipeItemCreate();
    }
}
