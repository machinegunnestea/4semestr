using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace FileDataAccess
{
    public class JsonManager
    {
        public IEnumerable<Gazetter> GetAll()
        {
            string json = File.ReadAllText(FileContext.JsonName);
            var result = JsonConvert.DeserializeObject<List<Gazetter>>(json);
            return result;
        }
        public void Create(Gazetter item)
        {
            var json = JsonConvert.SerializeObject(item);
            File.WriteAllText(FileContext.JsonName, json);
        }
        public void Delete(string country)
        {
            List<Gazetter> gazetters = GetAll().ToList();
            var del = gazetters.FirstOrDefault(x => x.Country == country);
            gazetters.Remove(del);
            var json = JsonConvert.SerializeObject(gazetters);
            File.WriteAllText(FileContext.JsonName, json);
        }
        public void Save(List<Gazetter> gazetters)
        {
            var str = JsonConvert.SerializeObject(gazetters);
            File.WriteAllText(FileContext.JsonName, str);
        }
    }
}
