using System;
using System.Collections;
using System.Collections.Generic;

namespace lab2
{
    class Collection<T> : IEnumerable<T> where T : struct, IComparable<T> // ограничение на параметр типа значимый
    {
        public Stack<T> Patients { get; set; } = new Stack<T>();

        public List<T> Search(Predicate<T> searchParameter)
        {
            List<T> listSearched = new List<T>();
            foreach (var item in Patients)
            {
                if (searchParameter(item))
                {
                    listSearched.Add(item);
                }
            }
            return listSearched;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Patients.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
