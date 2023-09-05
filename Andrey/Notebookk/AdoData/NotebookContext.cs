using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoData
{
    public class NotebookContext
    {
        public const string AdoMSSQLConnectionString = "Server=DESKTOP-AIDC8ES\\SQLEXPRESS;" +
                              "Database=Notebook;" +
                              "Trusted_Connection=True;" +
                              "MultipleActiveResultSets=true;";
        public const string AdoSQLiteConnectionString = @"Data Source=D:\универ\4sem\Andrey\Notebook.db";

    }
}
