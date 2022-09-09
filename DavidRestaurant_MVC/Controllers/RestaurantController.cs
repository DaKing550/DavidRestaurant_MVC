using DavidRestaurant.Models.Restaurants;
using DavidRestaurant.Services.Restaurants;
using Microsoft.AspNetCore.Mvc;

namespace DavidRestaurant_MVC.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantService _service;

        public RestaurantController(IRestaurantService service)
        {
            _service = service;
        }

        // GET: RestaurantController
        public async Task<ActionResult> Index()
        {
            List<RestaurantListItem> restaurants = await _service.GetAllRestaurants();
            return View(restaurants);
        }

        // GET: RestaurantController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var restaurantDetails = await _service.GetRestaurantById(id);
            return View(restaurantDetails);
        }

        // GET: RestaurantController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaurantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RestaurantCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            await _service.CreateRestaurant(model);
            return RedirectToAction(nameof(Index));
        }


        // GET: RestaurantController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RestaurantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RestaurantEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.UpdateRestaurant(model);
            return RedirectToAction("Details", new { id = model.Id });
        }

        // GET: RestaurantController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var restaurantdetails = await _service.GetRestaurantById(id.Value);
            return View(restaurantdetails);
        }

        // POST: RestaurantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            if (await _service.DeleteRestaurant(id))
                return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }
    }
}
