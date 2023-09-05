using System;

namespace protecx1
{
    public static class ExtensionDog
    {
        private const float MaxWeightDog = 50;
        public static void OutputInformation(this Dog dog, string information)
        {
            if (dog.Weight < MaxWeightDog)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(information);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(information);
                Console.ResetColor();
            }
        }
    }
}