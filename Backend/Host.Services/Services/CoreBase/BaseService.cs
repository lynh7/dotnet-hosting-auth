using Host.DB.Entities.Base;
using Host.DB.Repositories.Interfaces.Base;
using System.Linq.Expressions;

namespace Host.Services.Services.CoreBase
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _repository;

        /// <summary>
        /// Repository of current TEntity
        /// </summary>
        protected IBaseRepository<TEntity> RepoCur { get { return this._repository; } }

        protected BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await RepoCur.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await RepoCur.GetByIdAsync(id);
        }

        public async Task<TEntity> GetByIdAsync(Guid id, params Expression<Func<TEntity, object>>[]? includes)
        {
            return await RepoCur.GetByIdAsync(id, includes);
        }

        public async Task<TEntity> GetByWhereClauseAsync(Expression<Func<TEntity, bool>> whereClause, params Expression<Func<TEntity, object>>[]? includes)
        {
            return await RepoCur.GetByWhereClauseAsync(whereClause, includes);
        }

        public async Task<IList<TEntity>> GetByIdAsync(IList<Guid> ids)
        {
            return await RepoCur.GetByIdsAsync(ids);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await RepoCur.IsExistedAsync(id);
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            if (entity.Id != Guid.Empty) return await RepoCur.InsertAsync(entity);

            //var tGetNewId = RepoCur.GetNewId();
            //if (tGetNewId.IsFaulted) return await Task.FromException<TEntity>(tGetNewId.Exception);

            //entity.Id = tGetNewId.Result;

            return await RepoCur.InsertAsync(entity);
        }

        public async Task<IList<TEntity>> InsertAsync(IList<TEntity> entities)
        {
            return await RepoCur.InsertRangeAsync(entities);
        }

        public async Task<TEntity> DeleteAsync(Guid id)
        {
            var entity = await RepoCur.GetByIdAsync(id);

            return await RepoCur.DeleteAsync(entity);
        }

        public async Task<IList<TEntity>> DeleteAsync(IList<Guid> ids)
        {
            var entities = await RepoCur.GetByIdsAsync(ids);

            return await RepoCur.DeleteRangeAsync(entities);
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            return await RepoCur.DeleteAsync(entity);
        }

        public async Task<IList<TEntity>> DeleteAsync(IList<TEntity> entities)
        {
            return await RepoCur.DeleteRangeAsync(entities);
        }


        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await RepoCur.UpdateAsync(entity);
        }

        public async Task<IList<TEntity>> UpdateAsync(IList<TEntity> entities)
        {
            return await RepoCur.UpdateRangeAsync(entities);
        }

        public async Task<IList<TEntity>> InsertOrReplaceAllAsync(IList<TEntity> entities)
        {
            return await RepoCur.InsertOrReplaceAllAsync(entities);
        }

        public async Task<IList<TEntity>> GetAllIncludesAsync(Expression<Func<TEntity, bool>>? whereClause, params Expression<Func<TEntity, object>>[] includes)
        {
            return await RepoCur.GetAllAsync(whereClause, include: includes);
        }

        public async virtual Task<bool> Active(Guid id, bool isActive)
        {
            return await RepoCur.Active(id, isActive);
        }

        public async Task<bool> Active(TEntity entity, bool isActive)
        {
            return await RepoCur.Active(entity, isActive);
        }

        public async Task<IList<TEntity>> GetAllByWhereClauseAsync(Expression<Func<TEntity, bool>> whereClause, params Expression<Func<TEntity, object>>[]? includes)
        {
            return await RepoCur.GetAllByWhereClauseAsync(whereClause, includes);
        }
    }
}
