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
    public partial class Delete : Form
    {
        public bool del = false;
        public Delete(string day, DateTime time, string evvent, string name, string number)
        {
            InitializeComponent();
            comboBox1.Text=Convert.ToString(day);
            textBox5.Text = Convert.ToString(time);
            textBox6.Text = Convert.ToString(evvent);
            textBox7.Text = Convert.ToString(name);
            textBox9.Text = Convert.ToString(number);
            del = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            del = true;
            Close();
        }
    }
}
