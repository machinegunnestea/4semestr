using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lecture
{    public abstract class AbstaractPurchase : IComparable<AbstaractPurchase>
    {
        private Commodity commodity;
        private int count;

        public Commodity Commodity { get => commodity; set => commodity = value; }
        public int Count { get => count; set => count = value; }
        public abstract decimal GetCost();
        public int CompareTo(AbstaractPurchase other) => this.GetCost().CompareTo(other.GetCost());

        public override string ToString() => $"{Commodity}; {count}";

        protected AbstaractPurchase(Commodity commodity, int count)
        {
            this.commodity = commodity;
            this.count = count;
        }
        public static AbstaractPurchase operator +(AbstaractPurchase purchase1, AbstaractPurchase purchase2) => purchase1.Add(purchase2);
        public abstract AbstaractPurchase Add(AbstaractPurchase purchase);


    }

}

