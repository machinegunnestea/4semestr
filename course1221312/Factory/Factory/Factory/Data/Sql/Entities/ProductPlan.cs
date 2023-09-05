using System;

namespace Factory.Data.Sql.Entities
{
    public class ProductPlan
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
    }
}
