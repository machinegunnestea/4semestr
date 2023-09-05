using System.Data.Entity;

namespace EntityData
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext() :
          base("NotebookContext")
        {
        }
        public DbSet<Notebook> Notebooks { get; set; }
    }
}
