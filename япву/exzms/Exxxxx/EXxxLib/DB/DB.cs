using System.Collections.Generic;
using System.Linq;

namespace EXxxLib.DB
{
    public static class DB
    {
        private static readonly Context context = new Context();

        public static class Dog
        {
            public static List<Entities.Dog> ReadAll()
            {
                return context.Dog.ToList();
            }
            public static void Add(Entities.Dog dog)
            {
                context.Dog.Add(dog);
                context.SaveChanges();
            }
            public static void Update(Entities.Dog dog)
            {
                context.Dog.Update(dog);
                context.SaveChanges();
            }
        }
        public static class Breed
        {
            public static List<Entities.Breed> ReadAll()
            {
                return context.Breed.ToList();
            }
            public static void Add(Entities.Breed breed)
            {
                context.Breed.Add(breed);
                context.SaveChanges();
            }
        }
    }
}
