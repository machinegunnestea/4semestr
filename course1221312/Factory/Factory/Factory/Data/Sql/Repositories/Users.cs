using Factory.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Data.Sql.Repositories
{
    public class Users : IRepository<User>
    {
        private readonly FactoryContext db = FactoryContext.Get();

        public bool Add(User itemToAdd)
        {
            try
            {
                db.Users.Add(new()
                {
                    Id = GetFreeId(),
                    Level = itemToAdd.Level,
                    Login = itemToAdd.Login,
                    Password = itemToAdd.Password
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
                db.Users.Remove(db.Users.First(x => x.Id == id));
                db.SaveChanges();
            }
            catch (Exception)
            {
                db.RollBack();
                return false;
            }
            return true;
        }

        public bool Update(User itemToUpdate)
        {
            try
            {
                var item = db.Users.FirstOrDefault(x => x.Id == itemToUpdate.Id);
                item.Login = itemToUpdate.Login;
                item.Password = itemToUpdate.Password;
                item.Level = itemToUpdate.Level;

                db.Users.Update(item);
                db.SaveChanges();
            }
            catch (Exception)
            {
                db.RollBack();
                return false;
            }
            return true;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.ToList().Select(x => new User()
            {
                Id = x.Id,
                Level = x.Level,
                Login = x.Login,
                Password = x.Password
            });
        }

        public int GetFreeId()
        {
            return db.Users.Any() ? db.Users.Max(x => x.Id) + 1 : 1;
        }

        public User Find(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}
