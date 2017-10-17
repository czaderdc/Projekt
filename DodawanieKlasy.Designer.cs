namespace DziennikElektroniczny
{
    partial class DodawanieKlasy
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
            this.label1 = new System.Windows.Forms.Label();
            this.nazwaKlasyTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listaKlasListBox = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.listaPrzedmiotowListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa Klasy";
            // 
            // nazwaKlasyTextBox
            // 
            this.nazwaKlasyTextBox.Location = new System.Drawing.Point(41, 78);
            this.nazwaKlasyTextBox.Name = "nazwaKlasyTextBox";
            this.nazwaKlasyTextBox.Size = new System.Drawing.Size(100, 20);
            this.nazwaKlasyTextBox.TabIndex = 1;
            this.nazwaKlasyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lista Klas";
            // 
            // listaKlasListBox
            // 
            this.listaKlasListBox.FormattingEnabled = true;
            this.listaKlasListBox.Location = new System.Drawing.Point(32, 262);
            this.listaKlasListBox.Name = "listaKlasListBox";
            this.listaKlasListBox.Size = new System.Drawing.Size(120, 186);
            this.listaKlasListBox.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Dodaj klase";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(383, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(485, 533);
            this.dataGridView1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Lista Przedmiotów";
            // 
            // listaPrzedmiotowListBox
            // 
            this.listaPrzedmiotowListBox.FormattingEnabled = true;
            this.listaPrzedmiotowListBox.Location = new System.Drawing.Point(239, 262);
            this.listaPrzedmiotowListBox.Name = "listaPrzedmiotowListBox";
            this.listaPrzedmiotowListBox.Size = new System.Drawing.Size(120, 186);
            this.listaPrzedmiotowListBox.TabIndex = 8;
            // 
            // DodawanieKlasy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 581);
            this.Controls.Add(this.listaPrzedmiotowListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listaKlasListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nazwaKlasyTextBox);
            this.Controls.Add(this.label1);
            this.Name = "DodawanieKlasy";
            this.Text = "DodawanieKlasy";
            this.Load += new System.EventHandler(this.DodawanieKlasy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nazwaKlasyTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listaKlasListBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listaPrzedmiotowListBox;
    }
}