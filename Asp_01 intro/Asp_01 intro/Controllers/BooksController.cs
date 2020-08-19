using Asp_01_intro.DataBase;
using Asp_01_intro.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp_01_intro.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        private BooksContext dbContext = new BooksContext();

        public BooksController()
        {
            //books = new List<Book>
            //{
            //    new Book{Name = "Clean code", Author = "R.S. Martin", Year = 2019, Pages = 278, Img="https://miro.medium.com/max/4000/0*OqqCb1Pki8hgv8VE.jpg"},
            //    new Book{Name = "Clean architecture", Author = "R.S. Martin", Year = 2019, Pages = 300, Img="https://images-na.ssl-images-amazon.com/images/I/51llKzRG8RL._AC_SY400_.jpg"},
            //    new Book{Name = "Harry Potter", Author = "J.K. Roling", Year = 2010, Pages = 765, Img="https://images3.penguinrandomhouse.com/cover/9780739360385"},
            //    new Book{Name = "Clean Poetry", Author = "Lina Kostenko", Year = 2015, Pages = 250, Img="http://umka.com/images/product/8711_l.jpg"}
            //};
        }

        public ActionResult Index(string genre)
        {
            SetGenres();
            var books = dbContext.Books.ToList();
            if (genre == "All")
                ViewBag.Books = books;
            else
            {
                ViewBag.Books = books.Where(x => x.Genre.Name == genre).ToList();
            }
            return View();
        }


        // localhost:1324/Books/Details
        public ActionResult Details(int id)
        {
            SetGenres();
            var books = dbContext.Books.ToList();
            ViewBag.Detail = books.FirstOrDefault(x => x.Id == id);
            return View();
        }

        private void SetGenres()
        {
            ViewBag.Genres = dbContext.Genres.ToList();
        }
    }

}