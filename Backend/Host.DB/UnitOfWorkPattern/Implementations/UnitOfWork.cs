using Host.DB.Context;
using Host.DB.UnitOfWorkPattern.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Host.DB.UnitOfWorkPattern.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HostContext _context;

        public UnitOfWork(HostContext context)
        {
            _context = context;
        }

        public HostContext Context() => _context;

        public DbSet<T> Repository<T>() where T : class
        {
            return _context.Repository<T>();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public int SaveChanges(bool autoUpdateProperty = true)
        {
            if (autoUpdateProperty)
            {
                return _context.SaveChanges();
            }
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
