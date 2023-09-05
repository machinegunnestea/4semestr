using Factory.Data.Sql.Entities;
using Microsoft.EntityFrameworkCore;

namespace Factory.Data.Sql
{
    public class FactoryContext : DbContext
    {
        private static readonly string conStr =
                                      "Server=DESKTOP-AIDC8ES\\SQLEXPRESS;" +
                                      "Database=ll2;" +
                                      "Trusted_Connection=True;" +
                                      "MultipleActiveResultSets=true;";

        public DbSet<Material> Materials { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Norm> Norms { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductMaterial> ProductsMaterials { get; set; }
        public DbSet<ProductPlan> ProductsPlans { get; set; }
        public DbSet<ProductProduction> ProductsProductions { get; set; }
        public DbSet<Raw> Raws { get; set; }

        public FactoryContext(DbContextOptions<FactoryContext> options)
            : base(options) { }

        private static readonly FactoryContext context;

        static FactoryContext()
        {
            DbContextOptionsBuilder<FactoryContext> optionsBuilder = new();
            optionsBuilder.UseSqlServer(conStr);
            context = new(optionsBuilder.Options);
        }

        public void RollBack()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }

        public static FactoryContext Get()
        {
            return context;
        }
    }
}
