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
            set
            {
                //if (observer != null)
                //{
                //    observer(value, nameOfJournal);
                //}
                observer?.Invoke(value, nameOfJournal);
                nameOfJournal = value;

            }
        }
        public double SubscriptionPrice
        {
            get => subscriptionPrice;
            set
            {

                PriceChange?.Invoke(value, nameOfJournal);
                subscriptionPrice = value;
            }
        }

        public event SubscriptionPriceEventHandler PriceChange;

        ChangeInName observer;
        public void ObserverRegistration(ChangeInName ob)
        {
            observer += ob;
        }
       
        
    }
}
