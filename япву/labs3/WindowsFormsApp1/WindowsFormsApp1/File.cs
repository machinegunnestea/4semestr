using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApp1
{
    class File<T> where T : Worker

    {
        public static void OutputFromFile(Collection list, string path)
        {
            int counterOfLines = File.ReadAllLines(path).Length;

            using (StreamReader fstream = new StreamReader(path))            // если файл существует - то он открывается/ нет - создается
            {
                for (int i = 0; i < counterOfLines; i++)
                {
                    string[] temp = fstream.ReadLine().Split(';').ToArray();

                    Worker tmp = new Worker(temp[0], temp[1], DateTime.Parse(temp[2]), Double.Parse(temp[3]));
                    list.Add(tmp);
                }
            }
        }
        public static void WriteToFile(Collection list, string path)
        {
            using (StreamWriter stream = new StreamWriter(path, false))       // true - записывает в конец и после блока using закрывает поток 
            {
                foreach (T t in list.workers)
                {
                    stream.Write(t.Surname);
                    stream.Write(";");
                    stream.Write(t.FirmName);
                    stream.Write(";");
                    stream.Write(t.BirthDay);
                    stream.Write(";");
                    stream.Write(t.Payment);
                    stream.Write("\n");
                }
            }
        }
    }
}
