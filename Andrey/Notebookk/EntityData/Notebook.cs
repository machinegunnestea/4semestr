using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityData
{
    [Table("Notebooks")]
    public class Notebook
    {
        public string Day { get; set; }
        public DateTime Time { get; set; }
        [Key]
        public string Event { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }


    }
}
