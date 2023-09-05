using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebookk
{
    public class NotebookManager
    {
        private List<NotebookModel> notebooks = new List<NotebookModel>();

        public NotebookManager(List<NotebookModel> items)
        {
            notebooks = items;
        }
        public List<NotebookModel> Sort()
        {
            notebooks.Sort();
            return notebooks;
        }
        public List<NotebookModel> Find(string name)
        {
            var items = Sort();
            return items.FindAll(x => x.Name.Contains(name));
        }
    }
}
