using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidRestaurant.Data.Entities
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string IngredientName { get; set; }
        [Required]
        public int AmountOfIngredient { get; set; }
        [Required]
        public double PriceOfIngredient { get; set; }
    }
}
