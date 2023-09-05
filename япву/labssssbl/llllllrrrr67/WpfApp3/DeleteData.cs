using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public static class DeleteData
    {
        public static string Country { get; set; }
        public static void MakeEmptyFields()
        {
            Country = null;
        }
    }
}
