using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PsychologyPatientSystem.Core.Entities;

namespace PsychologyPatientSystem.Core.DataAccess.EntityFramework
{
    public class EfEntityRepository<TEntity, TContext> : IEntityRepository<TEntity>, IAsyncEntityRepository<TEntity> where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
    {
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ?
                    context.Set<TEntity>().ToList() :
                    context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedState = context.Entry(entity);
                addedState.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedState = context.Entry(entity);
                updatedState.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedState = context.Entry(entity);
                deletedState.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            var context = new TContext();
            return filter == null
                ? await context.Set<TEntity>().ToListAsync()
                : await context.Set<TEntity>().Where(filter).ToListAsync();

        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            var context = new TContext();
            return await context.Set<TEntity>().SingleOrDefaultAsync(filter);

        }

        public async Task AddAsync(TEntity entity)
        {
            var context = new TContext();

            var addedStateAsync = context.Entry(entity);
            addedStateAsync.State = EntityState.Added;
            await context.SaveChangesAsync();

        }

        public async Task UpdateAsync(TEntity entity)
        {
            var context = new TContext();
            var updatedStateAsync = context.Entry(entity);
            updatedStateAsync.State = EntityState.Modified;
            await context.SaveChangesAsync();

        }

        public async Task DeleteAsync(TEntity entity)
        {
            var context = new TContext();
            var deletedStateAsync = context.Entry(entity);
            deletedStateAsync.State = EntityState.Deleted;
            await context.SaveChangesAsync();

        }
    }
}
