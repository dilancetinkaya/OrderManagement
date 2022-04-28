using Microsoft.EntityFrameworkCore;
using OrderManagement.Core.Interfaces;
using OrderManagement.Infrastructure.Context;
using System.Linq.Expressions;

namespace OrderManagement.Infrastructure.Repositories;
public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly OrderDbContext _context;
    private DbSet<TEntity> _entity;
    public Repository(OrderDbContext context)
    {
        _context = context;
        _entity = _context.Set<TEntity>();
    }

    public async Task Add(TEntity entity)
    {
        await _entity.AddAsync(entity);
    }

    public void Delete(TEntity entity)
    {

        _entity.Remove(entity);
    }

    public async Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter)
    {
        return await _entity.Where(filter).ToListAsync();
    }

    public async Task<List<TEntity>> GetAll()
    {
        return await _entity.ToListAsync();
    }

    public async Task<int> TotalCount()
    {
        return await _entity.CountAsync();
    }

    public void Update(TEntity entity)
    {
        _entity.Update(entity);

    }
}

