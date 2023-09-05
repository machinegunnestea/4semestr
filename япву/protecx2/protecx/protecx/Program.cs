using System;
using System.Collections.Generic;
using System.Linq;


namespace protecx
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product() { Name = "laptop", Price = 1200, Category = "office equipment" };
            Product product2 = new Product() { Name = "dragon age", Price = 4200, Category = "game" };
            Product product3 = new Product() { Name = "ruler", Price = 2000, Category = "pencil case" };
            Product product4 = new Product() { Name = "printer", Price = 2000, Category = "office equipment" };
            Product product5 = new Product() { Name = "pen", Price = 100, Category = "pencil case" };
            Product product6 = new Product() { Name = "ice age 2", Price = 1400, Category = "game" };
            Product product7 = new Product() { Name = "audi", Price = 7400, Category = "car" };
            Product product8 = new Product() { Name = "scanner", Price = 700, Category = "office equipment" };

            List<Product> products1 = new List<Product>() { product1, product2, product3 };
            List<Product> products2 = new List<Product>() { product4, product5, product6, product7, product8 };

            Console.WriteLine("Oficce equipment that cost more than 1000");
            var equipment = products1.Union(products2)
                                        .Where(x => x.Category == "office equipment" && x.Price > 1000);
            equipment.ToList().ForEach(x => Console.WriteLine(x.Name));

            Console.WriteLine("\nEverything that is not in pencil case and costs more than 1000");

            var notMebel = products1.Union(products2)
                                    .Where(x => x.Category != "pencil case" && x.Price > 3000)
                                    .Select(x => new { x.Name, x.Price });
            foreach (var item in notMebel)
            {
                Console.WriteLine($"{item.Name}, {item.Price}");
            }


            Console.WriteLine("\nMax price product");
            var maxPrice = products1.Union(products2)
                                    .Where(item => item.Price == products1.Union(products2).Max(x => x.Price));
            foreach (var item in maxPrice)
            {
                Console.WriteLine($"{item.Name}, {item.Category}");
            }

            var average = products1.Union(products2)
                                    .Select(x => x.Price)
                                    .Average();
            Console.WriteLine("\nAverage cost of everything: " + average + "\n");

            Console.WriteLine("All categories w/ distinction");
            var listCategories = products1.Union(products2)
                                            .Select(x => x.Category)
                                            .Distinct();
            foreach (var item in listCategories)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nSame price goods");
            var listPriceMatches = from product in products1.Union(products2)
                                   group product by product.Price into g
                                   where g.Count() > 1
                                   select new
                                   {
                                       Name = g.Select(p => p)
                                   };


            foreach (var group in listPriceMatches)
            {
                foreach (var item in group.Name)
                {
                    Console.WriteLine(item.Name);
                }
            }
            Console.WriteLine("\nSorted goods by name");

            var namesAndCategoriesAlphabetically = from product in products1.Union(products2)
                                                   orderby product.Name
                                                   select new
                                                   {
                                                       product.Name,
                                                       product.Category
                                                   };
            foreach (var item in namesAndCategoriesAlphabetically)
            {
                Console.WriteLine(item.Name + " " + item.Category);
            }
            Console.WriteLine("\n");
            Console.WriteLine("Cars from 1000 to 2000");

            var availabilityAuto = products1.Union(products2)
                                            .Any(a => a.Category == "car" && a.Price > 1000 && a.Price < 2000);
            if (availabilityAuto)
            {
                Console.WriteLine("Category \"car\" contains goods from 1000 to 2000");
            }


            Console.WriteLine("\nAverage cost byy category");
            var averageOnCategories = from product in products1.Union(products2)
                                      group product by product.Category into g
                                      select new
                                      {
                                          Category = g.Key,
                                          AveragePrice = g.Average()
                                      };

            foreach (var group in averageOnCategories)
            {
                Console.WriteLine("Category: " + group.Category + " Average price: " + group.AveragePrice);

            }
            Console.WriteLine("\n");
            Console.WriteLine("Count of categories");
            var listCategoriesAndCount = from product in products1.Union(products2)
                                         group product by product.Category into g
                                         select new
                                         {
                                             Category = g.Select(item => item.Category)
                                                         .Distinct(),
                                             CountProducts = g.Select(item => item.Category)
                                                              .Count()
                                         };
            foreach (var group in listCategoriesAndCount)
            {
                foreach (var item in group.Category)
                {
                    Console.WriteLine("Category: " + item + " Ampont of goods: " + group.CountProducts);
                }
            }


            Console.ReadKey();
        }
    }
}
