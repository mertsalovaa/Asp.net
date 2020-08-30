using AutoMapper;
using GameesStore_client.Filter;
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
    public class GamesController : Controller
    {
        private readonly IGameService gameService;
        private readonly IMapper mapper;

        // #3
        public GamesController(IGameService _gameService, IMapper _mapper)
        {
            gameService = _gameService;
            mapper = _mapper;
        }


        // GET: Games
        public ActionResult Index(string type, string name)
        {
            SetFilters();
            ICollection<Game> games = null;
            if (type != null && name != null)
            {
                AddFilter(type, name);
                games = gameService.FilterGames(Session["GameFilters"] as List<GameFilter>);
            }
            else
            {
                games = gameService.GetAllGames();
            }
            var model = mapper.Map<ICollection<GameViewModel>>(games);


            return View(model);
            #region manual mapping List<Game> => ICollection<GameViewModel>
            //List<GameViewModel> model = new List<GameViewModel>();
            //foreach (var item in games)
            //{
            //    model.Add(new GameViewModel()
            //    {
            //        Id = item.Id,
            //        Name = item.Name,
            //        Description = item.Description,
            //        Year = item.Year,
            //        Image = item.Image,
            //        Price = item.Price,
            //        Developer = item.Developer.Company,
            //        Genre = item.Genre.Name
            //    });
            //} 
            #endregion
        }
        [HttpGet]
        public ActionResult Filter(string type, string name)
        {
            ICollection<Game> games = null;
            if (type != null && name != null)
            {
                AddFilter(type, name);
                games = gameService.FilterGames(Session["GameFilters"] as List<GameFilter>);
            }
            else
            {
                games = gameService.GetAllGames();
            }
            var model = mapper.Map<ICollection<GameViewModel>>(games);
            return PartialView("Partial/CardPartial", model);
        }

        private void AddFilter(string type, string name)
        {
            var filters = Session["GameFilters"] as List<GameFilter>;

            if (filters == null)
            {
                filters = new List<GameFilter>();
            }


            var isExists = filters.FirstOrDefault(x => x.Name == name && x.Type == type);
            if (isExists != null)
            {
                filters.Remove(isExists);
                Session["GameFilters"] = filters;
                return;
            }

            GameFilter filter = new GameFilter()
            {
                Type = type,
                Name = name
            };

            if (type == "Developer")
            {
                filter.Predicate = (x => x.Developer.Company == name);
            }
            if (type == "Genre")
            {
                filter.Predicate = (x => x.Genre.Name == name);
            }
            filters.Add(filter);

            Session["GameFilters"] = filters;
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetFilters();

            return View();
        }

        private void SetFilters()
        {
            ViewBag.Genres = gameService.GetAllGenres();
            ViewBag.Developers = gameService.GetAllDevelopers();
        }

        [HttpPost]
        public ActionResult Create(GameViewModel game)
        {
            if (ModelState.IsValid)
            {
                gameService.AddGame(mapper.Map<Game>(game));
                return RedirectToAction("Index");
            }
            return Create();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            SetFilters();

            var found = gameService.GetAllGames().FirstOrDefault(x => x.Id == id);
            var game = mapper.Map<GameViewModel>(found);
            return View(game);
        }

        [HttpPost]
        public ActionResult Edit(GameViewModel model)
        {
            if (ModelState.IsValid)
            {
                gameService.UpdateGame(mapper.Map<Game>(model));
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit", model.Id);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            gameService.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var found = gameService.GetAllGames().FirstOrDefault(x => x.Id == id);
            var game = mapper.Map<GameViewModel>(found);
            return View(game);
        }

        public ActionResult Search(string name)
        {
            SetFilters();
            var games = gameService.Search(name);
            if (games.Count > 0)
            {
                var model = mapper.Map<ICollection<GameViewModel>>(games);
                return RedirectToAction("Index", "Games", model);
            }
            else
            {
                return RedirectToAction("Index", "Games", gameService.GetAllGames());
            }
        }
    }
}