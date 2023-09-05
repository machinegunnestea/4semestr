using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lecture
{
    public partial class Form1 : Form
    {
        private AbstaractPurchase[] purchase;

        public Form1()
        {
            InitializeComponent();
            dataGridView2.Visible = false;
            var commodity = new Commodity[] {
                new Commodity("Сахар", 2.69m,new DateTime(2022,6,22), 365),
                new Commodity("Хлеб", 1.09m,new DateTime(2022,6,23), 4),
                new Commodity("Йогурт", 2.15m,new DateTime(2022,6,12), 30),
                new Commodity("Йогурт", 2.15m,new DateTime(2022,6,9), 30),
                new Commodity("Курица", 9.61m, new DateTime(2022,6,18), 15),
                new Commodity("Сыр", 6.34m,new DateTime(2022,3,22), 36)
            };
            purchase = new AbstaractPurchase[]
            {
                new Discount(commodity[0],2),
                new Discount(commodity[5],1),
                new Discount(commodity[2],4),
                new AddExpense(commodity[1], 2),
                new AddExpense(commodity[3], 3),
                new AddExpense(commodity[4], 1)
            };
        }
        private void EnterInformation(DataGridView Information)
        {
            Information.ColumnCount = 5;
            Information.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Information.Columns[0].HeaderText = "Purchase";
            Information.Columns[1].HeaderText = "Price";
            Information.Columns[2].HeaderText = "Count";
            Information.Columns[3].HeaderText = "Expiration date";
            Information.Columns[4].HeaderText = "Date of manufacture";
            Information.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Information.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Information.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Information.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Information.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            EnterInformation(dataGridView1);
            EnterInformation(dataGridView2);

            foreach (var purch in purchase)
            {
                dataGridView1.Rows.Add(purch.Commodity.Name, purch.Commodity.Price.ToString(), purch.Count.ToString(),
                    purch.Commodity.DateManufacture.ToString(), purch.Commodity.ExpirationDate.ToString());
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            EnterInformation(dataGridView2);
            dataGridView2.Visible = true;
            Array.Sort(purchase);
            Array.Reverse(purchase);
            foreach (var purch in purchase)
            {
                dataGridView2.Rows.Add(purch.Commodity.Name, purch.Commodity.Price.ToString(), purch.Count.ToString(),
                    purch.Commodity.DateManufacture.ToString(), purch.Commodity.ExpirationDate.ToString());
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Type type = purchase[Index].GetType();
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            EnterInformation(dataGridView2);
            dataGridView2.Visible = true;
            var param = new Type[] { typeof(Commodity), typeof(int) };
            var vs = new object[] { purchase[Index].Commodity, 0 };
            var purchs = (AbstaractPurchase)CreateMyObject(type, param, vs);
            var query = purchase.Where(p => p.Commodity.Name == purchase[Index].Commodity.Name).ToList();
            for (int i = 0; i < query.Count; i++)
            {
                purchs = purchs + query[i];
            }
            dataGridView2.Rows.Add(purchs.Commodity.Name, purchs.Commodity.Price.ToString(), purchs.Count.ToString(),
                purchs.Commodity.DateManufacture.ToString(), purchs.Commodity.ExpirationDate.ToString());
        }
        private int Index { get; set; }
        static object CreateMyObject(Type type, Type[] types, object[] vs)
        {
            var info = type.GetConstructor(types);
            object myobj = info.Invoke(vs);
            return myobj;
        }
        private void Information_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Index = e.RowIndex;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            EnterInformation(dataGridView2);
            dataGridView2.Visible = true;
            var date = DateTime.Now;
            var query = purchase.Where(p => date <= p.Commodity.GetExpirationDate() && p.Commodity.GetExpirationDate() <= date.AddDays(7)).
                Select(p => p);
            foreach (var purch in query)
            {
                dataGridView2.Rows.Add(purch.Commodity.Name, purch.Commodity.Price.ToString(), purch.Count.ToString(),
                    purch.Commodity.DateManufacture.ToString(), purch.Commodity.ExpirationDate.ToString());
            }

        }
    }

}
