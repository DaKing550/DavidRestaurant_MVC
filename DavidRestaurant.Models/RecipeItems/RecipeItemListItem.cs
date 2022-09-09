using DavidRestaurant.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidRestaurant.Models.RecipeItems
{
    public class RecipeItemListItem
    {
        public int Id { get; set; }
        public int AmountOfIngredient { get; set; }
        public int MenuItemId { get; set; }
        public int IngredientId { get; set; }
        public MenuItem MenuItem { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
