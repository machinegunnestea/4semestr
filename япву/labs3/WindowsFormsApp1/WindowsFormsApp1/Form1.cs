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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MdiChildren.Count(); i++)
                MdiChildren[i].Close();
            New new1 = new New(this);
            new1.MdiParent = this;
            new1.TopLevel = false;
          
            new1.FormBorderStyle = FormBorderStyle.None;
            new1.Show();

        }
               

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
        }


        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Author me = new Author();

            me.ShowDialog();
            Show();
        }

        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Hide();
            Open open = new Open();

            open.ShowDialog();
            Show();

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MdiChildren.Count(); i++)
                MdiChildren[i].Close();
            New new1 = new New(this);
            new1.MdiParent = this;
            new1.TopLevel = false;

            new1.FormBorderStyle = FormBorderStyle.None;
            new1.Show();
        }

        private void averageLoadingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MdiChildren.Count(); i++)
                MdiChildren[i].Close();
            AvarageSalary averageSalary = new AvarageSalary(this);
            averageSalary.MdiParent = this;
            averageSalary.TopLevel = false;
            averageSalary.FormBorderStyle = FormBorderStyle.None;
            averageSalary.Show();
        }
    }
}
