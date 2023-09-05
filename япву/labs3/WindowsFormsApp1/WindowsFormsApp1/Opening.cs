using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Open : Form
    {
        public Open()
        {
            InitializeComponent();
        }

        
        public DataGridViewCell this[int columIndex, int rowIndex]
        {
            get
            {
                return dataGridView1[columIndex, rowIndex];
            }
            set
            {
                dataGridView1[columIndex, rowIndex] = value;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public void Opening()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string fileName = openFileDialog.FileName;
            Collection collection = new Collection();
            File<Worker>.OutputFromFile(collection, fileName);

            foreach (Worker worker in collection.workers)
            {
                dataGridView2.Rows.Add(worker.Surname, worker.FirmName, worker.BirthDay.ToString("dd.MM.yyyy"), worker.Payment);
            }
            int count = dataGridView2.Rows.Count - 1;
            double sum = 0;

            for (int i = 0; i < count; i++)
            {
                sum += Convert.ToDouble(dataGridView2[3, i].Value.ToString());
            }
            double averageSalary = Math.Round((sum / count), 2);

            Worker workerTemp = new Worker();
            workerTemp = collection.workers[0];
            foreach (Worker worker in collection.workers)
            {
                if (worker.Age < workerTemp.Age)
                {
                    workerTemp = worker;
                }

            }
            textBox10.Text = averageSalary.ToString();
            textBox12.Text = workerTemp.Surname;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            Opening();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Open_Load(object sender, EventArgs e)
        {
            textBox9.Text = "Средняя з/п";
            textBox11.Text = "Самый молодой";
            Opening();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            Opening();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
