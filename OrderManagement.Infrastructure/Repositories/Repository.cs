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

    public async Task<bool> AddAsync(TEntity entity)
    {
        await _entity.AddAsync(entity);
        var result = _context.SaveChanges();
        return result > 0;
    }

    public bool Delete(TEntity entity)
    {
        _entity.Remove(entity);
        var result = _context.SaveChanges();
        return result > 0;

    }

    public async Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _entity.Where(filter).ToListAsync();
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _entity.ToListAsync();
    }


    public bool Update(TEntity entity)
    {
        _entity.Update(entity);
        var result = _context.SaveChanges();
        return result > 0;

    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _entity.Where(filter).FirstOrDefaultAsync();
    }
}

