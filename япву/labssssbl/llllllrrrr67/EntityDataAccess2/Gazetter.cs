using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab6.EntityDataAccess2
{
    [Table("Gazetters")]
    public class Gazetter
    {
        [Key]
        public string Country { get; set; }
        public double Square { get; set; }
        public double Population { get; set; }
        public string Continent { get; set; }
        public string Capital { get; set; }
    }
}
