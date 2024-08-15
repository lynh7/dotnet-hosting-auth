using Host.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Host.DB.Context
{
    public class HostContext : DbContext
    {
        public HostContext()
        {
        }

        public HostContext(DbContextOptions<HostContext> options) : base(options)
        {
        }

        #region DbSet
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Client> Clients { get; set; }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            try
            {
                //EntitiesRelationShipBuilder(modelBuilder);
                LowerCaseForAllEntityInSchema(modelBuilder);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Seed(modelBuilder);
        }

        private void EntitiesRelationShipBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                  .HasOne(b => b.Category)
                  .WithMany(bc => bc.Books)
                  .HasForeignKey(b => b.BookCategoryId);
        }

        private void LowerCaseForAllEntityInSchema(ModelBuilder builder)
        {
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                if (entity.IsKeyless)
                {
                    foreach (var property in entity.GetProperties())
                    {
                        property.SetColumnName(property.GetColumnName(StoreObjectIdentifier.Table(entity.GetTableName())).ToLower());
                    }
                }
                else
                {
                    var currentTableName = builder.Entity(entity.Name).Metadata.GetTableName();
                    builder.Entity(entity.Name).ToTable(currentTableName.ToLower());
                    foreach (var property in entity.GetProperties())
                    {
                        property.SetColumnName(property.GetColumnName(StoreObjectIdentifier.Table(entity.GetTableName())).ToLower());
                    }
                }
            }
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            var bookBuilder = modelBuilder.Entity<BookCategory>();
            bookBuilder.HasData(new BookCategory().InitBookCategory());

            var superAdminBuilder = modelBuilder.Entity<Client>();
            superAdminBuilder.HasData(new Client().SuperAdminSeedDefault());
        }

        #endregion

        public async Task RunMigration()
        {
            var migrations = await Database.GetPendingMigrationsAsync();
            if (migrations.Any())
            {
                await Database.MigrateAsync();
            }
        }


        #region Methods
        public virtual DbSet<T> Repository<T>() where T : class
        {
            return Set<T>();
        }
        public virtual async Task<int> SaveChangesAsync()
        {
            var changedEntries = base.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .GroupBy(e => e.Metadata.Name)
                .Select(g => g.First())
                .Select(e => e.Entity.GetType());

            var result = await base.SaveChangesAsync();

            return result;
        }
        #endregion 
    }
}
