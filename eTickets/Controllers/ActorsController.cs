using eTickets.Data.Service;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allActors = await _service.GetAllAsync();
            return View(allActors);
        }

        #region Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

           await _service.AddAsync(actor);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        { 
            return View();
        }
        #endregion

        #region Details
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        { 
            var actorDetails =  await _service.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");

            return View(actorDetails);
        }
        #endregion

        #region Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var actor = await _service.GetByIdAsync(id);

            if (actor == null)
            {
                return NotFound();
            }
            return View(actor); 
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var actor = await _service.GetByIdAsync(id);
           
            if (actor == null)
            {
                return NotFound();
            }

             await _service.DeleteAsync(id);
            return RedirectToAction("Index");   
        }
        #endregion

        #region Edit

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var actor = await _service.GetByIdAsync(id);

            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> EditConfirm(int id, [Bind("FullName,ProfilePictureURL,Bio,Id")] Actor updatedActor)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedActor);
            }
            await _service.UpdateAsync(id,updatedActor);
            return RedirectToAction("Index");
        }
        #endregion

    }
}
