using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteBack.Model.Model;

namespace TesteBack.Repository.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
         where TEntity : class, IEntity
    {
        #region property
        private readonly TesteContext _dbContext; 
        #endregion

        #region constructor
        public GenericRepository(TesteContext dbContext)
        {
            _dbContext = dbContext;
        } 
        #endregion

        #region method
        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetById(int? id)
        {
            return await _dbContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(int? id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        } 
        #endregion
    }
}
