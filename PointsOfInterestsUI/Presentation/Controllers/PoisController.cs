using System;
using AutoMapper;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class PoisController : Controller
    {
        private readonly IRepository _poiRepository;

        public PoisController(IRepository repository)
        {
            _poiRepository = repository;
        }

        // GET: Pois
        public IActionResult Index()
        {
            return View(_poiRepository.GetAll());
        }

        // GET: Pois/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poi = _poiRepository.GetById(id.Value);
      
            if (poi == null)
            {
                return NotFound();
            }

            return View(poi);
        }

        // GET: Pois/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pois/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Description,Lat,Long")] PoiViewModel poi)
        {
            if (ModelState.IsValid)
            {
                Poi concretePoi = new Poi(poi.Name, poi.Description, poi.Lat, poi.Long);
                _poiRepository.Create(concretePoi);
                return RedirectToAction(nameof(Index));
            }
            return NoContent();
        }

        // GET: Pois/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poi = _poiRepository.GetById(id.Value);
            if (poi == null)
            {
                return NotFound();
            }
            return View(poi);
        }

        // POST: Pois/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Name,Description,Lat,Long")] PoiViewModel poi)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PoiViewModel, Poi>();
            });
            IMapper mapper = config.CreateMapper();

            var concretePoi = _poiRepository.GetById(id);
            mapper.Map(poi,concretePoi);
            if (ModelState.IsValid)
            {
                try
                {
                    _poiRepository.Update(concretePoi);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoiExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(concretePoi);
        }

        // GET: Pois/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poi = _poiRepository.GetById(id.Value);

            if (poi == null)
            {
                return NotFound();
            }

            return View(poi);
        }

        // POST: Pois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _poiRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool PoiExists(Guid id)
        {
            return _poiRepository.GetById(id) != null;
        }
    }
}
