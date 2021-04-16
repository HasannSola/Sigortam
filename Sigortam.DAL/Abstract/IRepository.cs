using Microsoft.EntityFrameworkCore;
using Sigortam.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sigortam.DAL.Abstract
{
    public interface IRepository<TEntity>
        where TEntity : class,IEntity ,new ()
    {
        #region GetAll
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter);

        List<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);

        List<TEntity> GetAllIncluding(params object[] includeProperties);
  
        Task<List<TEntity>> GetAllIncludingAsync(params Expression<Func<TEntity, object>>[] includeProperties);

        #endregion
        TEntity GetIncluding(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity Get(Expression<Func<TEntity, bool>> filter);
 
        CResult<TEntity> Add(TEntity entity);

        CResult<TEntity> BulkInsert(List<TEntity> entities);
       
        Task<CResult<TEntity>> AddAsync(TEntity entity);
   
        CResult<TEntity> Update(TEntity entity);

        Task<CResult<TEntity>> UpdateAsync(TEntity entity);

        CResult<string> Delete(object id);
    }
}
