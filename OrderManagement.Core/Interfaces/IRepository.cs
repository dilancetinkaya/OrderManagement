using System.Linq.Expressions;

namespace OrderManagement.Core.Interfaces;

public interface IRepository<TEntity> where TEntity : class
    {
        Task<bool> AddAsync(TEntity entity);
        bool Delete(TEntity entity);
        bool Update(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
     

    }


