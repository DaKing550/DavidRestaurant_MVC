using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidRestaurant.Models.RecipeItems
{
    public class RecipeItemEdit
    {
        public int Id { get; set; }
        [Required]
        public int AmountOfIngredient { get; set; }
        public int MenuItemId { get; set; }
        public int IngredientId { get; set; }
    }
}
