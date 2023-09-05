using System.Collections.Generic;
using System.Linq;

namespace EntityData
{
    public class EntityMSSQLRepository
    {
        public IEnumerable<Notebook> GetAll()
        {
            using (MSSQLContext db = new MSSQLContext())
            {

                List<Notebook> notebooks = new List<Notebook>();
                var notebooksDB = db.Notebooks.ToList();
                foreach (var item in notebooksDB)
                    notebooks.Add(new Notebook
                    {
                        Day = item.Day,
                        Time = item.Time,
                        Event = item.Event,
                        Name = item.Name,
                        Number = item.Number,

                    });
                return notebooks;
            }
        }        
        public Notebook GetById(string evvent)
        {
            using (MSSQLContext db = new MSSQLContext())
            {
                return db.Notebooks.FirstOrDefault(x => x.Event == evvent);

            }
        }

        public void Create(Notebook item)
            {
                using (MSSQLContext db = new MSSQLContext())
                {
                    db.Notebooks.Add(item);
                    db.SaveChanges();
                }
            }
        public void Delete(string evvent)
        {
            using (MSSQLContext db = new MSSQLContext())
            {
                var item = db.Notebooks.FirstOrDefault(x => x.Event == evvent);
                db.Notebooks.Remove(item);
                db.SaveChanges();
            }
        }
        public void Update(Notebook item)
        {
            using (MSSQLContext db = new MSSQLContext())
            {
                var temp = db.Notebooks.FirstOrDefault(x => x.Event == item.Event);
                temp = item;
                db.SaveChanges();
            }
        }
        public void Save(List<Notebook> notebooks)
        {
            using (MSSQLContext db = new MSSQLContext())
            {
                var temp = db.Notebooks;
                db.Notebooks.RemoveRange(temp);
                db.Notebooks.AddRange(notebooks);
                db.SaveChanges();
            }
        }
    }
}
