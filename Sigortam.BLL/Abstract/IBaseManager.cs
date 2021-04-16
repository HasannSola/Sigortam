using Sigortam.Core.Model;
using Sigortam.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sigortam.BLL.Abstract
{
    public interface IBaseManager<TEntity> where TEntity
         : class, IEntity, new()
    {
        #region GetAll
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null);
        List<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
        List<TEntity> GetAllIncluding(params object[] includeProperties);
        Task<List<TEntity>> GetAllIncludingAsync(params Expression<Func<TEntity, object>>[] includeProperties);
        #endregion

        CResult<TEntity> Add(TEntity entity);
        Task<CResult<TEntity>> AddAsync(TEntity entity);

        CResult<string> Delete(object entityId);

        CResult<string> HardDelete(object entityId);

        TEntity Get(Expression<Func<TEntity, bool>> expression);

        CResult<TEntity> Update(TEntity entity);

        Task<CResult<TEntity>> UpdateAsync(TEntity entity);
        CResult<TEntity> BulkInsert(List<TEntity> obj);
    }
}
