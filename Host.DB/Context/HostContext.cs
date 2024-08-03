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
            var appBuilder = modelBuilder.Entity<BookCategory>();
            appBuilder.HasData(new BookCategory().InitBookCategory());
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
    }
}
