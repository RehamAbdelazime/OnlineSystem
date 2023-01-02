using ECommerce.Domain.Entities;
using System.Linq.Expressions;

namespace ECommerce.Infrastructure.Repository.Interfaces
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        Task<TEntity> GetAsync(TPrimaryKey id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<PagedEntities<TEntity>> GetByPage(Expression<Func<TEntity, bool>> predicate, int page, int itemsPerPage, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);
        Task<PagedEntities<TEntity>> GetByPage(List<TEntity> entities,
                                                          int page, int itemsPerPage,
                                                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);
        Task<PagedEntities<TEntity>> SearchByPage(Expression<Func<TEntity, bool>> predicate, int page, int itemsPerPage, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> CreateAsync(TEntity entity);
        TEntity Update(TEntity entity);
        Task<bool> IfExist(TEntity entity);
        //Task<bool> RemoveAsync(TPrimaryKey id, string updatedBy);
        Task<bool> RemoveHardAsync(TPrimaryKey id);
        Task<PagedEntities<TEntity>> SearchByPage(List<TEntity> entities,
                                                  int page, int itemsPerPage,
                                                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> Count();
        Task<int> Count(Expression<Func<TEntity, bool>> predicate);
    }
}
