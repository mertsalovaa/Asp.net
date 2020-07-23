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

        public ActionResult Details(int id)
        {
            var rooms = dbContext.EscapeQuests.ToList();
            ViewBag.Detail = rooms.FirstOrDefault(r => r.Id == id);
            return View();
        }

        public ActionResult Search(string name)
        {
            var rooms = dbContext.EscapeQuests.Where(r => r.Name.Contains(name)).ToList();
            if (rooms.Count == 0)
            {
                return View("Error");
            }
            ViewBag.SearchedRooms = rooms;
            return View();
        }
    }
}