using Host.DB.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Host.DB.Repositories.Interfaces.Base
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T? GetById(Guid id, params Expression<Func<T, object>>[]? includes);

        Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[]? includes);

        Task<IList<T>> GetByIdsAsync(IList<Guid> ids, params Expression<Func<T, object>>[]? includes);

        Task<T> GetByWhereClauseAsync(Expression<Func<T, bool>> whereClause = null, params Expression<Func<T, object>>[]? includes);

        Task<IList<T>> GetAllByWhereClauseAsync(Expression<Func<T, bool>> whereClause, params Expression<Func<T, object>>[]? includes);

        bool IsExisted(Guid id);

        Task<bool> IsExistedAsync(Guid id);

        Task<int> GetTotalRecords(Expression<Func<T, bool>>? expression = null);

        T Insert(T entity, bool autoSave = true);

        Task<T> InsertAsync(T entity, bool autoSave = true);

        Task<IList<T>> InsertRangeAsync(IList<T> entities, bool autoSave = true);

        Task<T> UpdateAsync(T entity, bool autoSave = true);

        Task<IList<T>> UpdateRangeAsync(IList<T> entities, bool autoSave = true);

        Task<T> DeleteAsync(T entity, bool autoSave = true);

        Task<IList<T>> DeleteRangeAsync(IList<T> entities, bool autoSave = true);

        Task<bool> StrongDeleteRangeAsync(IList<T> entities, bool autoSave = true);

        Task<bool> StrongDeleteAsync(T entity, bool autoSave = true);

        Task<IList<T>> DeleteRangeAsync(IList<Guid> entities, bool autoSave = true);

        IList<T> GetAll(Expression<Func<T, bool>>? expression = null,
            int skip = 0,
            int? take = null, params Expression<Func<T, object>>[] include);

        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null,
                int skip = 0,
                int? take = null, params Expression<Func<T, object>>[] include);

        int SaveChanges();

        IQueryable<T> GetQueryAbleIncludeDelete(Expression<Func<T, bool>>? expression = null, params Expression<Func<T, object>>[] includes);

        IQueryable<T> GetQueryable(Expression<Func<T, bool>>? expression = null, params Expression<Func<T, object>>[] includes);

        Task<int> SaveChangesAsync();

        Task<IEnumerable<T>> DeleteRangeAsync(IEnumerable<T> entity, bool autoSave = true);

        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>>? expression = null, params Expression<Func<T, object>>[]? includes);
        //Task<Guid> GetNewId();

        Task<IList<T>> InsertOrReplaceAllAsync(IList<T> entities);
        Task<bool> Active(T entity, bool isActive);
        Task<bool> Active(Guid id, bool isActive);

        //Task<PaginationResponseEntityModel<T>> GetPagedDataAsync(int pageIndex, int pageSize, Expression<Func<T, bool>> whereClause = null, params Expression<Func<T, object>>[] includes);
        //Task<PaginationResponseEntityModel<T>> GetPagedDataAsync(int pageIndex, int pageSize, Expression<Func<T, bool>> whereClause = null);

        Task<int> GetTotalRecords();
    }
}
