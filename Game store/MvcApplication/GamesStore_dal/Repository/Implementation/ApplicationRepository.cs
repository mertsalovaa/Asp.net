using GamesStore_dal.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore_dal.Repository.Implementation
{
    public class ApplicationRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext context;
        private readonly DbSet<TEntity> set;
        // 1) Dependecy Injection via ctor
        public ApplicationRepository(DbContext _context)
        {
            context = _context;
            set = context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            set.Add(entity);
            Save();
        }

        public void Delete(TEntity entity)
        {
            set.Remove(entity);
            Save();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return set.AsEnumerable();
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            return includes.Aggregate(set.AsQueryable(), (current, include) => current.Include(include)).AsEnumerable();
        }

        public TEntity GetById(int id)
        {
            return set.Find(id);
        }

        public void Update(TEntity entity)
        {
            //context.Entry(entity).State = EntityState.Modified;
            set.AddOrUpdate(entity);
            Save();
        }

        private void Save()
        {
            context.SaveChanges();
        }
    }
}
