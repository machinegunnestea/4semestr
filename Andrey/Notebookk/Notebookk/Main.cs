using AdoData;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EntityData;
using System.Linq;

namespace Notebookk
{
    public partial class Main : Form
    {
        public List<NotebookModel> notebooks;
        AdoMSSQLRepository adoMSSQLRepository = new AdoMSSQLRepository();
        AdoSQLiteRepository adoSQLiteRepository = new AdoSQLiteRepository();
        EntityMSSQLRepository entityMSSQLRepository = new EntityMSSQLRepository();
        EntitySQLiteRepository entitySQLiteRepository = new EntitySQLiteRepository();

        int repositoryId = 0;
        public Main()
        {
            InitializeComponent();
        }
        private void СompletionDateGridViewByCollection()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = notebooks;
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Create create = new Create();
            create.ShowDialog();
            if (create.notebook != null)
            {
                notebooks.Add(create.notebook);
                СompletionDateGridViewByCollection();
            }
        }

        private void mSSQLADOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var temp = new List<AdoData.Notebook>();
            foreach (var notebook in notebooks)
            {
                temp.Add(new AdoData.Notebook
                {
                    Day = notebook.Day,
                    Time = notebook.Time,
                    Event= notebook.Event,
                    Name = notebook.Name,
                    Number = notebook.Number
                });
            }
            adoMSSQLRepository.Save(temp);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {
                Delete delete = new Delete(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[1].Value), dataGridView1.SelectedRows[0].Cells[2].Value.ToString(),
                    dataGridView1.SelectedRows[0].Cells[3].Value.ToString(), dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
                delete.ShowDialog();
                if (delete.del == true)
                {
                    var del = notebooks.FirstOrDefault(x => x.Event == dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                    notebooks.Remove(del);
                }
                СompletionDateGridViewByCollection();
            }
            else
            {
                MessageBox.Show("Ничего не выбрано!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {
                Update update = new Update(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[1].Value), dataGridView1.SelectedRows[0].Cells[2].Value.ToString(),
                    dataGridView1.SelectedRows[0].Cells[3].Value.ToString(), dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
                update.ShowDialog();
                if (update.up == true)
                {
                    var up = notebooks.FirstOrDefault(x => x.Event == dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                    notebooks.Remove(up);
                    notebooks.Add(update.notebook);

                }
                СompletionDateGridViewByCollection();
            }
            else
            {
                MessageBox.Show("Ничего не выбрано!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NotebookManager manager = new NotebookManager(notebooks);
            notebooks = manager.Sort();
            СompletionDateGridViewByCollection();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NotebookManager manager = new NotebookManager(notebooks);
            notebooks = manager.Find(textBox2.Text);
            if (textBox2.Text == "")
                mSSQLADOToolStripMenuItem_Click(sender, e);

            СompletionDateGridViewByCollection();
        }

        private void mSSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            repositoryId = (int)Enums.AdoMSSQL;
            var model = adoMSSQLRepository.GetAll().Select(x => new NotebookModel
            {
                Day = x.Day,
                Time = x.Time,
                Event = x.Event,
                Name = x.Name,
                Number = x.Number
            });
            notebooks = model.ToList();
            СompletionDateGridViewByCollection();
        }

        private void sQLiteADOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            repositoryId = (int)Enums.AdoSQLite;
            var model = adoSQLiteRepository.GetAll().Select(x => new NotebookModel
            {
                Day = x.Day,
                Time = x.Time,
                Event = x.Event,
                Name = x.Name,
                Number = x.Number
            });
            notebooks = model.ToList();
            СompletionDateGridViewByCollection();
        }

        private void mSSQLEntityToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            repositoryId = (int)Enums.EntityMSSQL;
            var model = entityMSSQLRepository.GetAll().Select(x => new NotebookModel
            {
                Day = x.Day,
                Time = x.Time,
                Event = x.Event,
                Name = x.Name,
                Number = x.Number
            });
            notebooks = model.ToList();
            СompletionDateGridViewByCollection();
        }

        private void sQLiteEntityToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            repositoryId = (int)Enums.EntitySQLite;
            var model = entitySQLiteRepository.GetAll().Select(x => new NotebookModel
            {
                Day = x.Day,
                Time = x.Time,
                Event = x.Event,
                Name = x.Name,
                Number = x.Number
            });
            notebooks = model.ToList();
            СompletionDateGridViewByCollection();
        }

        private void xMLToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void jsonToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (repositoryId)
            {
                case 1:
                    mSSQLADOToolStripMenuItem_Click(sender, e);
                    break;
                case 2:
                    sQLiteADOToolStripMenuItem_Click(sender, e);
                    break;
                case 3:
                    mSSQLEntityToolStripMenuItem_Click(sender, e);
                    break;
                case 4:
                    sQLiteEntityToolStripMenuItem_Click(sender, e);
                    break;
                case 5:
                    xMLToolStripMenuItem_Click(sender, e);
                    break;
                case 6:
                    jsonToolStripMenuItem_Click(sender, e);
                    break;
                default:
                    break;
            }

        }

        private void sQLiteADOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var temp = new List<AdoData.Notebook>();
            foreach (var notebook in notebooks)
            {
                temp.Add(new AdoData.Notebook
                {
                    Day = notebook.Day,
                    Time = notebook.Time,
                    Event = notebook.Event,
                    Name = notebook.Name,
                    Number = notebook.Number
                });
            }
            adoSQLiteRepository.Save(temp);
        }

        private void mSSQLEntityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var temp = new List<EntityData.Notebook>();
            foreach (var notebook in notebooks)
            {
                temp.Add(new EntityData.Notebook
                {
                    Day = notebook.Day,
                    Time = notebook.Time,
                    Event = notebook.Event,
                    Name = notebook.Name,
                    Number = notebook.Number
                });
            }
            entityMSSQLRepository.Save(temp);
        }

        private void sQLiteEntityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var temp = new List<EntityData.Notebook>();
            foreach (var notebook in notebooks)
            {
                temp.Add(new EntityData.Notebook
                {
                    Day = notebook.Day,
                    Time = notebook.Time,
                    Event = notebook.Event,
                    Name = notebook.Name,
                    Number = notebook.Number
                });
            }
            entitySQLiteRepository.Save(temp);
        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void jsonToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
