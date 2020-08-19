using GamesStore_dal.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore_dal.Initializer
{
    public class GamesInitilizer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var genre = new List<Genre>
           {
               new Genre{Name="Action"},
               new Genre{Name="Shooter"},
               new Genre{Name="SportSimulator"},
               new Genre{Name="RPG"},
               new Genre{Name="Strategy"}
           };

            var developer = new List<Developer> {
                new Developer {Company="RockStar"},
                new Developer {Company="UbiSoft"},
                new Developer {Company="Fa"},
                new Developer {Company="Playrix"},
                new Developer {Company="Ghost Games"},
                new Developer {Company="Activision"}
                };

            var games = new List<Game>
            {
                new Game{
                Name="GTA 5",
                Price=500,
                Year=2018,
                Developer = developer.FirstOrDefault(x=>x.Company == "RockStar"),
                Genre = genre.FirstOrDefault(x=>x.Name == "RPG")},

                new Game{
                Name="Metro",
                Price=800,
                Year=2019,
                Developer = developer.FirstOrDefault(x=>x.Company == "Activision"),
                Genre = genre.FirstOrDefault(x=>x.Name == "Shooter")},

                new Game{
                Name="FarCry",
                Price=600,
                Year=2017,
                Developer = developer.FirstOrDefault(x=>x.Company == "UbiSoft"),
                Genre = genre.FirstOrDefault(x=>x.Name == "Action")},

                new Game{
                Name="FIFA",
                Price=850,
                Year=2020,
                Developer = developer.FirstOrDefault(x=>x.Company == "Ghost Games"),
                Genre = genre.FirstOrDefault(x=>x.Name == "SportSimulator")}
            };

            context.Developers.AddRange(developer);
            context.Genres.AddRange(genre);
            context.Games.AddRange(games);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
