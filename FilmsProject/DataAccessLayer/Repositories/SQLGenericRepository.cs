using FilmsProject.DataAccessLayer.Context;
using FilmsProject.DataAccessLayer.Interfaces.Entities;
using FilmsProject.DataAccessLayer.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsProject.DataAccessLayer.Repositories
{
    public abstract class SQLGenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : class, IEntity<TId>
    {
        protected FilmsProjectDbContext _myDBContext;
        protected DbSet<TEntity> _dbSet;

        public SQLGenericRepository(FilmsProjectDbContext myDBContext)
        {
            _myDBContext = myDBContext;
            _dbSet = _myDBContext.Set<TEntity>();
        }

        public async Task<TId> AddAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await _myDBContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _myDBContext.Entry(entity).State = EntityState.Modified;
            await _myDBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TId id)
        {
            TEntity entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
            await _myDBContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetAsync(TId id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }

}
