using System;

namespace ConsoleApp1
{
    public delegate void ChangeInName(string newNameJournal, string key);
    public delegate void SubscriptionPriceEventHandler(double newPrice, string key);
    class Journal
    {
        private string nameOfJournal;
        private double subscriptionPrice;
        public string NameOfJournal
        {
            get => nameOfJournal;
            set => nameOfJournal = value;
        }
        public double SubscriptionPrice
        {
            get => subscriptionPrice;
            set => subscriptionPrice = value;
        }

        public event SubscriptionPriceEventHandler PriceChange;

        ChangeInName observer;
        public void ObserverRegistration(ChangeInName ob)
        {
            observer += ob;
        }
        public void InputName()
        {
            Console.Write($"Введите новое название журнала {nameOfJournal}: ");
            string newNameJournal = Console.ReadLine();
            if (observer != null)
            {
                observer(newNameJournal, nameOfJournal);
            }
            NameOfJournal = newNameJournal;
        }
        public void InputPrice()
        {
            double price;
            Console.Write($"Введите новую годовую стоимость подписки журнала {nameOfJournal}: ");
            string input = Console.ReadLine();
            while (!Double.TryParse(input, out price) || price > 1000 || price < 1)
            {
                Console.Write($"Произошла ошибка. Введите новую годовую стоимость подписки журнала {nameOfJournal}: ");
                input = Console.ReadLine();
            }
            if (PriceChange != null)
            {
                PriceChange(price, NameOfJournal);
            }
            SubscriptionPrice = price;
        }
    }
}
