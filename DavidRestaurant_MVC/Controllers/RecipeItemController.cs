using DavidRestaurant.Models.RecipeItems;
using DavidRestaurant.Services.RecipeItems;
using Microsoft.AspNetCore.Mvc;

namespace DavidRestaurant_MVC.Controllers
{
    public class RecipeItemController : Controller
    {
        private IRecipeItemService _service;

        public RecipeItemController(IRecipeItemService service)
        {
            _service = service;
        }

        // GET: RecipeItemController
        public async Task<ActionResult> Index()
        {
            List<RecipeItemListItem> recipeItems = await _service.GetAllRecipeItems();
            return View(recipeItems);
        }

        // GET: RecipeItemController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var recipeItemdetails = await _service.GetRecipeItemById(id);
            return View(recipeItemdetails);
        }

        // GET: RecipeItemController/Create
        public async Task<IActionResult> Create()
        {
            var recipeItemCreate = await _service.BuildRecipeItemCreate();
            return View(recipeItemCreate);
        }

        // POST: RecipeItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RecipeItemCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            await _service.CreateRecipeItem(model);
            return RedirectToAction(nameof(Index));
        }


        // GET: RecipeItemController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        // POST: RecipeItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RecipeItemEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.UpdateRecipeItem(model);
            return RedirectToAction("Details", new { id = model.Id });

        }

        // GET: RecipeItemController/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var recipeItemdetails = await _service.GetRecipeItemById(id.Value);
            return View(recipeItemdetails);
        }

        // POST: RecipeItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            if (await _service.DeleteRecipeItem(id))
                return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }
    }
}
