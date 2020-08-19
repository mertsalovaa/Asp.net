using Planner.Entity;
using Planner.Models.Planner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Planner.Controllers
{
    public class PlannerController : Controller
    {
        private readonly EFContext _context;

        public PlannerController(EFContext context)
        {
            _context = context;
        }

        public PlannerController()
        {
            _context = new EFContext();
        }

        public ActionResult ListEvents()
        {
            List<EventViewModel> data = _context.Events.Select(t => new EventViewModel()
            {
                Id = t.Id,
                Date = t.Date,
                Description = t.Description,
                Image = t.Image,
                Title = t.Title
            }).ToList();

            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EventCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(new Event()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Date = model.Date,
                    Image = model.Image
                });
                _context.SaveChanges();
                return RedirectToAction("ListEvents", "Planner");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Delete(int id)
        {
            _context.Events.Remove(_context.Events.FirstOrDefault(s => s.Id == id));
            _context.SaveChanges();
            return RedirectToAction("ListEvents", "Planner");
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, EventCreateViewModel model)
        {
            Event edit = _context.Events.FirstOrDefault(e => e.Id == id);

            edit.Title = model.Title;

            edit.Description = model.Description;

            edit.Image = model.Image;
            edit.Date = model.Date;

            _context.SaveChanges();
            return RedirectToAction("ListEvents", "Planner");
        }

        public ActionResult Search(string name)
        {
            var events = _context.Events.Where(r => r.Title.Contains(name)).ToList();
            var convertedEvents = new List<EventViewModel>();
            foreach (var item in events)
            {
                convertedEvents.Add(new EventViewModel()
                {
                    Title = item.Title,
                    Date = item.Date,
                    Description = item.Description,
                    Image = item.Image
                });
            }
            if (convertedEvents.Count == 0)
            {
                return View("Error");
            }
            return View("ListEvents", convertedEvents);
        }
    }
}