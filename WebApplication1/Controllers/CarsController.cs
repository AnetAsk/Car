using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Data;
using WebApplication1.Rp;

namespace WebApplication1.Controllers
{
    public class CarsController : Controller
    {
        private readonly UnitOfWork _uow;

        public CarsController(UnitOfWork uow)
        {
            _uow = uow;
        }

        public IActionResult Index()
        {
            return View(_uow.Cars.GetAll());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _uow.Cars.Get(id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        public IActionResult Create()
        {
            ViewBag.Colors = new SelectList(Enum.GetValues(typeof(ConsoleColor)));
            ViewBag.Model = new SelectList(Enum.GetValues(typeof(Model)));
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Type,Id,Model")] Car car)
        {
            if (ModelState.IsValid)
            {
                _uow.Cars.Create(car);
                _uow.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _uow.Cars.Get(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewBag.Colors = new SelectList(Enum.GetValues(typeof(ConsoleColor)));
            ViewBag.Model = new SelectList(Enum.GetValues(typeof(Model)));
            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Type,Id,Model")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Cars.Edit(car);
                _uow.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _uow.Car.Get(id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var car = _uow.Cars.Get(id);
            _uow.Cars.Remove(car);
            _uow.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
