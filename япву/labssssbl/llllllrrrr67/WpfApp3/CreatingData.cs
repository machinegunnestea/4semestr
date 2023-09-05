using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public static class CreatingData
    {
        public static string Country { get; set; }
        public static double Square { get; set; }
        public static double Population { get; set; }
        public static string Continent { get; set; }
        public static string Capital { get; set; }
        public static void MakeEmptyFields()
        {
            Country = null;
            Square = 0;
            Population = 0;
            Continent = null;
            Capital = null;

        }
    }
}
