using System;
using System.Collections.Generic;

namespace lab2
{
    class Table
    {
        public void HeaderTable()
        {
            Console.WriteLine("┌─────────┬────────────────────┬─────────────────────────────────┬────────────────┐");
            Console.WriteLine("│         │ Lastname           │             date of             │     Age        │");
            Console.WriteLine("│         │                    │            discharge            │                │ ");
        }

        public void TableLines<T>(Collection<T> collection) where T : struct,IComparable<T>
        {
            int i = 1;
            foreach (var item in collection.Patients)
            {
                {
                    Console.WriteLine("├─────────┼────────────────────┼─────────────────────────────────┼────────────────┤");
                    Console.WriteLine($"│ {i,-7} │ {item} │");
                    i++;
                }
            }
        }
        public void TableLinesList<T>(List<T> list) where T : struct
        {
            int i = 1;
            foreach (var item in list)
            {
                {
                    Console.WriteLine("├─────────┼────────────────────┼─────────────────────────────────┼────────────────┤");
                    Console.WriteLine($"│ {i,-7} │ {item} │");
                    i++;
                }
            }
        }
        public void BottomTable()
        {
            Console.WriteLine("└─────────┴────────────────────┴─────────────────────────────────┴────────────────┘\n");
        }
    }
}
