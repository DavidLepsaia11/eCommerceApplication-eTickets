using eTickets.Domain.Interfaces.Repositories;
using eTickets.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorRepository _repository;

        public ActorsController(IActorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var allActors = await _repository.GetAllAsync();
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

           await _repository.AddAsync(actor);

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
            var actorDetails =  await _repository.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");

            return View(actorDetails);
        }
        #endregion

        #region Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var actor = await _repository.GetByIdAsync(id);

            if (actor == null)
            {
                return NotFound();
            }
            return View(actor); 
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var actor = await _repository.GetByIdAsync(id);
           
            if (actor == null)
            {
                return NotFound();
            }

             await _repository.DeleteAsync(id);
            return RedirectToAction("Index");   
        }
        #endregion

        #region Edit

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var actor = await _repository.GetByIdAsync(id);

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
            await _repository.UpdateAsync(id,updatedActor);
            return RedirectToAction("Index");
        }
        #endregion

    }
}
