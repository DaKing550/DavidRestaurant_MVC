using DavidRestaurant.Models.MenuItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidRestaurant.Services.MenuItems
{
    public interface IMenuItemService
    {
        Task<bool> CreateMenuItem(MenuItemCreate model);
        Task<List<MenuItemListItem>> GetAllMenuItems();
        Task<MenuItemDetail> GetMenuItemById(int id);
        Task<bool> UpdateMenuItem(MenuItemEdit model);
        Task<bool> DeleteMenuItem(int id);
        Task<MenuItemCreate> BuildMenuItemCreate();
    }
}
