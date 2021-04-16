using Microsoft.EntityFrameworkCore;
using Sigortam.Core.Model;
using Sigortam.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sigortam.DAl.Concrete
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {

        #region GetAll
        public virtual List<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            try
            {
                using (var context = new TContext())
                {
                    IQueryable<TEntity> query = context.Set<TEntity>();
                    foreach (var includeProperty in includeProperties)
                    {
                        query = query.Include(includeProperty);
                    }
                    return query.ToList();
                    // return query.AsNoTracking();//, AsNoTracking kullanırsak yaptığımız select üzerinde herhangi bir update işlemi uygulayamıyoruz.
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Repository.GetAllIncluding ; Repository", ex);
            }
        }
        public virtual List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                using (var context = new TContext())
                {
                    return filter == null ?
                        context.Set<TEntity>().ToList() :
                        context.Set<TEntity>().Where(filter).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Repository.GetAll ; Repository", ex);
            }
        }
        public virtual async Task<List<TEntity>> GetAllIncludingAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            try
            {
                using (var context = new TContext())
                {
                    IQueryable<TEntity> query = context.Set<TEntity>();
                    foreach (var includeProperty in includeProperties)
                    {
                        query = query.Include(includeProperty);
                    }
                    // return await query.AsNoTracking().ToListAsync();
                    return await query.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Repository.GetAllIncludingAsync ; Repository", ex);
            }
        }
        public virtual List<TEntity> GetAllIncluding(params object[] includeProperties)
        {
            try
            {
                using (var context = new TContext())
                {
                    IQueryable<TEntity> query = context.Set<TEntity>();
                    foreach (var includeProperty in includeProperties)
                    {
                        query = query.Include(includeProperty.ToString());
                    }
                    // return query.AsNoTracking();
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Repository.GetAllIncluding ; Repository", ex);
            }
        }
        #endregion
        public virtual CResult<TEntity> Add(TEntity entity)
        {
            try
            {
                using (var context = new TContext())
                {
                    var addEntity = context.Entry<TEntity>(entity);
                    addEntity.State = EntityState.Added;
                    context.SaveChanges();
                }

                return new CResult<TEntity>() { Object = entity, Succeeded = true, Desc = "Kayıt işlemi başarılı." };
            }
            catch (Exception ex)
            {
                return new CResult<TEntity>() { Succeeded = false, Desc = ex.Message.ToString(), ex = ex };
            }

        }
        public virtual async Task<CResult<TEntity>> AddAsync(TEntity entity)
        {
            try
            {
                using (var context = new TContext())
                {
                    // context.Set<TEntity>().Add(entity);
                    var addEntity = context.Entry(entity);
                    addEntity.State = EntityState.Added;
                    await context.SaveChangesAsync();
                }
                return new CResult<TEntity>() { Object = entity, Succeeded = true, Desc = "Kayıt işlemi başarılı." };
            }
            catch (Exception ex)
            {
                return new CResult<TEntity>() { Succeeded = false, Desc = ex.Message.ToString(), ex = ex };
            }
        }

        public virtual CResult<TEntity> Update(TEntity entity)
        {
            try
            {
                using (var context = new TContext())
                {
                    var updateEntity = context.Entry<TEntity>(entity);
                    updateEntity.State = EntityState.Modified;
                    context.SaveChanges();
                }
                return new CResult<TEntity>() { Object = entity, Succeeded = true, Desc = "Güncelleme işlemi başarılı." };
            }
            catch (Exception ex)
            {
                return new CResult<TEntity>() { Object = entity, Succeeded = false, Desc = ex.Message.ToString(), ex = ex };
            }
        }
        public virtual async Task<CResult<TEntity>> UpdateAsync(TEntity entity)
        {
            try
            {
                using (var context = new TContext())
                {
                    var updateEntity = context.Entry(entity);
                    updateEntity.State = EntityState.Modified;
                    await context.SaveChangesAsync();
                }
                return new CResult<TEntity>() { Object = entity, Succeeded = true, Desc = "Güncelleme işlemi başarılı." };
            }
            catch (Exception ex)
            {
                return new CResult<TEntity>() { Object = entity, Succeeded = false, Desc = ex.Message.ToString(), ex = ex };
            }

        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                using (var context = new TContext())
                {
                    return context.Set<TEntity>().FirstOrDefault(filter);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Repository.GetAll ; Repository", ex);
            }
        }
        public virtual TEntity GetIncluding(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            try
            {
                using (var context=new TContext())
                {
                    IQueryable<TEntity> query = context.Set<TEntity>();
                    foreach (var includeProperty in includeProperties)
                    {
                        query = query.Include(includeProperty);
                    }
                    // return query.AsNoTracking().FirstOrDefault(expression);//Bu kullanıldığında buradaki buradaki instance update edilmez
                    return query.FirstOrDefault(expression);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Repository.GetIncluding ; Repository", ex);
            }
        }

        public virtual CResult<string> Delete(object id)
        {
            try
            {
                using (var context = new TContext())
                {
                    var entity = context.Set<TEntity>().Find(id);
                    var addEntity = context.Entry<TEntity>(entity);
                    addEntity.State = EntityState.Deleted;
                    context.SaveChanges();

                }
                return new CResult<string>() { Succeeded = true, Desc = "Silme işlemi başarılı." };
            }
            catch (Exception ex)
            {
                return new CResult<string>() { Succeeded = false, Desc = ex.Message.ToString() };
            }

        }
        public virtual CResult<TEntity> BulkInsert(List<TEntity> entities)
        {
            try
            {
                using (var context=new TContext())
                {
                    context.Set<TEntity>().AddRange(entities);
                    context.SaveChanges();
                }
                return new CResult<TEntity>() { Object = null, Succeeded = true, Desc = "Kayıt işlemi başarılı." };
            }
            catch (Exception ex)
            {
                throw new Exception("Repository.BulkInsert ; Repository", ex);
            }
        }
    }
}
