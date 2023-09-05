using EXxxLib.Entities;
using Microsoft.EntityFrameworkCore;

namespace EXxxLib.DB
{
    public class Context : DbContext
    {
        public DbSet<Breed> Breed { get; set; }
        public DbSet<Dog> Dog { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;
                                   Database=examdb1;
                                   Trusted_Connection=True;");
        }
    }
}
