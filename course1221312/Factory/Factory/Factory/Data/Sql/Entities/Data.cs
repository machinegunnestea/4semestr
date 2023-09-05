using Factory.Data.Sql.Repositories;

namespace Factory.Data.Sql.Entities
{
    public static class Data
    {
        public static DataLayer Get()
        {
            return new(new Materials(), new Products(), new Raws(), new Users());
        }
    }
}
