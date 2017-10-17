namespace DziennikElektroniczny
{
    partial class PanelAdmina
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.wyswietlUczniowButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.wyswietlNauczycieliButton = new System.Windows.Forms.Button();
            this.dodajSzkoleButton = new System.Windows.Forms.Button();
            this.wylogujButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wybierz Szkołe";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(73, 127);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // wyswietlUczniowButton
            // 
            this.wyswietlUczniowButton.Location = new System.Drawing.Point(73, 176);
            this.wyswietlUczniowButton.Name = "wyswietlUczniowButton";
            this.wyswietlUczniowButton.Size = new System.Drawing.Size(121, 23);
            this.wyswietlUczniowButton.TabIndex = 2;
            this.wyswietlUczniowButton.Text = "Wyswietl Uczniów";
            this.wyswietlUczniowButton.UseVisualStyleBackColor = true;
            this.wyswietlUczniowButton.Click += new System.EventHandler(this.wyswietlUczniowButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(219, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(548, 519);
            this.dataGridView1.TabIndex = 3;
            // 
            // wyswietlNauczycieliButton
            // 
            this.wyswietlNauczycieliButton.Location = new System.Drawing.Point(73, 224);
            this.wyswietlNauczycieliButton.Name = "wyswietlNauczycieliButton";
            this.wyswietlNauczycieliButton.Size = new System.Drawing.Size(121, 23);
            this.wyswietlNauczycieliButton.TabIndex = 4;
            this.wyswietlNauczycieliButton.Text = "Wyświetl Nauczycieli";
            this.wyswietlNauczycieliButton.UseVisualStyleBackColor = true;
            this.wyswietlNauczycieliButton.Click += new System.EventHandler(this.wyswietlNauczycieliButton_Click);
            // 
            // dodajSzkoleButton
            // 
            this.dodajSzkoleButton.Location = new System.Drawing.Point(73, 465);
            this.dodajSzkoleButton.Name = "dodajSzkoleButton";
            this.dodajSzkoleButton.Size = new System.Drawing.Size(113, 23);
            this.dodajSzkoleButton.TabIndex = 5;
            this.dodajSzkoleButton.Text = "Dodaj nową szkołę";
            this.dodajSzkoleButton.UseVisualStyleBackColor = true;
            this.dodajSzkoleButton.Click += new System.EventHandler(this.dodajSzkoleButton_Click);
            // 
            // wylogujButton
            // 
            this.wylogujButton.Location = new System.Drawing.Point(521, 569);
            this.wylogujButton.Name = "wylogujButton";
            this.wylogujButton.Size = new System.Drawing.Size(85, 23);
            this.wylogujButton.TabIndex = 6;
            this.wylogujButton.Text = "Wyloguj";
            this.wylogujButton.UseVisualStyleBackColor = true;
            this.wylogujButton.Click += new System.EventHandler(this.wylogujButton_Click);
            // 
            // PanelAdmina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 613);
            this.ControlBox = false;
            this.Controls.Add(this.wylogujButton);
            this.Controls.Add(this.dodajSzkoleButton);
            this.Controls.Add(this.wyswietlNauczycieliButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.wyswietlUczniowButton);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "PanelAdmina";
            this.Text = "PanelAdmina";
            this.Load += new System.EventHandler(this.PanelAdmina_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button wyswietlUczniowButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button wyswietlNauczycieliButton;
        private System.Windows.Forms.Button dodajSzkoleButton;
        private System.Windows.Forms.Button wylogujButton;
    }
}