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
    public class DeveloperService : IDeveloperService
    {
        private readonly IGenericRepository<Developer> repo;

        public DeveloperService(IGenericRepository<Developer> _repo)
        {
            repo = _repo;
        }

        public void AddDeveloper(Developer developer)
        {
            repo.Create(developer);
        }

        public void DeleteDeveloper(int id)
        {
            repo.Delete(repo.GetById(id));
        }

        public ICollection<Developer> GetAllDevelopers()
        {
            return repo.GetAll().ToList();
        }

        public void UpdateDeveloper(Developer developer)
        {
            repo.Update(developer);
        }
    }
}
