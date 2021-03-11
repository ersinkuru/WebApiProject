using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.DataAccess.EntityFramework
{
    public class EfEntityRepository<TEntity, TContext> : IEntityRepository<TEntity> where TEntity:class,IEntity,new() where TContext:DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context=new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

 
        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Update(entity);
                deletedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                
                   return filter==null ? context.Set<TEntity>().ToList():
                       context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Update(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
