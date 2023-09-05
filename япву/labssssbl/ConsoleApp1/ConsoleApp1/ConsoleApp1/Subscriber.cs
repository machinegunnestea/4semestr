using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Subscriber : IComparable
    {
        private string lastName;
        private string address;
        public Dictionary<string, double> AllCostOfSubscriptions { get; set; }
        public double TotalCostOfSubscription
        {
            get
            {
                double sum = 0;
                foreach (KeyValuePair<string, double> costOfSubscriptions in AllCostOfSubscriptions)
                {
                    sum += costOfSubscriptions.Value;
                }
                return sum;
            }
        }
        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }
        public string Address
        {
            get => address;
            set => address = value;
        }
        public void InformationOutput(int number)
        {
            Console.WriteLine("├────────┼───────────────────┼────────────────────────────────────────┼──────────────────────────────┼────────────────────┤");
            Console.Write($"│ {number,-6} │ {LastName,-17} │ {Address,-38} │ ");
            bool flag = false;
            foreach (KeyValuePair<string, double> costOfSubscriptions in AllCostOfSubscriptions)
            {
                if (flag == false)
                {
                    Console.Write($" {costOfSubscriptions.Key, -28}│");
                    Console.WriteLine($" {TotalCostOfSubscription, -18} │");
                    flag = true;
                }
                else
                {
                    Console.WriteLine($"│        │                   │                                        │  {costOfSubscriptions.Key,-28}│                    │");
                }
            }
            
        }
        public int CompareTo(object obj)
        {
            Subscriber subscriber = obj as Subscriber;
            if(subscriber != null)
            {
                return subscriber.TotalCostOfSubscription.CompareTo(this.TotalCostOfSubscription);
            }
            else
            {
                throw new Exception("Невозможно сравнить два объекта");
            }
        }
        public void ChangeOfNameJournal(string newNameJournal, string old)
        {
            foreach(KeyValuePair<string, double> costOfSubscriptions in AllCostOfSubscriptions)
            {
                if (costOfSubscriptions.Key == old)
                {
                    double tmp = costOfSubscriptions.Value;
                    AllCostOfSubscriptions.Remove(old);
                    AllCostOfSubscriptions.Add(newNameJournal, tmp);
                    break;
                }
            }
        }
        public void ChangeOfPriceJournal(double newPriceJournal, string key)
        {
            //foreach (KeyValuePair<string, double> costOfSubscriptions in AllCostOfSubscriptions)
            //{
            //    if (costOfSubscriptions.Key == key)
            //    {
            //        //AllCostOfSubscriptions.Remove(key);
            //        //AllCostOfSubscriptions.Add(key, newPriceJournal);

            //        break;
            //    }
            //}
            AllCostOfSubscriptions[key] = newPriceJournal;
        }
    }
}
