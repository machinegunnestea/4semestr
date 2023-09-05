
namespace Exxxxx
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DogNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DogBreedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DogHeightColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AddDogButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ChangeDogButton = new System.Windows.Forms.Button();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.SearchUnderFiftyButton = new System.Windows.Forms.Button();
            this.SearchHeightButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.FindAverageHeightButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.SerializeButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DogNameColumn,
            this.DogBreedColumn,
            this.DogHeightColumn});
            this.dataGridView1.Location = new System.Drawing.Point(35, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(532, 518);
            this.dataGridView1.TabIndex = 1;
            // 
            // DogNameColumn
            // 
            this.DogNameColumn.HeaderText = "Кличка";
            this.DogNameColumn.Name = "DogNameColumn";
            this.DogNameColumn.ReadOnly = true;
            // 
            // DogBreedColumn
            // 
            this.DogBreedColumn.HeaderText = "Порода";
            this.DogBreedColumn.Name = "DogBreedColumn";
            this.DogBreedColumn.ReadOnly = true;
            // 
            // DogHeightColumn
            // 
            this.DogHeightColumn.HeaderText = "Высота";
            this.DogHeightColumn.Name = "DogHeightColumn";
            this.DogHeightColumn.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(683, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(374, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Добавление  данных о собаке";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(704, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 36);
            this.label2.TabIndex = 3;
            this.label2.Text = "Изменение роста собаки\r\n";
            // 
            // AddDogButton
            // 
            this.AddDogButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddDogButton.Location = new System.Drawing.Point(934, 97);
            this.AddDogButton.Name = "AddDogButton";
            this.AddDogButton.Size = new System.Drawing.Size(135, 45);
            this.AddDogButton.TabIndex = 10;
            this.AddDogButton.Text = "Добавить";
            this.AddDogButton.UseVisualStyleBackColor = true;
            this.AddDogButton.Click += new System.EventHandler(this.AddDogButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(643, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Порода";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(643, 86);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 8;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(643, 181);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown1.TabIndex = 14;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(643, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Высота в холке";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(643, 137);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(119, 23);
            this.textBox1.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(643, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Кличка";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(641, 299);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 23);
            this.comboBox2.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(768, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "Новый рост";
            // 
            // ChangeDogButton
            // 
            this.ChangeDogButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChangeDogButton.Location = new System.Drawing.Point(943, 287);
            this.ChangeDogButton.Name = "ChangeDogButton";
            this.ChangeDogButton.Size = new System.Drawing.Size(135, 41);
            this.ChangeDogButton.TabIndex = 17;
            this.ChangeDogButton.Text = "Изменить";
            this.ChangeDogButton.UseVisualStyleBackColor = true;
            this.ChangeDogButton.Click += new System.EventHandler(this.ChangeDogButton_Click);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(768, 300);
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(93, 23);
            this.numericUpDown2.TabIndex = 16;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(639, 282);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Собака";
            // 
            // SearchUnderFiftyButton
            // 
            this.SearchUnderFiftyButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SearchUnderFiftyButton.Location = new System.Drawing.Point(620, 352);
            this.SearchUnderFiftyButton.Name = "SearchUnderFiftyButton";
            this.SearchUnderFiftyButton.Size = new System.Drawing.Size(466, 34);
            this.SearchUnderFiftyButton.TabIndex = 20;
            this.SearchUnderFiftyButton.Text = "Вывод списка собак ниже 50";
            this.SearchUnderFiftyButton.UseVisualStyleBackColor = true;
            this.SearchUnderFiftyButton.Click += new System.EventHandler(this.SearchUnderFiftyButton_Click);
            // 
            // SearchHeightButton
            // 
            this.SearchHeightButton.Location = new System.Drawing.Point(620, 405);
            this.SearchHeightButton.Name = "SearchHeightButton";
            this.SearchHeightButton.Size = new System.Drawing.Size(210, 34);
            this.SearchHeightButton.TabIndex = 21;
            this.SearchHeightButton.Text = "Поиск по росту";
            this.SearchHeightButton.UseVisualStyleBackColor = true;
            this.SearchHeightButton.Click += new System.EventHandler(this.SearchHeightButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(870, 415);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 15);
            this.label9.TabIndex = 23;
            this.label9.Text = "Введите рост";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(966, 413);
            this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown3.TabIndex = 22;
            this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(969, 461);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 15);
            this.label8.TabIndex = 28;
            this.label8.Text = "Результат";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(969, 479);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 27;
            // 
            // FindAverageHeightButton
            // 
            this.FindAverageHeightButton.Location = new System.Drawing.Point(822, 478);
            this.FindAverageHeightButton.Name = "FindAverageHeightButton";
            this.FindAverageHeightButton.Size = new System.Drawing.Size(75, 23);
            this.FindAverageHeightButton.TabIndex = 26;
            this.FindAverageHeightButton.Text = "Найти";
            this.FindAverageHeightButton.UseVisualStyleBackColor = true;
            this.FindAverageHeightButton.Click += new System.EventHandler(this.FindAverageHeightButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(634, 461);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 15);
            this.label10.TabIndex = 25;
            this.label10.Text = "Порода";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(634, 479);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 23);
            this.comboBox3.TabIndex = 24;
            // 
            // SerializeButton
            // 
            this.SerializeButton.Location = new System.Drawing.Point(789, 545);
            this.SerializeButton.Name = "SerializeButton";
            this.SerializeButton.Size = new System.Drawing.Size(100, 23);
            this.SerializeButton.TabIndex = 31;
            this.SerializeButton.Text = "Сериализовать";
            this.SerializeButton.UseVisualStyleBackColor = true;
            this.SerializeButton.Click += new System.EventHandler(this.SerializeButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(637, 525);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 15);
            this.label11.TabIndex = 30;
            this.label11.Text = "Порода";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(637, 546);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 23);
            this.comboBox4.TabIndex = 29;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(943, 535);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 38);
            this.button1.TabIndex = 32;
            this.button1.Text = "Диаграмма";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 595);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SerializeButton);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.FindAverageHeightButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.SearchHeightButton);
            this.Controls.Add(this.SearchUnderFiftyButton);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ChangeDogButton);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AddDogButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DogNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DogBreedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DogHeightColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddDogButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ChangeDogButton;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button SearchUnderFiftyButton;
        private System.Windows.Forms.Button SearchHeightButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button FindAverageHeightButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button SerializeButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button1;
    }
}

