namespace Factory.Data.Sql.Entities
{
    public class ProductMaterial
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
    }
}
