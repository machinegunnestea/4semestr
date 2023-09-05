using System.Collections.Generic;

namespace Factory.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductPlan> Plans { get; set; } = new();
        public List<ProductProduction> Productions { get; set; } = new();
        public List<Norm> Norms { get; set; } = new();
        public List<ProductMaterial> Materials { get; set; } = new();
    }
}
