using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXxxLib.Entities
{
    public class Breed
    {
        [Key]
        public int BreedId { get; set; }
        public string BreedName { get; set; }

        public override string ToString() => BreedName;

        public static implicit operator string(Breed v)
        {
            throw new NotImplementedException();
        }
    }
}
