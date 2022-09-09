using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidRestaurant.Models.MenuItems
{
    public class MenuItemDetail
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public double Cost { get; set; } = 0.0;

        public int TimesOrdered { get; set; }
        public int RestaurantId { get; set; }
    }
}
