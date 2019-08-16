using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBack.Repository.Repository
{
    public interface IGenericRepository<TEntity>  where TEntity : class
    {
        #region method
        IQueryable<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetById(int? id);
        Task Create(TEntity entity);
        Task Update(int? id, TEntity entity);
        Task Delete(int? id); 
        #endregion
    }
}
