using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class GazetterModel: IComparable
    {
        public string Country { get; set; }
        public double Square { get; set; }
        public double Population { get; set; }
        public string Continent { get; set; }
        public string Capital { get; set; }
        public int CompareTo(object o)
        {
            GazetterModel temp = o as GazetterModel;
            if (temp != null)
                return this.Capital.CompareTo(temp.Capital);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
    }
}
