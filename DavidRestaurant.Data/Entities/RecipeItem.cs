using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidRestaurant.Data.Entities
{
    public class RecipeItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AmountOfIngredient { get; set; }

        [ForeignKey("MenuItem")]
        public int MenuItemId { get; set; }

        [ForeignKey("Ingredient")]
        public int IngredientId { get; set; }

        
        public MenuItem MenuItem { get; set; }

        
        public Ingredient Ingredient { get; set; }
    }
}
