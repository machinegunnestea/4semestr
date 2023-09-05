using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab6.FileDataAccess
{
    public class XMLManager
    {
        public IEnumerable<Gazetter> GetAll()
        {
            XDocument xdoc = XDocument.Load(FileContext.XMLName);
            List<Gazetter> gazetters = new List<Gazetter>();
            foreach (XElement gazetterElement in xdoc.Element("gazetters").Elements("gazetters"))
            {
                gazetters.Add(new Gazetter
                {
                    Country = gazetterElement.Element("country").Value,
                    Square = Convert.ToDouble(gazetterElement.Element("square").Value),
                    Population = Convert.ToDouble(gazetterElement.Element("population").Value),
                    Continent = gazetterElement.Element("continent").Value,
                    Capital = gazetterElement.Element("capital").Value,
                });
            }
            return gazetters;
        }
        public void Create(Gazetter item)
        {
            XDocument xdoc = XDocument.Load(FileContext.XMLName);
            XElement root = xdoc.Element("gazetters");
            root.Add(new XElement("gazetter",
                            new XElement("country", item.Country),
                            new XElement("square", item.Square),
                            new XElement("population", item.Population),
                            new XElement("continent", item.Continent),
                            new XElement("capital", item.Capital)
                ));
            xdoc.Save(FileContext.XMLName);
        }
        public void Delete(string country)
        {
            XDocument xdoc = XDocument.Load(FileContext.XMLName);
            XElement root = xdoc.Element("gazetters");

            root.Elements("gazetter").ToList().FirstOrDefault(x => x.Element("country").Value == country).Remove();
            root.Save(FileContext.XMLName);
        }
        public void Save(List<Gazetter> gazetters)
        {
            var items = GetAll();
            foreach (var item in items)
                Delete(item.Country);

            foreach (var gazetter in gazetters)
            {
                Create(gazetter);
            }

        }
    }
}
