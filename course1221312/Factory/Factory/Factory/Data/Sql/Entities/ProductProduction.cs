using System;

namespace Factory.Data.Sql.Entities
{
    public class ProductProduction
    {
        public int Id { get; set; }
        public DateTime DayProduction { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
