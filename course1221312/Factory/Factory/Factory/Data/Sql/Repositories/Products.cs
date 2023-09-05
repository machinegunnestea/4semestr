using Factory.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Data.Sql.Repositories
{
    public class Products : IRepository<Product>
    {
        private readonly FactoryContext db = FactoryContext.Get();

        public bool Add(Product itemToAdd)
        {
            try
            {
                db.Products.Add(new()
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

        private int GetFreeProductMaterialId()
        {
            return db.ProductsMaterials.Any() ? db.ProductsMaterials.Max(x => x.Id) + 1 : 1;
        }

        public bool Remove(int id)
        {
            try
            {
                db.Norms.RemoveRange(db.Norms.Where(x => x.ProductId == id));
                db.SaveChanges();
                db.ProductsMaterials.RemoveRange(db.ProductsMaterials.Where(x => x.ProductId == id));
                db.SaveChanges();
                db.ProductsProductions.RemoveRange(db.ProductsProductions.Where(x => x.ProductId == id));
                db.SaveChanges();
                db.ProductsPlans.RemoveRange(db.ProductsPlans.Where(x => x.ProductId == id));
                db.SaveChanges();
                db.Products.Remove(db.Products.First(x => x.Id == id));
                db.SaveChanges();
            }
            catch (Exception)
            {
                db.RollBack();
                return false;
            }
            return true;
        }

        private int GetFreeProductionId()
        {
            return db.ProductsProductions.Any() ? db.ProductsProductions.Max(x => x.Id) + 1 : 1;
        }

        public int GerFreePlanId()
        {
            return db.ProductsPlans.Any() ? db.ProductsPlans.Max(x => x.Id) + 1 : 1;
        }


        private int GetFreeNormId()
        {
            return db.Norms.Any() ? db.Norms.Max(x => x.Id) + 1 : 1;
        }

        public bool Update(Product itemToUpdate)
        {
            try
            {
                var item = db.Products.FirstOrDefault(x => x.Id == itemToUpdate.Id);
                item.Name = itemToUpdate.Name;

                db.Norms.RemoveRange(db.Norms.Where(x => x.RawId == item.Id));
                db.SaveChanges();

                db.Norms.AddRange(itemToUpdate.Norms.Select(x => new Entities.Norm()
                {
                    Id = GetFreeNormId(),
                    ProductId = itemToUpdate.Id,
                    quantity = x.Quantity,
                    RawId = itemToUpdate.Id
                }));
                db.SaveChanges();

                db.ProductsProductions.RemoveRange(db.ProductsProductions.Where(x => x.ProductId == item.Id));
                db.SaveChanges();

                db.ProductsProductions.AddRange(itemToUpdate.Productions.Select(x => new Entities.ProductProduction()
                {
                    Id = GetFreeProductionId(),
                    DayProduction = x.Date,
                    Count = x.Count,
                    ProductId = itemToUpdate.Id
                }));
                db.SaveChanges();

                db.ProductsPlans.RemoveRange(db.ProductsPlans.Where(x => x.ProductId == item.Id));
                db.SaveChanges();

                db.ProductsPlans.AddRange(itemToUpdate.Plans.Select(x => new Entities.ProductPlan()
                {
                    Id = GerFreePlanId(),
                    Date = x.Date,
                    Count = x.Count,
                    ProductId = itemToUpdate.Id
                }));
                db.SaveChanges();

                db.ProductsMaterials.RemoveRange(db.ProductsMaterials.Where(x => x.MaterialId == item.Id));
                db.SaveChanges();

                db.ProductsMaterials.AddRange(itemToUpdate.Materials.Select(x => new Entities.ProductMaterial()
                {
                    Id = GetFreeProductMaterialId(),
                    MaterialId = itemToUpdate.Id,
                    Quantity = x.Quantity,
                    ProductId = x.Id
                }));
                db.SaveChanges();


                db.Products.Update(item);
                db.SaveChanges();
            }
            catch (Exception)
            {
                db.RollBack();
                return false;
            }
            return true;
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products.ToList().Select(x => new Product()
            {
                Id = x.Id,
                Name = x.Name,
                Plans = db.ProductsPlans.Where(p => p.ProductId == x.Id).ToList().Select(p => new ProductPlan()
                {
                    Id = p.Id,
                    Count = p.Count,
                    Date = p.Date
                }).ToList(),
                Productions = db.ProductsProductions.Where(p => p.ProductId == x.Id).ToList().Select(p => new ProductProduction()
                {
                    Id = p.Id,
                    Count = p.Count,
                    Date = p.DayProduction
                }).ToList(),
                Materials = db.ProductsMaterials.Where(m => m.MaterialId == x.Id)
                    .Select(m => new ProductMaterial()
                    {
                        Id = m.Id,
                        Material = new Materials().Find(m.MaterialId),
                        Quantity = m.Quantity
                    }).ToList(),
                Norms = db.Norms.Where(n => n.RawId == x.Id).ToList().Select(s => new Norm()
                {
                    Id = s.Id,
                    Raw = new Raws().Find(s.RawId),
                    Quantity = s.quantity
                }).ToList()
            });
        }

        public int GetFreeId()
        {
            return db.Products.Any() ? db.Products.Max(x => x.Id) + 1 : 1;
        }

        public Product Find(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}
