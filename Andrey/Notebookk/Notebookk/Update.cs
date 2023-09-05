using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notebookk
{
    public partial class Update : Form
    {
        public bool up = false;
        public NotebookModel notebook = new NotebookModel();
        public Update(string day, DateTime time, string evvent, string name, string number)
        {
            InitializeComponent();
            comboBox1.Text = Convert.ToString(day);
            textBox5.Text = Convert.ToString(time);
            textBox6.Text = Convert.ToString(evvent);
            textBox7.Text = Convert.ToString(name);
            textBox9.Text = Convert.ToString(number);
            up = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            up = true;
            notebook.Day = comboBox1.Text;
            notebook.Time = Convert.ToDateTime(textBox5.Text);
            notebook.Event = textBox6.Text;
            notebook.Name = textBox7.Text;
            notebook.Number = textBox9.Text;
            Close();
        }
    }
}
