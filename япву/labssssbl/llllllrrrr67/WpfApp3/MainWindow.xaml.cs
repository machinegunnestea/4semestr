using System.Collections.Generic;
using System.Linq;
using System.Windows;
using lab6.AdoDataAccess;
using lab6.EntityDataAccess2;
using lab6.FileDataAccess;
namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<GazetterModel> gazetters;
        GazetterAdoMSSQLRepository gazetterAdoMSSQLRepository = new GazetterAdoMSSQLRepository();
        GazetterAdoSQLiteRepository gazetterAdoSQLiteRepository = new GazetterAdoSQLiteRepository();
        GazetterEntityMSSQLRepository gazetterEntityMSSQLRepository = new GazetterEntityMSSQLRepository();
        GazetterEntitySQLiteRepository gazetterEntitySQLiteRepository = new GazetterEntitySQLiteRepository();
        XMLManager gazetterXMLRepository = new XMLManager();
        JsonManager gazetterJsonRepository = new JsonManager();
        private string nameBase;
        int repositoryId = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void СompletionDateGridViewByCollection()
        {
            dataGrid1.ItemsSource = null;
            dataGrid1.ItemsSource = gazetters;
        }
        private void mSSqlToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            label1.Content = "MSSQL";
            repositoryId = (int)Enums.AdoMSSQL;
            var model = gazetterAdoMSSQLRepository.GetAll().Select(x => new GazetterModel
            {
                Country = x.Country,
                Square = x.Square,
                Population = x.Population,
                Continent = x.Continent,
                Capital = x.Capital
            });
            gazetters = model.ToList();
            СompletionDateGridViewByCollection();
        }
        private void sQLiteToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            label1.Content = "SQLite";
            repositoryId = (int)Enums.AdoSQLite;
            var model = gazetterAdoSQLiteRepository.GetAll().Select(x => new GazetterModel
            {
                Country = x.Country,
                Square = x.Square,
                Population = x.Population,
                Continent = x.Continent,
                Capital = x.Capital
            });
            gazetters = model.ToList();
            СompletionDateGridViewByCollection();
        }
        private void mSSQLEntityToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            label1.Content = "MSSQL(Entity)";
            repositoryId = (int)Enums.EntityMSSQL;
            var model = gazetterEntityMSSQLRepository.GetAll().Select(x => new GazetterModel
            {
                Country = x.Country,
                Square = x.Square,
                Population = x.Population,
                Continent = x.Continent,
                Capital = x.Capital
            });
            gazetters = model.ToList();
            СompletionDateGridViewByCollection();
        }

        private void sQLiteEntityToolStripMenuItem_Clic(object sender, RoutedEventArgs e)
        {
            label1.Content = "SQLite(Entity)";
            repositoryId = (int)Enums.EntitySQLite;
            var model = gazetterEntitySQLiteRepository.GetAll().Select(x => new GazetterModel
            {
                Country = x.Country,
                Square = x.Square,
                Population = x.Population,
                Continent = x.Continent,
                Capital = x.Capital
            });
        }
        private void xMLToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            label1.Content = "XML";
            repositoryId = (int)Enums.XML;
            var model = gazetterXMLRepository.GetAll().Select(x => new GazetterModel
            {
                Country = x.Country,
                Square = x.Square,
                Population = x.Population,
                Continent = x.Continent,
                Capital = x.Capital
            });
            gazetters = model.ToList();
            СompletionDateGridViewByCollection();
        }
        private void jSONToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            label1.Content = "JSON";
            repositoryId = (int)Enums.Json;
            var model = gazetterJsonRepository.GetAll().Select(x => new GazetterModel
            {
                Country = x.Country,
                Square = x.Square,
                Population = x.Population,
                Continent = x.Continent,
                Capital = x.Capital
            });
            gazetters = model.ToList();
            СompletionDateGridViewByCollection();
        }
        private void mSSQLToolStripMenuItem1_Click(object sender, RoutedEventArgs e)
        {
            var temp = new List<lab6.AdoDataAccess.Gazetter>();
            foreach (var gazetter in gazetters)
            {
                temp.Add(new lab6.AdoDataAccess.Gazetter
                {
                    Country = gazetter.Country,
                    Square = gazetter.Square,
                    Population = gazetter.Population,
                    Continent = gazetter.Continent,
                    Capital = gazetter.Capital

                });
            }
            gazetterAdoMSSQLRepository.Save(temp);
        }
        private void sQLiteToolStripMenuItem1_Click(object sender, RoutedEventArgs e)
        {
            var temp = new List<lab6.AdoDataAccess.Gazetter>();
            foreach (var gazetter in gazetters)
            {
                temp.Add(new lab6.AdoDataAccess.Gazetter
                {
                    Country = gazetter.Country,
                    Square = gazetter.Square,
                    Population = gazetter.Population,
                    Continent = gazetter.Continent,
                    Capital = gazetter.Capital
                });
            }
            gazetterAdoSQLiteRepository.Save(temp);
        }
        private void mSSQLEntityToolStripMenuItem1_Click(object sender, RoutedEventArgs e)
        {
            var temp = new List<lab6.EntityDataAccess2.Gazetter>();
            foreach (var gazetter in gazetters)
            {
                temp.Add(new lab6.EntityDataAccess2.Gazetter
                {
                    Country = gazetter.Country,
                    Square = gazetter.Square,
                    Population = gazetter.Population,
                    Continent = gazetter.Continent,
                    Capital = gazetter.Capital
                });
            }
            gazetterEntityMSSQLRepository.Save(temp);
        }
        private void sQLiteEntityToolStripMenuItem1_Click(object sender, RoutedEventArgs e)
        {
            var temp = new List<lab6.EntityDataAccess2.Gazetter>();
            foreach (var gazetter in gazetters)
            {
                temp.Add(new lab6.EntityDataAccess2.Gazetter
                {
                    Country = gazetter.Country,
                    Square = gazetter.Square,
                    Population = gazetter.Population,
                    Continent = gazetter.Continent,
                    Capital = gazetter.Capital
                });
            }

            gazetterEntitySQLiteRepository.Save(temp);
        }

        private void xMLToolStripMenuItem1_Click(object sender, RoutedEventArgs e)
        {
            var temp = new List<lab6.FileDataAccess.Gazetter>();
            foreach (var gazetter in gazetters)
            {
                temp.Add(new lab6.FileDataAccess.Gazetter
                {
                    Country = gazetter.Country,
                    Square = gazetter.Square,
                    Population = gazetter.Population,
                    Continent = gazetter.Continent,
                    Capital = gazetter.Capital
                });
            }
            gazetterXMLRepository.Save(temp);
        }

        private void jSONToolStripMenuItem1_Click(object sender, RoutedEventArgs e)
        {
            var temp = new List<lab6.FileDataAccess.Gazetter>();
            foreach (var gazetter in gazetters)
            {
                temp.Add(new lab6.FileDataAccess.Gazetter
                {
                    Country = gazetter.Country,
                    Square = gazetter.Square,
                    Population = gazetter.Population,
                    Continent = gazetter.Continent,
                    Capital = gazetter.Capital
                });
            }
            gazetterJsonRepository.Save(temp);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            switch (repositoryId)
            {
                case 1:
                    mSSQLToolStripMenuItem1_Click(sender, e);
                    break;
                case 2:
                    sQLiteToolStripMenuItem1_Click(sender, e);
                    break;
                case 3:
                    mSSQLEntityToolStripMenuItem1_Click(sender, e);
                    break;
                case 4:
                    sQLiteEntityToolStripMenuItem1_Click(sender, e);
                    break;
                case 5:
                    xMLToolStripMenuItem1_Click(sender, e);
                    break;
                case 6:
                    jSONToolStripMenuItem1_Click(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Create create = new Create();
            if (create.ShowDialog() == true)
            {
                if (gazetters.Any(gazetter => gazetter.Country.ToLower() == CreatingData.Country.ToLower()))
                {
                    MessageBox.Show("Страна уже существует.");
                    return;
                }
                gazetters.Add(new GazetterModel
                {
                    Country = CreatingData.Country,
                    Square = CreatingData.Square,
                    Population = CreatingData.Population,
                    Continent = CreatingData.Continent,
                    Capital = CreatingData.Capital
                });
                СompletionDateGridViewByCollection();
            }
        }

        //private void button3_Click(object sender, RoutedEventArgs e)
        //{
        //    Delete delete = new Delete();
        //    if (delete.ShowDialog() == true)
        //    {
        //        if (gazetters.Any(gazetter => gazetter.Capital == DeleteData.Country))
        //        {
        //            gazetters.RemoveAll(gazetter => gazetter.Capital == DeleteData.Country);
        //            СompletionDateGridViewByCollection();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Страны с введённым названием не существует.");
        //        }
        //    }
        //}

        //private void button6_Click(object sender, RoutedEventArgs e)
        //{
        //    Search search = new Search();
        //    if (search.ShowDialog() == true)
        //    {
        //        var listSearchType = new List<GazetterModel>();
        //        if (gazetters.Any(gazetter => gazetter.Capital.Contains(SearchData.CapitalPart)))
        //        {
        //            foreach (var item in gazetters)
        //            {
        //                if (item.Capital.Contains(SearchData.CapitalPart))
        //                {
        //                    listSearchType.Add(item);
        //                }
        //            }
        //            dataGrid1.ItemsSource = listSearchType;
        //            nameBase = label1.Content.ToString();
        //            label1.Content = "Результаты поиска";

        //            button7.Visibility = Visibility.Visible;
        //        }
        //    }
        //}
        private void button5_Click(object sender, RoutedEventArgs e)
        {
            button7.Visibility = Visibility.Hidden;
            gazetters.Clear();
            label1.Content = "Загрузите данные";
            dataGrid1.ItemsSource = null;
        }
        private void button7_Click(object sender, RoutedEventArgs e)
        {
            label1.Content = nameBase;
            dataGrid1.ItemsSource = gazetters;
            button7.Visibility = Visibility.Hidden;
        }
    }
}
