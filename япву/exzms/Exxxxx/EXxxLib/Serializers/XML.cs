using EXxxLib.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace EXxxLib.Serializers
{
    public static class XML
    {

        public static void Save(List<Dog> dogs, string filename)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Dog[]));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, dogs.ToArray());
            }
        }

    }
}
