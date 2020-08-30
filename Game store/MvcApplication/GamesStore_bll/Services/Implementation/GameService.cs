using Binbin.Linq;
using GameesStore_client.Filter;
using GamesStore_bll.Services.Abstraction;
using GamesStore_dal.Entities;
using GamesStore_dal.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            if (filters != null && filters.Count > 0)
            {
                var predicates = new List<Expression<Func<Game, bool>>> ();
                var types = filters.GroupBy(x => x.Type);
                foreach (var item in types)
                {

                    var predicate = PredicateBuilder.Create(item.First().Predicate);
                    for (int i = 1; i < item.Count(); i++)
                    {
                        predicate = predicate.Or(item.ToArray()[i].Predicate);
                    }
                    predicates.Add(predicate);
                }
                var resultPredicate = PredicateBuilder.Create(predicates[0]);
                for (int i = 0; i < predicates.Count; i++)
                {
                    resultPredicate = resultPredicate.And(predicates[i]);
                }
                return repo.GetAll().Where(resultPredicate.Compile()).ToList();
            }
            return repo.GetAll().ToList();
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

        public ICollection<Game> Search(string searchName)
        {
            return repo.GetAll().Where(x => x.Name.Contains(searchName)).ToList();
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
