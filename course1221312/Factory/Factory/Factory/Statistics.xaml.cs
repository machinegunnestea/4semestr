using Factory.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Factory.Data.Models;

namespace Factory
{

    public partial class Statistics : Window
    {
        private readonly DataLayer data;
        private  IEnumerable<ProductItem> products;
        public Statistics()
        {
            data = GetDb();
            InitializeComponent();
        }

        public DataLayer GetDb()
        {
            return DataLayer.Sql();
        }
        private class ProductItem
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public List<ProductPlan> Plans { get; set; }
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var titleOfProducts = data.Products.GetAll();

           
        }

        private void Chart_Loaded(object sender, RoutedEventArgs e)
        {
            products = data.Products.GetAll().Select(x => new ProductItem()
            {
                Name = x.Name,
                ID=x.Id,
                Plans=x.Plans
                

            });

            var titleOfProducts = products.ToList();
            string[] test = new string[titleOfProducts.Count];
            double[] count = new double[titleOfProducts.Count];
            double[] positions = new double[titleOfProducts.Count];

            for (int i = 0; i < test.Length; i++)
            {
                test[i] = titleOfProducts[i].Name;
                positions[i] = i;
                if (titleOfProducts.First(x=>x.Name==test[i]).Plans.Count != 0)
                {
                    count[i] = titleOfProducts[i].Plans[0].Count;
                }
            }
            double[] values = count;
            string[] labels = test;

            Chart.Plot.AddBar(values, positions);
            Chart.Plot.XTicks(positions, labels);
            Chart.Plot.SetAxisLimits(yMin: 0);

            Chart.Plot.SaveFig("bar_labels.png");

            Chart.Refresh();
        }
    }
}
