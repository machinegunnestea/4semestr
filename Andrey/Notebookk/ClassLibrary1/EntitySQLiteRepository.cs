using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityData
{
    public class EntitySQLiteRepository
    {
        private readonly string connectionString = @"Data Source=D:\универ\4sem\Andrey\Notebook.db";


        public IEnumerable<Notebook> GetAll()
        {
            using (SQLiteContext db = new SQLiteContext())
            {
                List<Notebook> notebooks = new List<Notebook>();
                var notebooksDB = db.Notebooks.ToList();
                foreach (var item in notebooksDB)
                    notebooks.Add(new Notebook
                    {
                        Day=item.Day,
                        Time=item.Time,
                        Event=item.Event,
                        Name=item.Name,
                        Number=item.Number,

                    });
                return notebooks;

            }
        }
        public Notebook GetById(string evvent)
        {
            using (SQLiteContext db = new SQLiteContext(connectionString))
            {
                return db.Notebooks.FirstOrDefault(x => x.Event == evvent);
            }
        }

        public void Create(Notebook item)
        {
            using (SQLiteContext db = new SQLiteContext(connectionString))
            {
                db.Notebooks.Add(item);
                db.SaveChanges();
            }
        }
        public void Delete(string evvent)
        {
            using (SQLiteContext db = new SQLiteContext(connectionString))
            {
                var item = db.Notebooks.FirstOrDefault(x => x.Event == evvent);
                db.Notebooks.Remove(item);
                db.SaveChanges();
            }
        }
        public void Update(Notebook item)
        {
            using (SQLiteContext db = new SQLiteContext(connectionString))
            {
                var temp = db.Notebooks.FirstOrDefault(x => x.Event == item.Event);
                temp = item;
                db.SaveChanges();
            }
        }
        public void Save(List<Notebook> sklads)
        {
            using (SQLiteContext db = new SQLiteContext())
            {
                var temp = db.Notebooks;
                db.Notebooks.RemoveRange(temp);
                db.Notebooks.AddRange(sklads);
                db.SaveChanges();
            }
        }
    }
}
