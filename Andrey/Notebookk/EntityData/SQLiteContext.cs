using System.Data.Entity;

namespace EntityData
{

    public class SQLiteContext : DbContext
    {
        public SQLiteContext(string stringConnection) : base(stringConnection)
        {
        }
        public SQLiteContext() : base("NotebookConnection")
        {
        }
        public DbSet<Notebook> Notebooks { get; set; }

    }
}
