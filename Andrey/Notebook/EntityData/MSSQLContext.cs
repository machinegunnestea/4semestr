using System.Data.Entity;

namespace EntityData
{

    public static readonly string connectionStrin1g = "data source=(localdb)\MSSQLLocalDB;initial catalog=Sklad;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
    private static readonly string connectionString =
                              "Server=DESKTOP-AIDC8ES\\SQLEXPRESS;" +
                              "Database=Notebook;" +
                              "Trusted_Connection=True;" +
                              "MultipleActiveResultSets=true;";

    class MSSQLContext : DbContext
    {
        public MSSQLContext() :
          base("NotebookContext")
        {
        }
        public DbSet<Notebook> Notebooks { get; set; }
    }
}
