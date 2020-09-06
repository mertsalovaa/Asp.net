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
    public class GenresController : Controller
    {
        // GET: Genres
        private readonly IGenreService genreService;
        private readonly IMapper mapper;

        public GenresController(IGenreService _genreService, IMapper _mapper)
        {
            genreService = _genreService;
            mapper = _mapper;
        }

        public ActionResult Index()
        {
            var genre = genreService.GetAllGenres();
            var model = mapper.Map<ICollection<GenreViewModel>>(genre);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GenreViewModel genre)
        {
            if (ModelState.IsValid)
            {
                genreService.AddGenre(mapper.Map<Genre>(genre));
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            genreService.DeleteGenre(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var found = genreService.GetAllGenres().FirstOrDefault(x => x.Id == id);
            var genre = mapper.Map<GenreViewModel>(found);
            return View(genre);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var found = genreService.GetAllGenres().FirstOrDefault(x => x.Id == id);
            var genre = mapper.Map<GenreViewModel>(found);
            return View(genre);
        }

        [HttpPost]
        public ActionResult Edit(GenreViewModel genre)
        {
            if (ModelState.IsValid)
            {
                genreService.UpdateGenre(mapper.Map<Genre>(genre));
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit", genre.Id);
        }
    }
}