using DavidRestaurant.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidRestaurant.Models.RecipeItems
{
    public class RecipeItemCreate
    {

        [Required]
        public int AmountOfIngredient { get; set; }
        [Required]
        public int MenuItemId { get; set; }
        [Required]
        public int IngredientId { get; set; }
        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
