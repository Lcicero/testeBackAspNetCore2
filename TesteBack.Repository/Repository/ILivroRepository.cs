using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteBack.Model.Criteria;
using TesteBack.Model.Model;

namespace TesteBack.Repository.Repository
{
    public interface ILivroRepository : IGenericRepository<Livro>
    {
        #region method
        Task<List<Livro>> GetByCriteria(LivroCriteria criteria); 
        #endregion
    }
}
