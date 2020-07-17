using EscapeQuest_DZ.DacaAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EscapeQuest_DZ.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        private EscapeContext dbContext = new EscapeContext();
        public ActionResult Index()
        {
            var rooms = dbContext.EscapeQuests.ToList();
            ViewBag.Rooms = rooms;
            return View();
        }
    }
}