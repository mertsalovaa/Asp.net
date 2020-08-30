using AutoMapper;
using GameesStore_client.Models;
using GamesStore_bll.Services.Abstraction;
using GamesStore_dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameesStore_client.Controllers
{
    public class DevelopersController : Controller
    {
        // GET: Developers
        private readonly IDeveloperService devService;
        private readonly IMapper mapper;

        public DevelopersController(IDeveloperService _devService, IMapper _mapper)
        {
            devService = _devService;
            mapper = _mapper;
        }

        public ActionResult Index()
        {
            var dev = devService.GetAllDevelopers();
            var model = mapper.Map<ICollection<DeveloperViewModel>>(dev);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DeveloperViewModel developer)
        {
            if (ModelState.IsValid)
            {
                devService.AddDeveloper(mapper.Map<Developer>(developer));
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            devService.DeleteDeveloper(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var found = devService.GetAllDevelopers().FirstOrDefault(x => x.Id == id);
            var dev = mapper.Map<DeveloperViewModel>(found);
            return View(dev);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var found = devService.GetAllDevelopers().FirstOrDefault(x => x.Id == id);
            var dev = mapper.Map<DeveloperViewModel>(found);
            return View(dev);
        }

        [HttpPost]
        public ActionResult Edit(DeveloperViewModel developer)
        {
            if (ModelState.IsValid)
            {
                devService.UpdateDeveloper(mapper.Map<Developer>(developer));
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit", developer.Id);
        }
    }
}