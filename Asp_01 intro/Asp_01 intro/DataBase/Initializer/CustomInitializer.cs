using Asp_01_intro.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Asp_01_intro.DataBase.Initializer
{
    public class CustomInitializer : DropCreateDatabaseAlways<BooksContext>
    {
        protected override void Seed(BooksContext context)
        {
            var genre = new List<Genre>()
            {
                new Genre{Name="IT"},
                new Genre{Name="Fantastic"},
                new Genre{Name="Tales"},
                new Genre{Name="Liric"},
                new Genre{Name="Novels"}
            };

            var author = new List<Author>
            {
                new Author{Name="R.S.Martin"},
                new Author{Name="J.K. Roling"},
                new Author{Name="L. Kostenko"},
                new Author{Name="S. Lafore"}
            };

            var books = new List<Book>
            {
                new Book{Name="Clean code",
                    Desc="About good practice to code",
                    Img="https://miro.medium.com/max/4000/0*OqqCb1Pki8hgv8VE.jpg",
                Pages=246,
                Genre = genre.FirstOrDefault(g=>g.Name == "IT"),
                Year = 2019,
                Author = author.FirstOrDefault(a=>a.Name == "R.S.Martin")
                },
                new Book{Name="Clean architecture",
                    Desc="About good practice to code",
                    Img="https://images-na.ssl-images-amazon.com/images/I/51llKzRG8RL._AC_SY400_.jpg",
                Pages=220,
                Genre = genre.FirstOrDefault(g=>g.Name == "IT"),
                Year = 2019,
                Author = author.FirstOrDefault(a=>a.Name == "R.S.Martin")
                },
                new Book{Name="Harry Potter",
                    Desc="Nice tale",
                    Img="https://images3.penguinrandomhouse.com/cover/9780739360385",
                Pages=579,
                Genre = genre.FirstOrDefault(g=>g.Name == "Fantastic"),
                Year = 2019,
                Author = author.FirstOrDefault(a=>a.Name == "J.K. Roling")
                },
                new Book{Name="Poetry",
                    Desc="Poetry",
                    Img="http://umka.com/images/product/8711_l.jpg",
                Pages=579,
                Genre = genre.FirstOrDefault(g=>g.Name == "Liric"),
                Year = 2019,
                Author = author.FirstOrDefault(a=>a.Name == "L. Kostenko")
                }
            };

            context.Genres.AddRange(genre);
            context.Authors.AddRange(author);
            context.Books.AddRange(books);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}