using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXxxLib.Entities
{
    [Serializable]
    public class Dog
    {
        [Key]
        public int Id { get; set; }
        public int BreedId { get; set; }
        public Breed Breed { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public override string ToString() => Name;
        public Dog()
        {
        }
    }
}
