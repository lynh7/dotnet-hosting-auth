using Host.DB.Entities.Base;
using Host.DB.Repositories.Interfaces.Base;
using Host.DB.UnitOfWorkPattern.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Host.DB.Repositories.Implementations.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly IUnitOfWork _unitOfWork;
        private readonly DbSet<T> _table;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _table = _unitOfWork.Repository<T>();
        }

        public DbSet<T> Table => _table;

        public T? GetById(Guid id, params Expression<Func<T, object>>[]? includes)
        {
            var query = from b in Table
                        where !b.IsDeleted && b.Id == id
                        select b;

            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return query.FirstOrDefault();
        }

        public async Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[]? includes)
        {
            var query = from b in Table
                        where !b.IsDeleted && id == b.Id
                        select b;

            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return await query.FirstOrDefaultAsync();

        }

        public async Task<T> GetByWhereClauseAsync(Expression<Func<T, bool>> whereClause, params Expression<Func<T, object>>[]? includes)
        {
            var query = from b in Table
                        where !b.IsDeleted
                        select b;

            query = query.Where(whereClause);


            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IList<T>> GetAllByWhereClauseAsync(Expression<Func<T, bool>> whereClause, params Expression<Func<T, object>>[]? includes)
        {
            var query = from b in Table
                        where !b.IsDeleted
                        select b;

            query = query.Where(whereClause);

            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<IList<T>> GetByIdsAsync(IList<Guid> ids, params Expression<Func<T, object>>[]? includes)
        {
            var query = from b in Table
                        where !b.IsDeleted && ids.Contains(b.Id)
                        select b;

            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return await query.ToListAsync();
        }

        public bool IsExisted(Guid id)
        {
            return GetById(id) != null;
        }

        public async Task<bool> IsExistedAsync(Guid id)
        {
            return (await GetByIdAsync(id)) != null;
        }

        public Task<int> GetTotalRecords(Expression<Func<T, bool>>? expression = null)
        {
            return Task.Run(() =>
            {
                var query = from b in Table
                            where !b.IsDeleted
                            select b;

                if (expression != null)
                {
                    query = query.Where(expression);
                }

                return query.Count();
            });
        }

        public T Insert(T entity, bool autoSave = true)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("can not insert null object");
            }

            entity.CreatedOn = DateTime.UtcNow;
            entity.ModifiedOn = DateTime.UtcNow;
            _unitOfWork.Repository<T>().Add(entity);
            if (autoSave)
            {
                _unitOfWork.SaveChanges();
            }
            return entity;
        }

        public async Task<T> InsertAsync(T entity, bool autoSave = true)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entity.CreatedOn = DateTime.UtcNow;
            entity.ModifiedOn = DateTime.UtcNow;
            _unitOfWork.Repository<T>().Add(entity);
            if (autoSave)
            {
                await _unitOfWork.SaveChangesAsync();
            }
            return entity;
        }

        public async Task<IList<T>> InsertRangeAsync(IList<T> entities, bool autoSave = true)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }

            foreach (var item in entities)
            {
                item.CreatedOn = DateTime.UtcNow;
                item.ModifiedOn = DateTime.UtcNow;
            }

            await _unitOfWork.Repository<T>().AddRangeAsync(entities);

            if (autoSave)
            {
                await _unitOfWork.SaveChangesAsync();
            }

            return entities;
        }

        public async Task<T> UpdateAsync(T entity, bool autoSave = true)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entity.ModifiedOn = DateTime.UtcNow;
            _unitOfWork.Repository<T>().Update(entity);
            if (autoSave)
            {
                await _unitOfWork.SaveChangesAsync();
            }
            return entity;
        }

        public async Task<IList<T>> UpdateRangeAsync(IList<T> entities, bool autoSave = true)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }

            foreach (var item in entities)
            {
                item.ModifiedOn = DateTime.UtcNow;
            }

            _unitOfWork.Repository<T>().UpdateRange(entities);

            if (autoSave)
            {
                await _unitOfWork.SaveChangesAsync();
            }

            return entities;
        }

        public async Task<T> DeleteAsync(T entity, bool autoSave = true)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entity.IsDeleted = true;
            await UpdateAsync(entity, autoSave);

            return entity;
        }

        public async Task<bool> StrongDeleteRangeAsync(IList<T> entities, bool autoSave = true)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }

            _unitOfWork.Repository<T>().RemoveRange(entities);

            if (autoSave)
            {
                await _unitOfWork.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> StrongDeleteAsync(T entity, bool autoSave = true)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _unitOfWork.Repository<T>().Remove(entity);

            if (autoSave)
            {
                await _unitOfWork.SaveChangesAsync();
            }

            return true;

        }

        public async Task<IList<T>> DeleteRangeAsync(IList<T> entities, bool autoSave = true)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }

            entities.ToList().ForEach(p => p.IsDeleted = true);
            _ = await UpdateRangeAsync(entities, autoSave);

            return entities;
        }

        public async Task<IList<T>> DeleteRangeAsync(IList<Guid> ids, bool autoSave = true)
        {
            if (ids == null)
            {
                throw new ArgumentNullException("entities");
            }

            var entities = await GetByIdsAsync(ids);

            await DeleteRangeAsync(entities, autoSave);

            return entities;
        }

        public async Task<IEnumerable<T>> DeleteRangeAsync(IEnumerable<T> entity, bool autoSave = true)
        {
            _unitOfWork.Repository<T>().RemoveRange(entity);
            if (autoSave)
            {
                await _unitOfWork.SaveChangesAsync();
            }
            return entity;
        }

        public IQueryable<T> GetQueryAbleIncludeDelete(Expression<Func<T, bool>>? expression = null, params Expression<Func<T, object>>[]? includes)
        {
            var query = from b in Table
                        select b;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return query;
        }

        public IQueryable<T> GetQueryable(Expression<Func<T, bool>>? expression = null, params Expression<Func<T, object>>[]? includes)
        {
            var query = from b in Table
                        where !b.IsDeleted
                        select b;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return query;
        }

        public IList<T> GetAll(Expression<Func<T, bool>>? expression = null,
            int skip = 0,
            int? take = null,
            params Expression<Func<T, object>>[]? includes
            )
        {
            var query = from b in Table
                        where !b.IsDeleted
                        select b;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            if (take != null)
            {
                query = query.Skip(skip).Take(take.Value);
            }

            return query.ToList();
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null,
                int skip = 0,
                int? take = null,
                params Expression<Func<T, object>>[]? includes
                )
        {
            var query = from b in Table
                        where !b.IsDeleted
                        select b;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            if (take != null)
            {
                query = query.Skip(skip).Take(take.Value);
            }

            return await query.ToListAsync();
        }

        public int SaveChanges()
        {
            return _unitOfWork.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>>? expression = null, params Expression<Func<T, object>>[]? includes)
        {
            var query = from b in Table
                        where !b.IsDeleted
                        select b;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return await query.FirstOrDefaultAsync();

        }

        //public virtual async Task<Guid> GetNewId()
        //{
        //    var query = from b in Table
        //                select b.Id;

        //    var tAny = query.AnyAsync();
        //    await tAny;

        //    if (tAny.IsFaulted) return await Task.FromException<int>(new System.Exception("GetNewId excute query any faield"));
        //    if (!tAny.Result) return 1;

        //    var tMax = query.MaxAsync();
        //    await tMax;

        //    if (tMax.IsFaulted) return await Task.FromException<int>(new System.Exception("GetNewId excute query Max faield"));
        //    return tMax.Result + 1;
        //}

        public virtual async Task<IList<T>> InsertOrReplaceAllAsync(IList<T> entities)
        {
            var existIds = Table.Select(p => p.Id).ToList();

            foreach (var item in entities)
            {
                if (!existIds.Contains(item.Id))
                {
                    item.CreatedOn = DateTime.UtcNow;
                    item.ModifiedOn = DateTime.UtcNow;
                    _unitOfWork.Repository<T>().Add(item);
                }
                else
                {
                    item.ModifiedOn = DateTime.UtcNow;
                    _unitOfWork.Repository<T>().Attach(item);
                    _unitOfWork.Context().Entry(item).State = EntityState.Modified;
                }
            }

            var isSaved = await _unitOfWork.SaveChangesAsync() > 0;
            return entities;
        }

        public virtual async Task<bool> Active(Guid id, bool isActive)
        {
            var currentEntity = await Table.FindAsync(id);
            if (currentEntity == null)
            {
                return false;
            }
            var context = _unitOfWork.Context();

            currentEntity.IsDeactivate = !isActive;
            currentEntity.ModifiedOn = DateTime.UtcNow;

            var isSaved = await context.SaveChangesAsync() > 0;

            if (!isSaved) throw new Exception("Saving failed");
            return isSaved;
        }

        public virtual async Task<bool> Active(T entity, bool isActive)
        {
            var context = _unitOfWork.Context();
            entity.ModifiedOn = DateTime.UtcNow;
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

            entity.IsDeactivate = !isActive;

            var isSaved = await context.SaveChangesAsync() > 0;

            if (!isSaved) throw new Exception("Saving failed");

            return isSaved;
        }

        public async Task<IQueryable<T>> GetPagedDataAsync(int pageIndex, int pageSize)
        {
            var query = GetQueryable();

            query = query.Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            return query;
        }

        public async Task<int> GetTotalRecords()
        {
            var query = GetQueryable();

            var totalRecords = await query.CountAsync();

            return totalRecords;
        }
    }
}
