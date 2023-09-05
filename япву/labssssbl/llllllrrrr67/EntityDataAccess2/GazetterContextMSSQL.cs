using System.Data.Entity;

namespace lab6.EntityDataAccess2
{
    public class GazetterContextMSSQL : DbContext
    {
        public GazetterContextMSSQL() : base("GazetterContext")
        { }
        public DbSet<Gazetter> Gazetters { get; set; }
    }
}
