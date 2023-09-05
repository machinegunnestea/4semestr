using System;

namespace ConsoleApp1
{
    class Table
    {
        public void HeaderTable()
        {
            Console.WriteLine("┌────────┬───────────────────┬────────────────────────────────────────┬──────────────────────────────┬────────────────────┐");
            Console.WriteLine("│  №     │ Фамилия           │                 Адрес                  │ Издания                      │ Стоимость          │");
            Console.WriteLine("│        │                   │                                        │                              │                    │");
        }

        public void BottomTable()
        {
            Console.WriteLine("└────────┴───────────────────┴────────────────────────────────────────┴──────────────────────────────┴────────────────────┘");
        }
    }
}
