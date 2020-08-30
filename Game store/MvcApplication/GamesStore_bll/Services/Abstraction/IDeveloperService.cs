using GamesStore_dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore_bll.Services.Abstraction
{
    public interface IDeveloperService
    {
        ICollection<Developer> GetAllDevelopers();
        void AddDeveloper(Developer developer);
        void UpdateDeveloper(Developer developer);
        void DeleteDeveloper(int id);
    }
}
