using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EXxxLib.Entities;
using EXxxLib.DB;
using EXxxLib.Serializers;

namespace Exxxxx
{
    public partial class MainForm : Form
    {
        public List<Dog> Dogs;
        public List<Breed> Breeds;
        public MainForm()
        {
            Dogs = DB.Dog.ReadAll();
            Breeds = DB.Breed.ReadAll();
            InitializeComponent();
            Find(Dogs, x => x.Height < 50);

      

            LoadComboBox(comboBox1, Breeds.Select(breed => breed.BreedName).ToList());
            LoadComboBox(comboBox2, Dogs.Select(dog => dog.Name).ToList());
            LoadComboBox(comboBox3, Breeds.Select(breed => breed.BreedName).ToList());
            LoadComboBox(comboBox4, Breeds.Select(breed => breed.BreedName).ToList());

        }
        private void RefreshTable()
        {
            dataGridView1.Rows.Clear();
            InitializeTable();
        }
        private void InitializeTable()
        {
            var data = from dog in Dogs
                       select new { dog.Name, dog.Breed, dog.Height };
            data.ToList().ForEach(item => dataGridView1.Rows.Add(item.Name, item.Breed, item.Height));
        }
        private void AddDogButton_Click(object sender, EventArgs e)
        {
            string dogName = textBox1.Text;
            int dogHeight = Convert.ToInt32(numericUpDown1.Value);
            Breed dogBreed = Breeds.Find(breed => breed.BreedName == comboBox1.Text);

            if (dogBreed == null)
            {
                MessageBox.Show("Выбранная порода не найдена в бд");
                return;
            }
            int dogId = 1;
            if (Dogs.Count > 0)
                dogId = Dogs.Max(dog => dog.Id) + 1;
            Dog dog = new Dog()
            {
                Id = dogId,
                Name = dogName,
                Height = dogHeight,
                BreedId = dogBreed.BreedId,
                Breed = dogBreed
            };
            try
            {
                DB.Dog.Add(dog);
                Dogs.Add(dog);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            RefreshTable();
            LoadComboBox(comboBox2, Dogs.Select(dog => dog.Id + " " + dog.Name).ToList());
        }
        private List<T> Find<T>(IEnumerable<T> data, Predicate<T> comparer)
        {
            return data.Where(x => comparer(x)).ToList();
        }
        private void LoadComboBox(ComboBox box, List<string> items)
        {
            box.Items.Clear();
            box.Items.AddRange(items.ToArray());
            if (items.Count > 0)
                box.SelectedIndex = 0;
        }

        private void ChangeDogButton_Click(object sender, EventArgs e)
        {
            string name = comboBox2.Text;
            if (name == null)
            {
                MessageBox.Show("Неверный формат названия собаки");
                return;
            }
            Dog dog = Dogs.Find(dog => dog.Name == name);
            if(dog == null)
            {
                MessageBox.Show("Не найдена собака с такой кличкой");
                return;
            }
            dog.Height = Convert.ToInt32(numericUpDown2.Value);
            try
            {
                DB.Dog.Update(dog);
                Dogs = DB.Dog.ReadAll();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            RefreshTable();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshTable();

        }

        private void SearchUnderFiftyButton_Click(object sender, EventArgs e)
        {
            new Search(Dogs).Show();
        }

        private void SearchHeightButton_Click(object sender, EventArgs e)
        {
            int inputHeight = Convert.ToInt32(numericUpDown3.Value);
            var a = Find(Dogs, x => x.Height > inputHeight);
            if (a.Count() == 0)
            {
                MessageBox.Show("Не найдено таких собак");
                return;
            }
            new Search(a).Show();
        }

        private void FindAverageHeightButton_Click(object sender, EventArgs e)
        {
            Breed breed = Breeds.Find(x => x.BreedName == comboBox3.Text);
            if (breed == null)
            {
                MessageBox.Show("Не найдена такая порода");
                return;
            }
            //
            var dogs = from dog in Dogs
                       where dog.BreedId == breed.BreedId
                       select dog;
            if (dogs.Count() == 0)
            {
                MessageBox.Show("Не найдено таких собак");
                return;
            }
            //
            textBox2.Text = dogs.Average(dog => dog.Height).ToString();

        }

        private void SerializeButton_Click(object sender, EventArgs e)
        {
            Breed breed = Breeds.Find(breed => breed.BreedName == comboBox4.Text);
            if (breed == null)
            {
                MessageBox.Show("Не найдено такой породы");
                return;
            }
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "XML files(.xml)| *.xml";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XML.Save(Dogs.Where(x => x.Breed.BreedName == breed.BreedName).ToList(), saveFileDialog1.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Diagramm diogramWindow = new Diagramm();
            diogramWindow.Show();
        }
    }
}
