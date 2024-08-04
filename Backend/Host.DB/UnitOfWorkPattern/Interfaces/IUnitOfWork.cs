using Host.DB.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
