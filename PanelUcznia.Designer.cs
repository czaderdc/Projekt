namespace DziennikElektroniczny
{
    partial class PanelUcznia
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.ocenaComboBox = new System.Windows.Forms.ComboBox();
            this.przedmiotComboBox = new System.Windows.Forms.ComboBox();
            this.Ocena = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1495, 442);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1586, 348);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Dodaj ocene";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ocenaComboBox
            // 
            this.ocenaComboBox.FormattingEnabled = true;
            this.ocenaComboBox.Location = new System.Drawing.Point(1603, 152);
            this.ocenaComboBox.Name = "ocenaComboBox";
            this.ocenaComboBox.Size = new System.Drawing.Size(121, 21);
            this.ocenaComboBox.TabIndex = 2;
            // 
            // przedmiotComboBox
            // 
            this.przedmiotComboBox.FormattingEnabled = true;
            this.przedmiotComboBox.Location = new System.Drawing.Point(1603, 243);
            this.przedmiotComboBox.Name = "przedmiotComboBox";
            this.przedmiotComboBox.Size = new System.Drawing.Size(121, 21);
            this.przedmiotComboBox.TabIndex = 3;
            // 
            // Ocena
            // 
            this.Ocena.AutoSize = true;
            this.Ocena.Location = new System.Drawing.Point(1640, 133);
            this.Ocena.Name = "Ocena";
            this.Ocena.Size = new System.Drawing.Size(39, 13);
            this.Ocena.TabIndex = 4;
            this.Ocena.Text = "Ocena";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1629, 227);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Przedmiot";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(24, 476);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(269, 191);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // PanelUcznia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Ocena);
            this.Controls.Add(this.przedmiotComboBox);
            this.Controls.Add(this.ocenaComboBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "PanelUcznia";
            this.Text = "PanelUcznia";
            this.Load += new System.EventHandler(this.PanelUcznia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox ocenaComboBox;
        private System.Windows.Forms.ComboBox przedmiotComboBox;
        private System.Windows.Forms.Label Ocena;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}