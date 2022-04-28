using System.Linq.Expressions;

namespace OrderManagement.Core.Interfaces;

public interface IRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter);
     

    }


