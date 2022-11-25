﻿using eTickets.Data;
using eTickets.Data.Service;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaService _service;

        public CinemasController(ICinemaService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allCinemas = await _service.GetAllAsync();
            return View(allCinemas);
        }

        #region Edit

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await _service.GetByIdAsync(id);

            if (cinema == null)
            {
               return NotFound();
            }
            return View(cinema);
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> EditConfirm(int id, [Bind("Name,Logo,Description,Id")] Cinema updatedCinema)
        {
            // Cinema-ს მოდელს არ ადევს ვალიდაციები და ამიტომაც შემოდის if ოპერატორში.

            if (!ModelState.IsValid)
            {
                return View(updatedCinema);
            }
            await _service.UpdateAsync(id, updatedCinema);
            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        { 
           var cinema = await _service.GetByIdAsync(id);

            if (cinema == null)
            {
                return NotFound();
            }
            return View(cinema);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var cinema = await _service.GetByIdAsync(id);

            if (cinema == null)
            {
                return NotFound();
            }
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        #endregion

        #region Create 

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Logo,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.AddAsync(cinema);
            return RedirectToAction("Index");
        }
        #endregion

    }
}
