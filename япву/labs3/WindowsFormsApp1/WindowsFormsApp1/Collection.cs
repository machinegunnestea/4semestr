using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Collection
    {
        public List<Worker> workers = new List<Worker>();

        public void Add(Worker worker)
        {
            workers.Add(worker);
        } 

    }
}
