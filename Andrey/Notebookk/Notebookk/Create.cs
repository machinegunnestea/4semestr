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
    public partial class Create : Form
    {
        public NotebookModel notebook = null;

        public Create()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            notebook = new NotebookModel
            {
                Day = comboBox1.Text.ToString(),
                Time = Convert.ToDateTime(textBox5.Text),
                Event = textBox6.Text.ToString(),
                Name = textBox7.Text.ToString(),
                Number = textBox9.Text.ToString()
            };
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
