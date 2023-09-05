using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebookk
{
    public class NotebookModel :IComparable
    {
        public string Day { get; set; }
        public DateTime Time { get; set; }
        public string Event { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }

        public int CompareTo(object obj)
        {
            NotebookModel temp = obj as NotebookModel;
            if (temp != null)
                return this.Name.CompareTo(temp.Name);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
    }
}
