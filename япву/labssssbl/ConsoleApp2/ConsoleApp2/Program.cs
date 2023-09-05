using System;
using System.Collections;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList A = new ArrayList(200);
            A.Add("Вася");
            A.Add("Васйя");
            int k = A.Add(55);
            Console.WriteLine(k);  // будет выведено значение 1.
            ArrayList B = new ArrayList(1);
            B.Add(3); B.Add(6.5); B.Add(2);
            A.AddRange(B);
            foreach (object a in A)
                Console.WriteLine(a);

        }
    }
}
