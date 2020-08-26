using Binbin.Linq;
using GameesStore_client.Filter;
using GamesStore_bll.Services.Abstraction;
using GamesStore_dal.Entities;
using GamesStore_dal.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore_bll.Services.Implementation
{
    public class GameService : IGameService
    {
        private readonly IGenericRepository<Game> repo;
        private readonly IGenericRepository<Developer> repoDev;
        private readonly IGenericRepository<Genre> repoGenre;

        // Dependency Injection #2
        public GameService(IGenericRepository<Game> _repo, IGenericRepository<Developer> _repoDev, IGenericRepository<Genre> _repoGenre)
        {
            repo = _repo;
            repoDev = _repoDev;
            repoGenre = _repoGenre;
        }

        public void AddGame(Game game)
        {
            var developer = repoDev.GetAll().FirstOrDefault(x => x.Company == game.Developer.Company);
            var genre = repoGenre.GetAll().FirstOrDefault(x => x.Name == game.Genre.Name);

            game.Genre = genre;
            game.Developer = developer;
            repo.Create(game);
        }

        public void Delete(int id)
        {
            repo.Delete(repo.GetById(id));
        }

        public ICollection<Game> FilterGames(List<GameFilter> filters)
        {
            var predicate = PredicateBuilder.Create(filters[0].Predicate);
            for (int i = 1; i < filters.Count; i++)
            {
                predicate = predicate.Or(filters[i].Predicate);
            }
            return repo.GetAll().Where(predicate.Compile()).ToList();
        }

        public ICollection<string> GetAllDevelopers()
        {
            return repoDev.GetAll().Select(x => x.Company).ToList();
        }

        public ICollection<Game> GetAllGames()
        {
            return repo.GetAll().ToList();
        }

        public ICollection<string> GetAllGenres()
        {
            return repoGenre.GetAll().Select(x => x.Name).ToList();

        }

        public void UpdateGame(Game model)
        {
            var game = repo.GetById(model.Id);

            var developer = repoDev.GetAll().FirstOrDefault(x => x.Company == model.Developer.Company);
            var genre = repoGenre.GetAll().FirstOrDefault(x => x.Name == model.Genre.Name);

            game = model;
            game.Developer = developer;
            game.Genre = genre;

            repo.Update(game);
        }
    }
}
