using AutoMapper;
using GameesStore_client.Filter;
using GameesStore_client.Models;
using GameesStore_client.Utils;
using GameesStore_client.Utils.Helper;
using GamesStore_bll.Services.Abstraction;
using GamesStore_dal.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace GameesStore_client.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameService gameService;
        private readonly ICartService cartService;
        private readonly IMapper mapper;

        // #3
        public GamesController(IGameService _gameService, IMapper _mapper, ICartService _cartService)
        {
            gameService = _gameService;
            mapper = _mapper;
            cartService = _cartService;
        }


        // GET: Games
        public ActionResult Index(string type, string name)
        {
            var manager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var user = manager.FindByName(User.Identity.Name);
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
            ViewBag.CountGames = cartService.CountProducts(user.Id);

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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Create(GameViewModel model, HttpPostedFileBase image)
        {
            if (image != null && (image.ContentType.Contains("image")))
            {
                //
                if (ModelState.IsValid)
                {
                    // 1.jpg
                    string fileName = Guid.NewGuid().ToString() + ".jpg";

                    string fullPath = Server.MapPath("~/img/") + fileName;

                    var convertedPicture = CustomImageConvertor.ConverrtBitmap(new Bitmap(image.InputStream), 300, 300);
                    if (convertedPicture != null)
                    {
                        convertedPicture.Save(fullPath, ImageFormat.Jpeg);
                        model.Image = "/img/" + fileName;
                    }
                    gameService.AddGame(mapper.Map<Game>(model));
                    return RedirectToAction("Index");
                }
            }
            if (image == null && model.Image != null)
            {
                string fileName = Guid.NewGuid().ToString() + ".jpg";
                string fullPath = Server.MapPath("~/img/") + fileName;
                Bitmap convertedPicture;
                if (!model.Image.StartsWith("http"))
                {
                    const string ExpectedImagePrefix = "data:image/png;base64,";
                    string base64 = model.Image.Substring(ExpectedImagePrefix.Length);
                    var bytes = Convert.FromBase64String(base64);

                    convertedPicture = CustomImageConvertor.ConverrtBitmap(new Bitmap(new MemoryStream(bytes)), 300, 300);
                    if (convertedPicture != null)
                    {
                        convertedPicture.Save(fullPath, ImageFormat.Jpeg);
                        model.Image = "/img/" + fileName;
                    }
                    gameService.AddGame(mapper.Map<Game>(model));
                    return RedirectToAction("Index");
                }

                WebRequest request = WebRequest.Create(model.Image);
                var responce = request.GetResponse();
                fileName = Guid.NewGuid().ToString() + ".jpg";

                fullPath = Server.MapPath("~/img/") + fileName;
                var stream = responce.GetResponseStream();
                convertedPicture = CustomImageConvertor.ConverrtBitmap(new Bitmap(stream), 300, 300);
                if (convertedPicture != null)
                {
                    convertedPicture.Save(fullPath, ImageFormat.Jpeg);
                    model.Image = "/img/" + fileName;
                }
                gameService.AddGame(mapper.Map<Game>(model));
                return RedirectToAction("Index");
            }
            return Create();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            SetFilters();

            var found = gameService.GetAllGames().FirstOrDefault(x => x.Id == id);
            var game = mapper.Map<GameViewModel>(found);
            return View(game);
        }

        [Authorize]
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
        [Authorize]
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
            ICollection<Game> games = new List<Game>();
            SetFilters();
            games = gameService.Search(name);
            if (games.Count > 0)
            {
                var model = mapper.Map<ICollection<GameViewModel>>(games);
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Games", gameService.GetAllGames());
            }
        }
    }
}