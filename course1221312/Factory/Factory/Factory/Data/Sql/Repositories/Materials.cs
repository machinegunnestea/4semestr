using Factory.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Data.Sql.Repositories
{
    public class Materials : IRepository<Material>
    {
        private readonly FactoryContext db = FactoryContext.Get();

        public bool Add(Material itemToAdd)
        {
            try
            {
                db.Materials.Add(new()
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
                db.ProductsMaterials.RemoveRange(db.ProductsMaterials.Where(x => x.MaterialId == id));
                db.SaveChanges();
                db.Materials.Remove(db.Materials.First(x => x.Id == id));
                db.SaveChanges();
            }
            catch (Exception)
            {
                db.RollBack();
                return false;
            }
            return true;
        }

        public bool Update(Material itemToUpdate)
        {
            try
            {
                var item = db.Materials.FirstOrDefault(x => x.Id == itemToUpdate.Id);
                item.Name = itemToUpdate.Name;

                db.Materials.Update(item);
                db.SaveChanges();
            }
            catch (Exception)
            {
                db.RollBack();
                return false;
            }
            return true;
        }

        public IEnumerable<Material> GetAll()
        {
            return db.Materials.ToList().Select(x => new Material()
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        public int GetFreeId()
        {
            return db.Materials.Any() ? db.Materials.Max(x => x.Id) + 1 : 1;
        }

        public Material Find(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}
