using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lecture
{
    public class Discount:AbstaractPurchase
    {
        public Commodity commodity;
        public int count;

        public Discount(Commodity commodity, int count) : base(commodity, count)
        {
            this.commodity = commodity;
            this.count = count;
        }
        public override decimal GetCost() => (commodity.Price * count) * 5 / 100;

        public override AbstaractPurchase Add(AbstaractPurchase purchase)
        {
            if (purchase.Commodity.Name == commodity.Name)
            {
                count += purchase.Count;
                return new Discount(commodity, count);
            }
            return new Discount(commodity, count);
        }
    }
}
