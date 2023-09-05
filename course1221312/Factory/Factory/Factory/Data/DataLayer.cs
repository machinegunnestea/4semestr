using Factory.Data.Models;
using System;

namespace Factory.Data
{
    public class DataLayer
    {
        public DataLayer(IRepository<Material> materials, IRepository<Product> products, IRepository<Raw> raws, IRepository<User> users)
        {
            Materials = materials ?? throw new ArgumentNullException(nameof(materials));
            Products = products ?? throw new ArgumentNullException(nameof(products));
            Raws = raws ?? throw new ArgumentNullException(nameof(raws));
            Users = users ?? throw new ArgumentNullException(nameof(users));
        }

        public static DataLayer Sql() => Data.Sql.Entities.Data.Get();

        public IRepository<Material> Materials { get; set; }
        public IRepository<Product> Products { get; set; }
        public IRepository<Raw> Raws { get; set; }
        public IRepository<User> Users { get; set; }
    }
}
