using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lecture
{
    public class AddExpense : AbstaractPurchase
    {
        public Commodity commodity;
        public int count;
        public AddExpense(Commodity commodity, int count) : base(commodity, count)
        {
            this.commodity = commodity;
            this.count = count;
        }

        public override AbstaractPurchase Add(AbstaractPurchase purchase)
        {
            if (purchase.Commodity.Name == commodity.Name)
            {
                count += purchase.Count;
                return new AddExpense(commodity, count);
            }
            return new AddExpense(commodity, count);
        }

        public override decimal GetCost() => commodity.Price * count + 50;
    }
}
