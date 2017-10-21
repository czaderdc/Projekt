namespace DziennikElektroniczny
{
    partial class PanelDyrektora
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
            this.dodajUczniaButton = new System.Windows.Forms.Button();
            this.dodajNauczycielaButton = new System.Windows.Forms.Button();
            this.dodajKlaseButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.wyswietlUczniowButton = new System.Windows.Forms.Button();
            this.wyswietlNauczycieliButton = new System.Windows.Forms.Button();
            this.wylogujButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dodajUczniaButton
            // 
            this.dodajUczniaButton.Location = new System.Drawing.Point(12, 22);
            this.dodajUczniaButton.Name = "dodajUczniaButton";
            this.dodajUczniaButton.Size = new System.Drawing.Size(118, 23);
            this.dodajUczniaButton.TabIndex = 0;
            this.dodajUczniaButton.Text = "Dodaj Ucznia";
            this.dodajUczniaButton.UseVisualStyleBackColor = true;
            this.dodajUczniaButton.Click += new System.EventHandler(this.dodajUczniaButton_Click);
            // 
            // dodajNauczycielaButton
            // 
            this.dodajNauczycielaButton.Location = new System.Drawing.Point(136, 22);
            this.dodajNauczycielaButton.Name = "dodajNauczycielaButton";
            this.dodajNauczycielaButton.Size = new System.Drawing.Size(118, 23);
            this.dodajNauczycielaButton.TabIndex = 1;
            this.dodajNauczycielaButton.Text = "Dodaj Nauczyciela";
            this.dodajNauczycielaButton.UseVisualStyleBackColor = true;
            this.dodajNauczycielaButton.Click += new System.EventHandler(this.dodajNauczycielaButton_Click);
            // 
            // dodajKlaseButton
            // 
            this.dodajKlaseButton.Location = new System.Drawing.Point(260, 22);
            this.dodajKlaseButton.Name = "dodajKlaseButton";
            this.dodajKlaseButton.Size = new System.Drawing.Size(118, 23);
            this.dodajKlaseButton.TabIndex = 2;
            this.dodajKlaseButton.Text = "Dodaj Klase";
            this.dodajKlaseButton.UseVisualStyleBackColor = true;
            this.dodajKlaseButton.Click += new System.EventHandler(this.dodajKlaseButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(399, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(891, 564);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // wyswietlUczniowButton
            // 
            this.wyswietlUczniowButton.Location = new System.Drawing.Point(260, 283);
            this.wyswietlUczniowButton.Name = "wyswietlUczniowButton";
            this.wyswietlUczniowButton.Size = new System.Drawing.Size(118, 23);
            this.wyswietlUczniowButton.TabIndex = 4;
            this.wyswietlUczniowButton.Text = "Wyświetl Uczniów";
            this.wyswietlUczniowButton.UseVisualStyleBackColor = true;
            // 
            // wyswietlNauczycieliButton
            // 
            this.wyswietlNauczycieliButton.Location = new System.Drawing.Point(260, 231);
            this.wyswietlNauczycieliButton.Name = "wyswietlNauczycieliButton";
            this.wyswietlNauczycieliButton.Size = new System.Drawing.Size(118, 23);
            this.wyswietlNauczycieliButton.TabIndex = 5;
            this.wyswietlNauczycieliButton.Text = "Wyświetl nauczycieli";
            this.wyswietlNauczycieliButton.UseVisualStyleBackColor = true;
            this.wyswietlNauczycieliButton.Click += new System.EventHandler(this.wyswietlNauczycieliButton_Click);
            // 
            // wylogujButton
            // 
            this.wylogujButton.Location = new System.Drawing.Point(12, 536);
            this.wylogujButton.Name = "wylogujButton";
            this.wylogujButton.Size = new System.Drawing.Size(118, 23);
            this.wylogujButton.TabIndex = 6;
            this.wylogujButton.Text = "Wyloguj";
            this.wylogujButton.UseVisualStyleBackColor = true;
            this.wylogujButton.Click += new System.EventHandler(this.wylogujButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Dodaj Przedmiot";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PanelDyrektora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 571);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.wylogujButton);
            this.Controls.Add(this.wyswietlNauczycieliButton);
            this.Controls.Add(this.wyswietlUczniowButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dodajKlaseButton);
            this.Controls.Add(this.dodajNauczycielaButton);
            this.Controls.Add(this.dodajUczniaButton);
            this.Name = "PanelDyrektora";
            this.Text = "PanelDyrektora";
            this.Load += new System.EventHandler(this.PanelDyrektora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button dodajUczniaButton;
        private System.Windows.Forms.Button dodajNauczycielaButton;
        private System.Windows.Forms.Button dodajKlaseButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button wyswietlUczniowButton;
        private System.Windows.Forms.Button wyswietlNauczycieliButton;
        private System.Windows.Forms.Button wylogujButton;
        private System.Windows.Forms.Button button1;
    }
}