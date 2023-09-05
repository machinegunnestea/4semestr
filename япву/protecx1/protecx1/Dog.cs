using System;
using System.Collections.Generic;
using System.Text;

namespace protecx1
{
    public class Dog
    {
        public string Name;
        public int Weight;
        public int StartedWeight;
        public event EventHandler<DogWeightChangedEventArgs> Notify;
        public Dog(string name, int weight)
        {
            Name = name;
            Weight = weight;
            StartedWeight = weight;
        }

        public void ChangeWeight(int weight)
        {
            Weight += weight;
            Notify?.Invoke(this, new DogWeightChangedEventArgs(Name, Weight));
        }

    }

    public class DogWeightChangedEventArgs : EventArgs
    {
        public string Name { get; }
        public float NewWeight { get; }

        public DogWeightChangedEventArgs(string name, float newWeight)
        {
            Name = name;
            NewWeight = newWeight;
        }
    }
}