using EXxxLib.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EXxxLib.DB;
using System.Linq;
using System.Drawing;

namespace Exxxxx
{
    public partial class Diagramm : Form
    {
        public List<Dog> Dogs;
        public List<Breed> Breeds;
        public Diagramm()
        {
            Context context = new Context();

            InitializeComponent();
            List<Breed> breeds = context.Breed.ToList();
            List<Dog> dogs = context.Dog.ToList();
        }

        private void Diagramm_Load(object sender, EventArgs e)
        {

        }
    }


}
