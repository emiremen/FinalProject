using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, Tcontext> : IEntityRepository<TEntity>
        where TEntity: class, IEntity, new() 
        where Tcontext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            // IDisposable pattern implementation of c#
            using (Tcontext northwindContext = new Tcontext())
            {
                var addedEntity = northwindContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                northwindContext.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (Tcontext northwindContext = new Tcontext())
            {
                var deletedEntity = northwindContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                northwindContext.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (Tcontext northwindContext = new Tcontext())
            {
                return northwindContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (Tcontext northwindContext = new Tcontext())
            {
                return filter == null ? northwindContext.Set<TEntity>().ToList() : northwindContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public List<TEntity> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            using (Tcontext northwindContext = new Tcontext())
            {
                var updatedEntity = northwindContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                northwindContext.SaveChanges();
            }
        }
    }
}
