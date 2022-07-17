using Core.Abstract.EntityFramework;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext> 
        where TEntity : class, IEntity,new()
        where TContext : DbContext, new()
    {
        
        public void Add(TEntity entity)
        {
            using (TContext reCapProjectContext = new TContext())
            {
                var addedEntity = reCapProjectContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                reCapProjectContext.SaveChanges();
            }
        }
        public void Update(TEntity entity)
        {
            using (TContext reCapProjectContext = new TContext())
            {
                var updatedEntity = reCapProjectContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                reCapProjectContext.SaveChanges();
            }
        }



        public void Delete(TEntity entity)
        {
            using (TContext reCapProjectContext = new TContext())
            {
                var deletedEntity = reCapProjectContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                reCapProjectContext.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter=null)
        {
            using (TContext reCapProjectContext = new TContext())
            {
                return filter == null 
                    ? reCapProjectContext.Set<TEntity>().ToList() 
                    : reCapProjectContext.Set<TEntity>().Where(filter).ToList();

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext reCapProjectContext = new TContext())
            {
                return reCapProjectContext.Set<TEntity>().SingleOrDefault(filter);

            }
        }


    }
}
