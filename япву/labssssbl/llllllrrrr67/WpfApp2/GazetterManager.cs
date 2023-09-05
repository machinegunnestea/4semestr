using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class GazetterManager
    {
        private List<GazetterModel> gazetters = new List<GazetterModel>();

        public GazetterManager(List<GazetterModel> items)
        {
            gazetters = items;
        }
        public List<GazetterModel> Sort()
        {
            gazetters.Sort();
            return gazetters;
        }
        public List<GazetterModel> Find(string country)
        {
            var items = Sort();
            return items.FindAll(x => x.Capital.Contains(country));
        }
    }
}
