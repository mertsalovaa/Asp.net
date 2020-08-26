using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore_dal.Repository.Abstraction
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Create(TEntity enitity);
        void Update(TEntity enitity);
        void Delete(TEntity enitity);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);
        TEntity GetById(int id);
    }
}
