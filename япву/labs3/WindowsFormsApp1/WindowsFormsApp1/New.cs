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
    public partial class New : Form
    {
        public New(Form1 ParentForm)
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void New_Load(object sender, EventArgs e)
        {
            textBox5.Text = "Фамилия:";
            textBox6.Text = "Фирма:";
            textBox7.Text = "Дата Рождения:";
            textBox9.Text = "Средняя з/п:";
            textBox11.Text = "Самый молодой:";
            textBox8.Text = "Зарплата($):";

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string surname = textBox1.Text;
            string firm = textBox2.Text;
            DateTime birth = Convert.ToDateTime(maskedTextBox2.Text);
            double money = Convert.ToDouble(textBox4.Text);
            dataGridView1.Rows.Add(surname, firm, birth, money);
            textBox1.Clear();
            textBox2.Clear(); ;
            maskedTextBox2.Clear();
            textBox4.Clear();

            Collection collection = new Collection();
            Worker worker = new Worker(surname, firm, birth, money);
            collection.Add(worker);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Collection collection = new Collection();
            File<Worker>.OutputFromFile(collection, "Rabotnik2.txt");
            foreach (Worker worker in collection.workers)
            {
                dataGridView1.Rows.Add(worker.Surname, worker.FirmName, worker.BirthDay.ToString("dd.MM.yyyy"), worker.Payment);

            }

            int count = dataGridView1.Rows.Count - 1;
            double sum = 0;

            for (int i = 0; i < count; i++)
            {
                sum += Convert.ToDouble(dataGridView1[3, i].Value.ToString());
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

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if ((Convert.ToDateTime(dataGridView1[2, i].Value) == workerTemp.BirthDay))
                {
                    dataGridView1[0, i].Style.BackColor = Color.Red;
                    dataGridView1[1, i].Style.BackColor = Color.Red;
                    dataGridView1[2, i].Style.BackColor = Color.Red;
                    dataGridView1[3, i].Style.BackColor = Color.Red;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Collection collection = new Collection();
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                collection.Add(new Worker(dataGridView1.Rows[i].Cells[0].Value.ToString(),
                    dataGridView1.Rows[i].Cells[1].Value.ToString(),
                    Convert.ToDateTime(dataGridView1.Rows[i].Cells[2].Value.ToString()),
                    Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString())));

            }
            dataGridView1.Rows.Clear();
            textBox10.Clear();
            textBox12.Clear();
            File<Worker>.WriteToFile(collection, "Rabotnik.txt");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog.FileName;

            Collection collection = new Collection();
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                collection.Add(new Worker(dataGridView1.Rows[i].Cells[0].Value.ToString(),
                    dataGridView1.Rows[i].Cells[1].Value.ToString(),
                    Convert.ToDateTime(dataGridView1.Rows[i].Cells[2].Value.ToString()),
                    Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString())));

            }
            dataGridView1.Rows.Clear();
            textBox10.Clear();
            textBox12.Clear();
            File<Worker>.WriteToFile(collection, filename);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.Rows.RemoveAt(index);
        }
    }
}
