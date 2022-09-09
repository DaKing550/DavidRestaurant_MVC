using DavidRestaurant.Models.MenuItems;
using DavidRestaurant.Services.MenuItems;
using Microsoft.AspNetCore.Mvc;

namespace DavidRestaurant_MVC.Controllers
{
    public class MenuItemController : Controller
    {
        private IMenuItemService _service;

        public MenuItemController(IMenuItemService service)
        {
            _service = service;
        }

        // GET: MenuItemController
        public async Task<ActionResult> Index()
        {
            List<MenuItemListItem> menuItems = await _service.GetAllMenuItems();
            return View(menuItems);
        }

        // GET: MenuItemController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var menuItemDetails = await _service.GetMenuItemById(id);

            return View(menuItemDetails);

        }

        // GET: MenuItemController/Create
        public async Task<IActionResult> Create()
        {
            var menuItemCreate = await _service.BuildMenuItemCreate();
            return View(menuItemCreate);
        }

        // POST: MenuItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MenuItemCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            await _service.CreateMenuItem(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: MenuItemController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MenuItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MenuItemEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.UpdateMenuItem(model);
            return RedirectToAction("Details", new { id = model.Id });
        }

        // GET: MenuItemController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var MenuItemdetails = await _service.GetMenuItemById(id.Value);
            return View(MenuItemdetails);
        }

        // POST: MenuItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            if (await _service.DeleteMenuItem(id))
                return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }
    }
}
