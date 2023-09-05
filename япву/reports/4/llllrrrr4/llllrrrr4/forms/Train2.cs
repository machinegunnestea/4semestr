using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace llllrrrr4
{
    public partial class Train2 : Form
    {
        public Train2()
        {
            InitializeComponent();
        }
        public DataGridViewCell this[int row, int column] { get => dataGridView1[row, column]; set { dataGridView1[row, column] = value; } }

        private void Train2_Load(object sender, EventArgs e)
        {
            numberTextBox.Text = "Номер поезда";
            fromDestTextBox.Text = "Пункт отправления";
            toDestTextBox.Text = "Пункт назначения";
            priceTextBox.Text = "Цена за место (BYN)";
            amountOfPlacesTextBox.Text = "Количество свободных мест";
        }

        private void clear_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void prosessing_Click(object sender, EventArgs e)
        {
            Collection collection = new Collection();
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("train.dat", FileMode.OpenOrCreate))
            {
                collection.trains = (List<Train>)formatter.Deserialize(fs);
            }
            foreach (Train train in collection.trains)
            {
                dataGridView1.Rows.Add(train.NumberOfTrain, train.FromDestination, train.ToDestination, train.Price, train.AmountOfFreePlaces);
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            Collection collection = new Collection();
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                collection.Add(new Train(
                    dataGridView1.Rows[i].Cells[0].Value.ToString(),
                    dataGridView1.Rows[i].Cells[1].Value.ToString(),
                    dataGridView1.Rows[i].Cells[2].Value.ToString(),
                    Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString()),
                    Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value.ToString())));
            }
            dataGridView1.Rows.Clear();

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("train.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, collection.trains);
            }

        }

        private void decreasingPrice_Click(object sender, EventArgs e)
        {
            Collection collection = new Collection();
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                collection.Add(new Train(
                    dataGridView1.Rows[i].Cells[0].Value.ToString(),
                    dataGridView1.Rows[i].Cells[1].Value.ToString(),
                    dataGridView1.Rows[i].Cells[2].Value.ToString(),
                    Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString()),
                    Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value.ToString())));
            }
            dataGridView1.Rows.Clear();
            Train tempTrain = collection.trains[0];
            foreach (Train train1 in collection.trains)
            {
                if (train1.AmountOfFreePlaces > tempTrain.AmountOfFreePlaces)
                {
                    tempTrain = train1;
                }
            }

            foreach (Train train in collection.trains)
            {
                if (train == tempTrain)
                {
                    train.Price = Math.Round((train.Price * 0.8), 2);
                }
                dataGridView1.Rows.Add(train.NumberOfTrain, train.FromDestination, train.ToDestination, train.Price, train.AmountOfFreePlaces);
            }
        }

        private void saveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Data files(*.dat)|*.dat|All files(*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog.FileName;

            Collection collection = new Collection();
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                collection.Add(new Train(
                    dataGridView1.Rows[i].Cells[0].Value.ToString(),
                    dataGridView1.Rows[i].Cells[1].Value.ToString(),
                    dataGridView1.Rows[i].Cells[2].Value.ToString(),
                    Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString()),
                    Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value.ToString())));
            }
            dataGridView1.Rows.Clear();

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, collection.trains);
            }

        }

        private void prosessingFrom_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Data files(*.dat)|*.dat|All files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string fileName = openFileDialog.FileName;
            Collection collection = new Collection();
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {

                collection.trains = (List<Train>)formatter.Deserialize(fs);
            }
            foreach (Train train in collection.trains)
            {
                dataGridView1.Rows.Add(train.NumberOfTrain, train.FromDestination, train.ToDestination, train.Price, train.AmountOfFreePlaces);
            }
        }

        private void adding_Click(object sender, EventArgs e)
        {
            string numberOfTrain = number.Text;
            string fromDestination = fromDest.Text;
            string toDestination = toDest.Text;
            double priceOf = Math.Round((Convert.ToDouble(price.Text)), 2);
            int places = Convert.ToInt32(amountOfPlaces.Text);
            dataGridView1.Rows.Add(numberOfTrain, fromDestination, toDestination,
                 priceOf, places);
            number.Clear();
            fromDest.Clear();
            toDest.Clear();
            price.Clear();
            amountOfPlaces.Clear();


            Collection collection = new Collection();
            Train train = new Train(numberOfTrain, fromDestination, toDestination,
                priceOf, places);
            collection.Add(train);
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.Rows.RemoveAt(index);

        }
    }
}
