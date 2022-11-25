using eTickets.Data;
using eTickets.Data.Service;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducerService _service;

        public ProducersController(IProducerService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAllAsync();
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
            var producerDetails = await _service.GetByIdAsync(id);

            if (producerDetails == null) return View("NotFound");

            return View(producerDetails);
        }
        #endregion

        #region Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var producer = await _service.GetByIdAsync(id);

            if (producer == null)
            {
                return NotFound();
            }
            return View(producer);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var producer = await _service.GetByIdAsync(id);

            if (producer == null)
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
            var producer = await _service.GetByIdAsync(id);

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
            await _service.UpdateAsync(id, updatedProducer);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
