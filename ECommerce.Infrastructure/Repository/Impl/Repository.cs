using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repository.Impl
{
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> _entities;
        protected readonly ILogger _logger;

        public Repository(DbContext context, ILogger logger)
        {
            Context = context;
            _entities = Context.Set<TEntity>();
            _logger = logger;
        }
        public async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return await _entities.FindAsync(id);
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entities.Where(predicate).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<PagedEntities<TEntity>> GetByPage(Expression<Func<TEntity, bool>> predicate,
                                                          int page, int itemsPerPage,
                                                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            int skip = itemsPerPage * (page - 1);
            var dbset = orderBy(_entities.Where(predicate));
            return new PagedEntities<TEntity>
            {
                Count = dbset.Count(),
                Entities = await dbset.Skip(skip).Take(itemsPerPage).ToListAsync()
            };
        }

        public async Task<PagedEntities<TEntity>> GetByPage(List<TEntity> entities,
                                                          int page, int itemsPerPage,
                                                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            int skip = itemsPerPage * (page - 1);
            var dbset = orderBy(entities.AsQueryable());
            entities = dbset.Skip(skip).Take(itemsPerPage).ToList();

            return new PagedEntities<TEntity>
            {
                Count = dbset.Count(),
                Entities = entities
            };
        }
        public async Task<PagedEntities<TEntity>> SearchByPage(Expression<Func<TEntity, bool>> predicate,
                                                  int page, int itemsPerPage,
                                                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
                                                  params Expression<Func<TEntity, object>>[] includes)
        {
            int skip = itemsPerPage * (page - 1);
            var dbset = orderBy(_entities.Where(predicate));
            var entities = await dbset.Skip(skip).Take(itemsPerPage).ToListAsync();
            if (includes != null)
            {
                entities = await includes.Aggregate(entities.AsQueryable(),
                          (current, include) => current.Include(include)).ToListAsync();
            }
            //entities = await includes.Aggregate(entities.AsQueryable(), (query, path) => query.Include(path)).ToListAsync();
            return new PagedEntities<TEntity>
            {
                Count = dbset.Count(),
                Entities = entities
            };
        }

        public async Task<PagedEntities<TEntity>> SearchByPage(List<TEntity> entities,
                                                  int page, int itemsPerPage,
                                                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            int skip = itemsPerPage * (page - 1);
            var dbset = orderBy(entities.AsQueryable());
            entities = dbset.Skip(skip).Take(itemsPerPage).ToList();

            //entities = await includes.Aggregate(entities.AsQueryable(), (query, path) => query.Include(path)).ToListAsync();
            return new PagedEntities<TEntity>
            {
                Count = dbset.Count(),
                Entities = entities
            };
        }
        public async Task<PagedEntities<TEntity>> SearchByPage(Expression<Func<TEntity, bool>> predicate,
                                                  int page, int itemsPerPage,
                                                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            int skip = itemsPerPage * (page - 1);
            var dbset = orderBy(_entities.Where(predicate));
            return new PagedEntities<TEntity>
            {
                Count = dbset.Count(),
                Entities = await dbset.Skip(skip).Take(itemsPerPage).ToListAsync()
            };
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            return await _entities.Where(predicate).ToListAsync();
        }
        public async Task<bool> IfExist(TEntity entity)
        {
            return await _entities.ContainsAsync(entity);
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            try
            {
                var obj = await _entities.AddAsync(entity);
                return obj.Entity;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public TEntity Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Detached;
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public async Task<int> Count()
        {
            return await _entities.CountAsync();
        }
        public async Task<int> Count(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entities.CountAsync(predicate);
        }
        public async Task<bool> RemoveHardAsync(TPrimaryKey id)
        {
            var entity = await _entities.FindAsync(id);
            if (entity != null)
            {
                _entities.Remove(entity);
                return true;
            }

            return false;
        }        
    }
}
