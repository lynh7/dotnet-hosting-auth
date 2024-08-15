using Host.DB.Context;
using Microsoft.EntityFrameworkCore;

namespace Host.DB.UnitOfWorkPattern.Interfaces
{
    public interface IUnitOfWork
    {
        HostContext Context();
        DbSet<T> Repository<T>() where T : class;
        int SaveChanges();
        int SaveChanges(bool autoUpdateProperty = true);
        Task<int> SaveChangesAsync();
    }
}
