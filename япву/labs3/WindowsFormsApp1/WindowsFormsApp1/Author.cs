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
    public partial class Author : Form
    {
        public Author()
        {
            InitializeComponent();
        }

        private void Author_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("C:\\Users\\Nastya\\Desktop\\1212.jpg");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
