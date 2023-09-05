using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace llllrrrr4
{
    [Serializable]
    class Train
    {
        private string numberOfTrain;
        private string fromDestination;
        private string toDestination;
        private double price;
        private int amountOfFreePlaces;

        public Train()
        { }

        public Train(string numberOfTrain, string fromDestination, string toDestination, double price, int countOfFreePlaces)
        {
            this.numberOfTrain = numberOfTrain;
            this.fromDestination = fromDestination;
            this.toDestination = toDestination;
            Price = price;
            this.amountOfFreePlaces = countOfFreePlaces;
        }
        public string NumberOfTrain { get => numberOfTrain; }
        public string FromDestination { get => fromDestination; }
        public string ToDestination { get => toDestination; }
        public double Price { get => price; set { price = value; } }
        public int AmountOfFreePlaces { get => amountOfFreePlaces; set { amountOfFreePlaces = value; } }
    }
}
