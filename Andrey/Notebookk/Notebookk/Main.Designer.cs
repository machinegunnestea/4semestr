
namespace Notebookk
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mSSQLADOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLiteADOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mSSQLEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLiteEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mSSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLiteADOToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mSSQLEntityToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLiteEntityToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.jsonToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(512, 34);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(122, 20);
            this.textBox2.TabIndex = 17;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(525, 58);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(96, 22);
            this.button5.TabIndex = 16;
            this.button5.Text = "Поиск";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(354, 32);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(110, 37);
            this.button4.TabIndex = 15;
            this.button4.Text = "Сортировка";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(240, 32);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 37);
            this.button3.TabIndex = 14;
            this.button3.Text = "Изменить выбранный";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(126, 32);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 37);
            this.button2.TabIndex = 13;
            this.button2.Text = "Удалить выбранный";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 32);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 37);
            this.button1.TabIndex = 12;
            this.button1.Text = "добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 85);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(635, 359);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(659, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem,
            this.открытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mSSQLADOToolStripMenuItem,
            this.sQLiteADOToolStripMenuItem,
            this.mSSQLEntityToolStripMenuItem,
            this.sQLiteEntityToolStripMenuItem,
            this.xMLToolStripMenuItem,
            this.jsonToolStripMenuItem});
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как...";
            // 
            // mSSQLADOToolStripMenuItem
            // 
            this.mSSQLADOToolStripMenuItem.Name = "mSSQLADOToolStripMenuItem";
            this.mSSQLADOToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mSSQLADOToolStripMenuItem.Text = "MSSQL(ADO)";
            this.mSSQLADOToolStripMenuItem.Click += new System.EventHandler(this.mSSQLADOToolStripMenuItem_Click);
            // 
            // sQLiteADOToolStripMenuItem
            // 
            this.sQLiteADOToolStripMenuItem.Name = "sQLiteADOToolStripMenuItem";
            this.sQLiteADOToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sQLiteADOToolStripMenuItem.Text = "SQLite(ADO)";
            this.sQLiteADOToolStripMenuItem.Click += new System.EventHandler(this.sQLiteADOToolStripMenuItem_Click);
            // 
            // mSSQLEntityToolStripMenuItem
            // 
            this.mSSQLEntityToolStripMenuItem.Name = "mSSQLEntityToolStripMenuItem";
            this.mSSQLEntityToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mSSQLEntityToolStripMenuItem.Text = "MSSQL(Entity)";
            this.mSSQLEntityToolStripMenuItem.Click += new System.EventHandler(this.mSSQLEntityToolStripMenuItem_Click);
            // 
            // sQLiteEntityToolStripMenuItem
            // 
            this.sQLiteEntityToolStripMenuItem.Name = "sQLiteEntityToolStripMenuItem";
            this.sQLiteEntityToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sQLiteEntityToolStripMenuItem.Text = "SQLite(Entity)";
            this.sQLiteEntityToolStripMenuItem.Click += new System.EventHandler(this.sQLiteEntityToolStripMenuItem_Click);
            // 
            // xMLToolStripMenuItem
            // 
            this.xMLToolStripMenuItem.Name = "xMLToolStripMenuItem";
            this.xMLToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.xMLToolStripMenuItem.Text = "XML";
            this.xMLToolStripMenuItem.Click += new System.EventHandler(this.xMLToolStripMenuItem_Click);
            // 
            // jsonToolStripMenuItem
            // 
            this.jsonToolStripMenuItem.Name = "jsonToolStripMenuItem";
            this.jsonToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.jsonToolStripMenuItem.Text = "Json";
            this.jsonToolStripMenuItem.Click += new System.EventHandler(this.jsonToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mSSQLToolStripMenuItem,
            this.sQLiteADOToolStripMenuItem1,
            this.mSSQLEntityToolStripMenuItem1,
            this.sQLiteEntityToolStripMenuItem1,
            this.xMLToolStripMenuItem1,
            this.jsonToolStripMenuItem1});
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            // 
            // mSSQLToolStripMenuItem
            // 
            this.mSSQLToolStripMenuItem.Name = "mSSQLToolStripMenuItem";
            this.mSSQLToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mSSQLToolStripMenuItem.Text = "MSSQL(ADO)";
            this.mSSQLToolStripMenuItem.Click += new System.EventHandler(this.mSSQLToolStripMenuItem_Click);
            // 
            // sQLiteADOToolStripMenuItem1
            // 
            this.sQLiteADOToolStripMenuItem1.Name = "sQLiteADOToolStripMenuItem1";
            this.sQLiteADOToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.sQLiteADOToolStripMenuItem1.Text = "SQLite(ADO)";
            this.sQLiteADOToolStripMenuItem1.Click += new System.EventHandler(this.sQLiteADOToolStripMenuItem1_Click);
            // 
            // mSSQLEntityToolStripMenuItem1
            // 
            this.mSSQLEntityToolStripMenuItem1.Name = "mSSQLEntityToolStripMenuItem1";
            this.mSSQLEntityToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.mSSQLEntityToolStripMenuItem1.Text = "MSSQL(Entity)";
            this.mSSQLEntityToolStripMenuItem1.Click += new System.EventHandler(this.mSSQLEntityToolStripMenuItem1_Click);
            // 
            // sQLiteEntityToolStripMenuItem1
            // 
            this.sQLiteEntityToolStripMenuItem1.Name = "sQLiteEntityToolStripMenuItem1";
            this.sQLiteEntityToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.sQLiteEntityToolStripMenuItem1.Text = "SQLite(Entity)";
            this.sQLiteEntityToolStripMenuItem1.Click += new System.EventHandler(this.sQLiteEntityToolStripMenuItem1_Click);
            // 
            // xMLToolStripMenuItem1
            // 
            this.xMLToolStripMenuItem1.Name = "xMLToolStripMenuItem1";
            this.xMLToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.xMLToolStripMenuItem1.Text = "XML";
            this.xMLToolStripMenuItem1.Click += new System.EventHandler(this.xMLToolStripMenuItem1_Click);
            // 
            // jsonToolStripMenuItem1
            // 
            this.jsonToolStripMenuItem1.Name = "jsonToolStripMenuItem1";
            this.jsonToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.jsonToolStripMenuItem1.Text = "Json";
            this.jsonToolStripMenuItem1.Click += new System.EventHandler(this.jsonToolStripMenuItem1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 456);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Main";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mSSQLADOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sQLiteADOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mSSQLEntityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sQLiteEntityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jsonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mSSQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sQLiteADOToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mSSQLEntityToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sQLiteEntityToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem xMLToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem jsonToolStripMenuItem1;
    }
}

