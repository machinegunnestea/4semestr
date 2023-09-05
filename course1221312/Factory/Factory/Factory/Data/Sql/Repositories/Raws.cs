using Factory.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Data.Sql.Repositories
{
    public class Raws : IRepository<Raw>
    {
        private readonly FactoryContext db = FactoryContext.Get();

        public bool Add(Raw itemToAdd)
        {
            try
            {
                db.Raws.Add(new()
                {
                    Id = GetFreeId(),
                    Name = itemToAdd.Name
                });
                db.SaveChanges();
            }
            catch (Exception)
            {
                db.RollBack();
                return false;
            }
            return true;
        }

        public bool Remove(int id)
        {
            try
            {
                db.Norms.RemoveRange(db.Norms.Where(x => x.RawId == id));
                db.SaveChanges();
                db.Raws.Remove(db.Raws.First(x => x.Id == id));
                db.SaveChanges();
            }
            catch (Exception)
            {
                db.RollBack();
                return false;
            }
            return true;
        }

        public bool Update(Raw itemToUpdate)
        {
            try
            {
                var item = db.Raws.FirstOrDefault(x => x.Id == itemToUpdate.Id);
                item.Name = itemToUpdate.Name;

                db.Raws.Update(item);
                db.SaveChanges();
            }
            catch (Exception)
            {
                db.RollBack();
                return false;
            }
            return true;
        }

        public IEnumerable<Raw> GetAll()
        {
            return db.Raws.ToList().Select(x => new Raw()
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        public int GetFreeId()
        {
            return db.Raws.Any() ? db.Raws.Max(x => x.Id) + 1 : 1;
        }

        public Raw Find(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}
