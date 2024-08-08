using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Host.Services.Services.CoreBase
{
    public interface IBaseService<TEntity>
    {
        Task<IList<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> GetByIdAsync(Guid id, params Expression<Func<TEntity, object>>[]? includes);
        Task<TEntity> GetByWhereClauseAsync(Expression<Func<TEntity, bool>> whereClause, params Expression<Func<TEntity, object>>[]? includes);
        Task<IList<TEntity>> GetAllByWhereClauseAsync(Expression<Func<TEntity, bool>> whereClause, params Expression<Func<TEntity, object>>[]? includes);
        Task<IList<TEntity>> GetByIdAsync(IList<Guid> ids);
        Task<bool> ExistsAsync(Guid id);
        Task<TEntity> InsertAsync(TEntity entity);
        Task<IList<TEntity>> InsertAsync(IList<TEntity> entities);
        Task<TEntity> DeleteAsync(Guid id);
        Task<IList<TEntity>> DeleteAsync(IList<Guid> ids);
        Task<TEntity> DeleteAsync(TEntity entity);
        Task<IList<TEntity>> DeleteAsync(IList<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<IList<TEntity>> UpdateAsync(IList<TEntity> entities);
        Task<IList<TEntity>> InsertOrReplaceAllAsync(IList<TEntity> entities);
        Task<IList<TEntity>> GetAllIncludesAsync(Expression<Func<TEntity, bool>> whereClause, params Expression<Func<TEntity, object>>[] includes);
        Task<bool> Active(TEntity entity, bool isActive);
        Task<bool> Active(Guid id, bool isActive);
    }
}
