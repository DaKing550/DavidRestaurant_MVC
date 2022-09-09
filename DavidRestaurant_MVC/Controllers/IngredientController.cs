using DavidRestaurant.Data.Entities;
using DavidRestaurant.Models.Ingredients;
using DavidRestaurant.Services.Ingredients;
using Microsoft.AspNetCore.Mvc;

namespace DavidRestaurant_MVC.Controllers
{
    public class IngredientController : Controller
    {
        private IIngredientService _service;

        public IngredientController(IIngredientService service, InventoryDbContext context)
        {
            _service = service;

        }

        // GET: IngredientController
        public async Task<ActionResult> Index()
        {
            List<IngredientListItem> ingredients = await _service.GetAllIngredients();
            return View(ingredients);
        }

        // GET: IngredientController/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var ingredientdetails = await _service.GetIngredientById(id);
            return View(ingredientdetails);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: IngredientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IngredientCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            await _service.CreateIngredient(model);
            return RedirectToAction(nameof(Index));

        }

        // GET: IngredientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IngredientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(IngredientEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.UpdateIngredient(model);
            return RedirectToAction("Details", new { id = model.Id });
        }

        // GET: IngredientController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var ingredientdetails = await _service.GetIngredientById(id.Value);
            return View(ingredientdetails);
        }

        // POST: IngredientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _service.DeleteIngredient(id))
                return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }
    }
}
