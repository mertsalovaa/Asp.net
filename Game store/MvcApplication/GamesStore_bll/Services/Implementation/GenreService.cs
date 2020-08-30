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
    public class GenreService : IGenreService
    {
        private readonly IGenericRepository<Genre> repo;

        public GenreService(IGenericRepository<Genre> _repo)
        {
            repo = _repo;
        }

        public void AddGenre(Genre genre)
        {
            repo.Create(genre);
        }

        public void DeleteGenre(int id)
        {
            repo.Delete(repo.GetById(id));
        }

        public ICollection<Genre> GetAllGenres()
        {
            return repo.GetAll().ToList();
        }

        public void UpdateGenre(Genre genre)
        {
            repo.Update(genre);
        }
    }
}
