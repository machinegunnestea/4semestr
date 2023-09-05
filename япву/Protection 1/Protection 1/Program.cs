using System;

namespace Protection_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Dog[] dogsArray = new[]
            {
                new Dog("Lana", 20),
                new Dog("Tuzik", 30),
                new Dog("Lord", 16),
                new Dog("Pookie", 50)
            };
            OutputInformation(dogsArray);
            Registration(dogsArray);
            WeightChange(dogsArray);
        }

        private static void WeightChange(Dog[] dogs)
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                var dog = dogs[random.Next(0, dogs.Length - 1)];
                dog.ChangeWeight(random.Next(-dog.Weight, dog.Weight));
            }
        }
        private static void Registration(Dog[] array)
        {
            foreach (var item in array)
            {
                item.Notify += OnChangeWeight;
            }
        }

        private static void OnChangeWeight(object sender, DogWeightChangedEventArgs e)
        {
            Dog dog = (Dog)sender;
            float currentWeight = dog.StartedWeight;
            if (currentWeight > e.NewWeight)
            {
                dog.OutputInformation($"The dog {e.Name} has lost weight");
            }
            else if (Math.Abs(currentWeight - e.NewWeight) == 0)
            {
                dog.OutputInformation($"The dog {e.Name} has not changed its weight");
            }
            else
            {
                dog.OutputInformation($"The dog {e.Name} recovered");
            }
        }

        private static void OutputInformation(Dog[] array)
        {
            foreach (var item in array)
            {
                item.OutputInformation($"Name - {item.Name}\tWeight - {item.Weight}");
            }
            Console.WriteLine();
        }
    }
}