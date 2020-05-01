using Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Core.DataAccess.Concrete.EntityFramework
{

    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, new()
    where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var dbContextTransaction = context.Database.BeginTransaction();
                try
                {
                    context.Set<TEntity>().Add(entity);
                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    dbContextTransaction.Dispose();
                }
                catch
                {
                    dbContextTransaction.Rollback();
                    throw;
                }
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var dbContextTransaction = context.Database.BeginTransaction();
                try
                {
                    context.Set<TEntity>();
                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    dbContextTransaction.Dispose();
                }
                catch
                {
                    dbContextTransaction.Rollback();
                    throw;
                }
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Where(filter).FirstOrDefault();
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var dbContextTransaction = context.Database.BeginTransaction();
                try
                {
                    context.Set<TEntity>();
                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    dbContextTransaction.Dispose();
                }
                catch
                {
                    dbContextTransaction.Rollback();
                    throw;
                }
            }
        }
    }
}
