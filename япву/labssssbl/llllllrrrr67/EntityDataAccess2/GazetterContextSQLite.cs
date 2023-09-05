using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6.EntityDataAccess2
{
    public class GazetterContextSQLite : DbContext
    {
        public GazetterContextSQLite(string stringConnection) : base(stringConnection)
        { }
        public GazetterContextSQLite():base("GazetterConnection")
        { }
        public DbSet<Gazetter> Gazetters { get; set; }

    }
}
