using eTickets.Data;
using eTickets.Data.Service;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var allActors = await _service.GetAll();
            return View(allActors);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, Bio, ProfilePictureURL")] Actor actor)
        { 
            
        }

        [HttpGet]
        public IActionResult Create()
        { 
            return View();
        }
    }
}
