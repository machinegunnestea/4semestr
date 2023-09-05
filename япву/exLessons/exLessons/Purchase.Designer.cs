namespace exLessons
{
    partial class Purchase
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
            this.Information = new System.Windows.Forms.DataGridView();
            this.SortInformation = new System.Windows.Forms.DataGridView();
            this.ExpirationBtton = new System.Windows.Forms.Button();
            this.SortButton = new System.Windows.Forms.Button();
            this.SummaButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Information)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SortInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // Information
            // 
            this.Information.AllowUserToAddRows = false;
            this.Information.BackgroundColor = System.Drawing.Color.LavenderBlush;
            this.Information.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Information.Location = new System.Drawing.Point(38, 25);
            this.Information.Name = "Information";
            this.Information.RowHeadersVisible = false;
            this.Information.RowTemplate.Height = 25;
            this.Information.Size = new System.Drawing.Size(725, 188);
            this.Information.TabIndex = 0;
            this.Information.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Information_CellClick);
            // 
            // SortInformation
            // 
            this.SortInformation.AllowUserToAddRows = false;
            this.SortInformation.BackgroundColor = System.Drawing.Color.LavenderBlush;
            this.SortInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SortInformation.Location = new System.Drawing.Point(38, 332);
            this.SortInformation.Name = "SortInformation";
            this.SortInformation.RowHeadersVisible = false;
            this.SortInformation.RowTemplate.Height = 25;
            this.SortInformation.Size = new System.Drawing.Size(725, 188);
            this.SortInformation.TabIndex = 1;
            this.SortInformation.Visible = false;
            // 
            // ExpirationBtton
            // 
            this.ExpirationBtton.BackColor = System.Drawing.Color.SeaShell;
            this.ExpirationBtton.Location = new System.Drawing.Point(121, 257);
            this.ExpirationBtton.Name = "ExpirationBtton";
            this.ExpirationBtton.Size = new System.Drawing.Size(139, 32);
            this.ExpirationBtton.TabIndex = 2;
            this.ExpirationBtton.Text = "Search";
            this.ExpirationBtton.UseVisualStyleBackColor = false;
            this.ExpirationBtton.Click += new System.EventHandler(this.ExpirationBtton_Click);
            // 
            // SortButton
            // 
            this.SortButton.BackColor = System.Drawing.Color.SeaShell;
            this.SortButton.Location = new System.Drawing.Point(340, 257);
            this.SortButton.Name = "SortButton";
            this.SortButton.Size = new System.Drawing.Size(139, 32);
            this.SortButton.TabIndex = 3;
            this.SortButton.Text = "Sort";
            this.SortButton.UseVisualStyleBackColor = false;
            this.SortButton.Click += new System.EventHandler(this.SortButton_Click);
            // 
            // SummaButton
            // 
            this.SummaButton.BackColor = System.Drawing.Color.SeaShell;
            this.SummaButton.Location = new System.Drawing.Point(556, 257);
            this.SummaButton.Name = "SummaButton";
            this.SummaButton.Size = new System.Drawing.Size(139, 32);
            this.SummaButton.TabIndex = 4;
            this.SummaButton.Text = "Union";
            this.SummaButton.UseVisualStyleBackColor = false;
            this.SummaButton.Click += new System.EventHandler(this.SummaButton_Click);
            // 
            // Purchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(811, 532);
            this.Controls.Add(this.SummaButton);
            this.Controls.Add(this.SortButton);
            this.Controls.Add(this.ExpirationBtton);
            this.Controls.Add(this.SortInformation);
            this.Controls.Add(this.Information);
            this.Name = "Purchase";
            this.Text = "Purchase";
            this.Load += new System.EventHandler(this.Purchase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Information)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SortInformation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView Information;
        private DataGridView SortInformation;
        private Button ExpirationBtton;
        private Button SortButton;
        private Button SummaButton;
    }
}