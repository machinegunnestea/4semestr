
namespace exLessons
{
    public class Commodity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime DateManufacture { get; set; }
        public int ExpirationDate { get; set; } //в днях
        public DateTime GetExpirationDate() => DateManufacture.AddDays(ExpirationDate);
        
        public Commodity(string name, decimal price, DateTime dateManufacture, int expirationDate)
        {
            Name = name;
            Price = price;
            DateManufacture = dateManufacture;
            ExpirationDate = expirationDate;
        }

        public override string ToString() => $"{Name}; {Price}; {DateManufacture:d}; {ExpirationDate}";
        
    }
}
