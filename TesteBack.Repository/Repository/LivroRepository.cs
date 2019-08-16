using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteBack.Model.Criteria;
using TesteBack.Model.Model;

namespace TesteBack.Repository.Repository
{
    public class LivroRepository : GenericRepository<Livro>, ILivroRepository
    {
        #region property
        public LivroRepository(TesteContext dbContext) : base(dbContext) { } 
        #endregion

        #region method
        public async Task<List<Livro>> GetByCriteria(LivroCriteria criteria)
        {
            return await GetAll().Where(u => (!string.IsNullOrEmpty(u.Titulo) && u.Titulo.StartsWith(criteria.Titulo)
             || !string.IsNullOrEmpty(u.Autor) && u.Autor.StartsWith(criteria.Autor))).ToListAsync();
        } 
        #endregion
    }
}
