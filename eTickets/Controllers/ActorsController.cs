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

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        { 
           var actorDetails =  await _service.GetByIdAsync(id);

            if (actorDetails == null) return View("Empty");

            return View(actorDetails);
        }

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
        
    }
}
