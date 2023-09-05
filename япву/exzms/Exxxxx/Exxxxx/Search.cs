using EXxxLib.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
namespace Exxxxx
{

    public partial class Search : Form
    {
        private readonly BindingList<Dog> data = new BindingList<Dog>();
        private readonly BindingSource source = new BindingSource();

        public Search(IEnumerable<Dog> dogs)
        {
            data = new BindingList<Dog>(dogs.ToList());
            InitializeComponent();
        }

        private void Search_Load(object sender, EventArgs e)
        {

        }
        public Search(List<Dog> dogs)
        {
            var searchResult = dogs.Where(x => x.Height < 50).GroupBy(x => x.BreedId).ToList();
            List<List<Dog>> resultDogs = new List<List<Dog>>();
            searchResult.ForEach(item =>
            {
                resultDogs.Add(item.ToList());
            });
            resultDogs.ForEach(x =>
            {
                x.Sort((Dog x, Dog y) => -1 * x.Height.CompareTo(y.Height));
                x.ForEach(dog => data.Add(dog));
            });

            InitializeComponent();
            InitializeTable(dataGridView1);
        }

        private void InitializeTable(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = true;

            source.DataSource = data;
            dataGrid.DataSource = source;

            dataGrid.Columns[0].HeaderText = "Порода";
            dataGrid.Columns[1].HeaderText = "Кличка";
            dataGrid.Columns[2].HeaderText = "Высота";

        }

    }
}
