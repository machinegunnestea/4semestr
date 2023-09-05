using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6.EntityDataAccess2
{
    public class GazetterEntityMSSQLRepository
    {
        public IEnumerable<Gazetter> GetAll()
        {
            using (GazetterContextMSSQL db = new GazetterContextMSSQL())
            {

                List<Gazetter> gazetters = new List<Gazetter>();
                var gazettersDB = db.Gazetters;
                foreach (var item in gazettersDB)
                    gazetters.Add(new Gazetter
                    {
                        Country = item.Country,
                        Square = item.Square,
                        Population = item.Population,
                        Continent = item.Continent,
                        Capital = item.Capital,
                    });
                return gazetters;
            }
        }
        public Gazetter GetById(string country)
        {
            using (GazetterContextMSSQL db = new GazetterContextMSSQL())
            {
                return db.Gazetters.FirstOrDefault(x => x.Country == country);

            }
        }
        public void Create(Gazetter item)
        {
            using (GazetterContextMSSQL db = new GazetterContextMSSQL())
            {
                db.Gazetters.Add(item);
                db.SaveChanges();
            }
        }
        public void Delete(string country)
        {
            using (GazetterContextMSSQL db = new GazetterContextMSSQL())
            {
                var item = db.Gazetters.FirstOrDefault(x => x.Country == country);
                db.Gazetters.Remove(item);
                db.SaveChanges();
            }
        }
        public void Update(Gazetter item)
        {
            using (GazetterContextMSSQL db = new GazetterContextMSSQL())
            {
                var temp = db.Gazetters.FirstOrDefault(x => x.Country == item.Country);
                temp = item;
                db.SaveChanges();
            }
        }
        public void Save(List<Gazetter> gazetters)
        {
            using (GazetterContextMSSQL db = new GazetterContextMSSQL())
            {
                var temp = db.Gazetters;
                db.Gazetters.RemoveRange(temp);
                db.Gazetters.AddRange(gazetters);
                db.SaveChanges();
            }
        }
    }
}
