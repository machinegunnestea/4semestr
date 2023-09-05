using System;

namespace Factory.Data.Models
{
    public class ProductPlan
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public string DateStr => Date.ToString("d");
    }
}
