namespace protecx
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }

        public override bool Equals(object obj) => (((Product)obj).Name == Name && ((Product)obj).Price == Price && ((Product)obj).Category == Category);

        public override int GetHashCode() => Name.GetHashCode() + Price.GetHashCode() + Category.GetHashCode();
    }
}
