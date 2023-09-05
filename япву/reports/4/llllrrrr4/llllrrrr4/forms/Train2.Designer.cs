
namespace llllrrrr4
{
    partial class Train2
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
            this.delete = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.decreasingPrice = new System.Windows.Forms.Button();
            this.saveAs = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prosessingFrom = new System.Windows.Forms.Button();
            this.prosessing = new System.Windows.Forms.Button();
            this.amountOfPlaces = new System.Windows.Forms.TextBox();
            this.toDest = new System.Windows.Forms.TextBox();
            this.number = new System.Windows.Forms.TextBox();
            this.adding = new System.Windows.Forms.Button();
            this.price = new System.Windows.Forms.TextBox();
            this.fromDest = new System.Windows.Forms.TextBox();
            this.amountOfPlacesTextBox = new System.Windows.Forms.TextBox();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.toDestTextBox = new System.Windows.Forms.TextBox();
            this.fromDestTextBox = new System.Windows.Forms.TextBox();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // delete
            // 
            this.delete.AllowDrop = true;
            this.delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delete.Location = new System.Drawing.Point(297, 618);
            this.delete.Margin = new System.Windows.Forms.Padding(2);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(131, 41);
            this.delete.TabIndex = 86;
            this.delete.Text = "delete";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // clear
            // 
            this.clear.AllowDrop = true;
            this.clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clear.Location = new System.Drawing.Point(83, 618);
            this.clear.Margin = new System.Windows.Forms.Padding(2);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(131, 41);
            this.clear.TabIndex = 85;
            this.clear.Text = "clear";
            this.clear.UseVisualStyleBackColor = false;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // decreasingPrice
            // 
            this.decreasingPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.decreasingPrice.Location = new System.Drawing.Point(373, 575);
            this.decreasingPrice.Margin = new System.Windows.Forms.Padding(2);
            this.decreasingPrice.Name = "decreasingPrice";
            this.decreasingPrice.Size = new System.Drawing.Size(167, 39);
            this.decreasingPrice.TabIndex = 84;
            this.decreasingPrice.Text = "уменьшение цены на 20% у самых свободных поездов";
            this.decreasingPrice.UseVisualStyleBackColor = true;
            this.decreasingPrice.Click += new System.EventHandler(this.decreasingPrice_Click);
            // 
            // saveAs
            // 
            this.saveAs.Location = new System.Drawing.Point(181, 575);
            this.saveAs.Margin = new System.Windows.Forms.Padding(2);
            this.saveAs.Name = "saveAs";
            this.saveAs.Size = new System.Drawing.Size(142, 39);
            this.saveAs.TabIndex = 83;
            this.saveAs.Text = "Сохранить как...";
            this.saveAs.UseVisualStyleBackColor = true;
            this.saveAs.Click += new System.EventHandler(this.saveAs_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(11, 575);
            this.save.Margin = new System.Windows.Forms.Padding(2);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(136, 39);
            this.save.TabIndex = 82;
            this.save.Text = "Сохранить";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridView1.Location = new System.Drawing.Point(24, 152);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(516, 419);
            this.dataGridView1.TabIndex = 81;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Номер поезда";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Пункт отправления";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Пункт назначения";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Цена за место";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Количество свободных мест";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // prosessingFrom
            // 
            this.prosessingFrom.Location = new System.Drawing.Point(439, 78);
            this.prosessingFrom.Margin = new System.Windows.Forms.Padding(2);
            this.prosessingFrom.Name = "prosessingFrom";
            this.prosessingFrom.Size = new System.Drawing.Size(101, 41);
            this.prosessingFrom.TabIndex = 80;
            this.prosessingFrom.Text = "Обработка\r\nиз...";
            this.prosessingFrom.UseVisualStyleBackColor = true;
            this.prosessingFrom.Click += new System.EventHandler(this.prosessingFrom_Click);
            // 
            // prosessing
            // 
            this.prosessing.Location = new System.Drawing.Point(439, 11);
            this.prosessing.Margin = new System.Windows.Forms.Padding(2);
            this.prosessing.Name = "prosessing";
            this.prosessing.Size = new System.Drawing.Size(101, 63);
            this.prosessing.TabIndex = 79;
            this.prosessing.Text = "Обработка";
            this.prosessing.UseVisualStyleBackColor = true;
            this.prosessing.Click += new System.EventHandler(this.prosessing_Click);
            // 
            // amountOfPlaces
            // 
            this.amountOfPlaces.Location = new System.Drawing.Point(233, 100);
            this.amountOfPlaces.Margin = new System.Windows.Forms.Padding(2);
            this.amountOfPlaces.Name = "amountOfPlaces";
            this.amountOfPlaces.Size = new System.Drawing.Size(90, 20);
            this.amountOfPlaces.TabIndex = 78;
            // 
            // toDest
            // 
            this.toDest.Location = new System.Drawing.Point(233, 54);
            this.toDest.Margin = new System.Windows.Forms.Padding(2);
            this.toDest.Name = "toDest";
            this.toDest.Size = new System.Drawing.Size(179, 20);
            this.toDest.TabIndex = 77;
            // 
            // number
            // 
            this.number.Location = new System.Drawing.Point(233, 9);
            this.number.Margin = new System.Windows.Forms.Padding(2);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(179, 20);
            this.number.TabIndex = 76;
            // 
            // adding
            // 
            this.adding.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.adding.Location = new System.Drawing.Point(327, 77);
            this.adding.Margin = new System.Windows.Forms.Padding(2);
            this.adding.Name = "adding";
            this.adding.Size = new System.Drawing.Size(84, 41);
            this.adding.TabIndex = 75;
            this.adding.Text = "Добавить";
            this.adding.UseVisualStyleBackColor = true;
            this.adding.Click += new System.EventHandler(this.adding_Click);
            // 
            // price
            // 
            this.price.Location = new System.Drawing.Point(233, 77);
            this.price.Margin = new System.Windows.Forms.Padding(2);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(90, 20);
            this.price.TabIndex = 74;
            // 
            // fromDest
            // 
            this.fromDest.Location = new System.Drawing.Point(233, 31);
            this.fromDest.Margin = new System.Windows.Forms.Padding(2);
            this.fromDest.Name = "fromDest";
            this.fromDest.Size = new System.Drawing.Size(179, 20);
            this.fromDest.TabIndex = 73;
            // 
            // amountOfPlacesTextBox
            // 
            this.amountOfPlacesTextBox.Location = new System.Drawing.Point(24, 100);
            this.amountOfPlacesTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.amountOfPlacesTextBox.Name = "amountOfPlacesTextBox";
            this.amountOfPlacesTextBox.Size = new System.Drawing.Size(176, 20);
            this.amountOfPlacesTextBox.TabIndex = 72;
            // 
            // priceTextBox
            // 
            this.priceTextBox.Location = new System.Drawing.Point(24, 77);
            this.priceTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(176, 20);
            this.priceTextBox.TabIndex = 71;
            // 
            // toDestTextBox
            // 
            this.toDestTextBox.Location = new System.Drawing.Point(24, 54);
            this.toDestTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.toDestTextBox.Name = "toDestTextBox";
            this.toDestTextBox.Size = new System.Drawing.Size(176, 20);
            this.toDestTextBox.TabIndex = 70;
            // 
            // fromDestTextBox
            // 
            this.fromDestTextBox.Location = new System.Drawing.Point(24, 31);
            this.fromDestTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.fromDestTextBox.Name = "fromDestTextBox";
            this.fromDestTextBox.Size = new System.Drawing.Size(176, 20);
            this.fromDestTextBox.TabIndex = 69;
            // 
            // numberTextBox
            // 
            this.numberTextBox.Location = new System.Drawing.Point(24, 9);
            this.numberTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.ReadOnly = true;
            this.numberTextBox.Size = new System.Drawing.Size(176, 20);
            this.numberTextBox.TabIndex = 68;
            // 
            // Train2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 715);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.decreasingPrice);
            this.Controls.Add(this.saveAs);
            this.Controls.Add(this.save);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.prosessingFrom);
            this.Controls.Add(this.prosessing);
            this.Controls.Add(this.amountOfPlaces);
            this.Controls.Add(this.toDest);
            this.Controls.Add(this.number);
            this.Controls.Add(this.adding);
            this.Controls.Add(this.price);
            this.Controls.Add(this.fromDest);
            this.Controls.Add(this.amountOfPlacesTextBox);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.toDestTextBox);
            this.Controls.Add(this.fromDestTextBox);
            this.Controls.Add(this.numberTextBox);
            this.Name = "Train2";
            this.Text = "Train2";
            this.Load += new System.EventHandler(this.Train2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button decreasingPrice;
        private System.Windows.Forms.Button saveAs;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button prosessingFrom;
        private System.Windows.Forms.Button prosessing;
        private System.Windows.Forms.TextBox amountOfPlaces;
        private System.Windows.Forms.TextBox toDest;
        private System.Windows.Forms.TextBox number;
        private System.Windows.Forms.Button adding;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.TextBox fromDest;
        private System.Windows.Forms.TextBox amountOfPlacesTextBox;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.TextBox toDestTextBox;
        private System.Windows.Forms.TextBox fromDestTextBox;
        private System.Windows.Forms.TextBox numberTextBox;
    }
}