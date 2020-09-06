using AutoMapper;
using GameesStore_client.Models;
using GameesStore_client.Utils;
using GamesStore_bll.Services.Abstraction;
using GamesStore_bll.Services.Implementation;
using GamesStore_dal.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameesStore_client.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart

        private readonly IMapper mapper;
        private readonly IGameService gameService;
        private readonly ICartService cartService;

        public CartController(IMapper _mapper, IGameService _gameService, ICartService _cartService)
        {
            mapper = _mapper;
            gameService = _gameService;
            cartService = _cartService;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(int id)
        {
            var manager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var user = manager.FindByName(User.Identity.Name);
            var game = gameService.GetAllGames().FirstOrDefault(x => x.Id == id);

            cartService.AddToCart(id, user.Id.ToString());
           
            return RedirectToAction("Index", "Games");
        }
    }
}