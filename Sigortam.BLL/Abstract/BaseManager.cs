using Sigortam.Core.Model;
using Sigortam.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sigortam.BLL.Abstract
{
    public abstract class BaseManager<TEntity> : IBaseManager<TEntity>
        where TEntity : class, IEntity, new()
    {
        private IRepository<TEntity> _genericDal;

        public BaseManager(IRepository<TEntity> InitContext)
        {
            _genericDal = InitContext;
        }

        protected BaseManager()
        {
        }

        public virtual CResult<TEntity> Add(TEntity entity)
        {
            return _genericDal.Add(entity);
        }

        public virtual async Task<CResult<TEntity>> AddAsync(TEntity entity)
        {
            return await _genericDal.AddAsync(entity);
        }

        public CResult<TEntity> BulkInsert(List<TEntity> obj)
        {
            return _genericDal.BulkInsert(obj);
        }

        public virtual CResult<string> Delete(object entityId)
        {
            return _genericDal.Delete(entityId);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return _genericDal.Get(expression);
        }

        public virtual List<TEntity> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            return _genericDal.GetAll(expression);
        }

        public virtual List<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _genericDal.GetAllIncluding(includeProperties);
        }

        public virtual List<TEntity> GetAllIncluding(params object[] includeProperties)
        {
            return _genericDal.GetAllIncluding(includeProperties);
        }

        public virtual async Task<List<TEntity>> GetAllIncludingAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await _genericDal.GetAllIncludingAsync(includeProperties);
        }

        public TEntity GetIncluding(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _genericDal.GetIncluding(expression, includeProperties);
        }

        public CResult<string> HardDelete(object entityId)
        {
            return _genericDal.Delete(entityId);
        }

        public virtual CResult<TEntity> Update(TEntity entity)
        {
            return _genericDal.Update(entity);
        }

        public virtual async Task<CResult<TEntity>> UpdateAsync(TEntity entity)
        {
            return await _genericDal.UpdateAsync(entity);
        }

    }
}
