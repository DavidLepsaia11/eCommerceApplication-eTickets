
using eTickets.Domain.Interfaces.Repositories;
using eTickets.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducerRepository _repository;

        public ProducersController(IProducerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var allProducers = await _repository.GetAllAsync();
            return View(allProducers);
        }


        #region Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Producer actor)
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
            var producerDetails = await _repository.GetByIdAsync(id);

            if (producerDetails == null) return View("NotFound");

            return View(producerDetails);
        }
        #endregion

        #region Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var producer = await _repository.GetByIdAsync(id);

            if (producer == null)
            {
                return NotFound();
            }
            return View(producer);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var producer = await _repository.GetByIdAsync(id);

            if (producer == null)
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
            var producer = await _repository.GetByIdAsync(id);

            if (producer == null)
            {
                return NotFound();
            }

            return View(producer);
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> EditConfirm(int id, [Bind("FullName,ProfilePictureURL,Bio,Id")] Producer updatedProducer)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedProducer);
            }
            await _repository.UpdateAsync(id, updatedProducer);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
