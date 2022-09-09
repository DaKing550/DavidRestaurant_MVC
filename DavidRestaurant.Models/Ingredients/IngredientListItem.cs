using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidRestaurant.Models.Ingredients
{
    public class IngredientListItem
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }
        public int AmountOfIngredient { get; set; }
        public double PriceOfIngredient { get; set; }
    }
}
