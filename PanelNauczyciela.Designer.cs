namespace DziennikElektroniczny
{
    partial class PanelNauczyciela
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
            this.klasaComboBox = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.przedmiotComboBox = new System.Windows.Forms.ComboBox();
            this.zapisOcenyButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(432, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Klasa";
            // 
            // klasaComboBox
            // 
            this.klasaComboBox.FormattingEnabled = true;
            this.klasaComboBox.Location = new System.Drawing.Point(391, 34);
            this.klasaComboBox.Name = "klasaComboBox";
            this.klasaComboBox.Size = new System.Drawing.Size(121, 21);
            this.klasaComboBox.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(778, 573);
            this.dataGridView1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Przedmiot";
            // 
            // przedmiotComboBox
            // 
            this.przedmiotComboBox.FormattingEnabled = true;
            this.przedmiotComboBox.Location = new System.Drawing.Point(85, 34);
            this.przedmiotComboBox.Name = "przedmiotComboBox";
            this.przedmiotComboBox.Size = new System.Drawing.Size(121, 21);
            this.przedmiotComboBox.TabIndex = 4;
            // 
            // zapisOcenyButton
            // 
            this.zapisOcenyButton.Location = new System.Drawing.Point(570, 32);
            this.zapisOcenyButton.Name = "zapisOcenyButton";
            this.zapisOcenyButton.Size = new System.Drawing.Size(150, 23);
            this.zapisOcenyButton.TabIndex = 5;
            this.zapisOcenyButton.Text = "Zapisz oceny";
            this.zapisOcenyButton.UseVisualStyleBackColor = true;
            this.zapisOcenyButton.Click += new System.EventHandler(this.zapisOcenyButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Wyloguj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PanelNauczyciela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 635);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zapisOcenyButton);
            this.Controls.Add(this.przedmiotComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.klasaComboBox);
            this.Controls.Add(this.label1);
            this.Name = "PanelNauczyciela";
            this.Text = "PanelNauczyciela";
            this.Load += new System.EventHandler(this.PanelNauczyciela_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox klasaComboBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox przedmiotComboBox;
        private System.Windows.Forms.Button zapisOcenyButton;
        private System.Windows.Forms.Button button1;
    }
}