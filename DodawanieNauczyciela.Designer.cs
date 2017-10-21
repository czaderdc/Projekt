namespace DziennikElektroniczny
{
    partial class DodawanieNauczyciela
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
            this.label4 = new System.Windows.Forms.Label();
            this.imieTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nazwiskoTextBox = new System.Windows.Forms.TextBox();
            this.wiekTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.generowanieButton = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.wojewodztwoComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ulicaTextBox = new System.Windows.Forms.TextBox();
            this.miastoTextBox = new System.Windows.Forms.TextBox();
            this.kodPocztowyTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dodajNauczyciela = new System.Windows.Forms.Button();
            this.hasloTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.KlasacomboBox = new System.Windows.Forms.ComboBox();
            this.przedmiotyICollectionBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Imie";
            // 
            // imieTextBox
            // 
            this.imieTextBox.Location = new System.Drawing.Point(67, 103);
            this.imieTextBox.Name = "imieTextBox";
            this.imieTextBox.Size = new System.Drawing.Size(100, 20);
            this.imieTextBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Nazwisko";
            // 
            // nazwiskoTextBox
            // 
            this.nazwiskoTextBox.Location = new System.Drawing.Point(67, 192);
            this.nazwiskoTextBox.Name = "nazwiskoTextBox";
            this.nazwiskoTextBox.Size = new System.Drawing.Size(100, 20);
            this.nazwiskoTextBox.TabIndex = 38;
            // 
            // wiekTextBox
            // 
            this.wiekTextBox.Location = new System.Drawing.Point(67, 277);
            this.wiekTextBox.Name = "wiekTextBox";
            this.wiekTextBox.Size = new System.Drawing.Size(100, 20);
            this.wiekTextBox.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Wiek";
            // 
            // generowanieButton
            // 
            this.generowanieButton.Location = new System.Drawing.Point(47, 328);
            this.generowanieButton.Name = "generowanieButton";
            this.generowanieButton.Size = new System.Drawing.Size(159, 23);
            this.generowanieButton.TabIndex = 41;
            this.generowanieButton.Text = "Wygeneruj Login i Hasło";
            this.generowanieButton.UseVisualStyleBackColor = true;
            this.generowanieButton.Click += new System.EventHandler(this.generowanieButton_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(97, 368);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 13);
            this.label14.TabIndex = 42;
            this.label14.Text = "Login";
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(67, 394);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(100, 20);
            this.loginTextBox.TabIndex = 37;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(97, 429);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 13);
            this.label15.TabIndex = 43;
            this.label15.Text = "Hasło";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-55, 429);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "Hasło";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(661, 249);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 52;
            this.label12.Text = "Kod Pocztowy";
            // 
            // wojewodztwoComboBox
            // 
            this.wojewodztwoComboBox.FormattingEnabled = true;
            this.wojewodztwoComboBox.Location = new System.Drawing.Point(658, 224);
            this.wojewodztwoComboBox.Name = "wojewodztwoComboBox";
            this.wojewodztwoComboBox.Size = new System.Drawing.Size(121, 21);
            this.wojewodztwoComboBox.TabIndex = 51;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(664, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 50;
            this.label11.Text = "Ulica";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(661, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 49;
            this.label10.Text = "Miasto";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(661, 196);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 48;
            this.label9.Text = "Województwo";
            // 
            // ulicaTextBox
            // 
            this.ulicaTextBox.Location = new System.Drawing.Point(658, 119);
            this.ulicaTextBox.Name = "ulicaTextBox";
            this.ulicaTextBox.Size = new System.Drawing.Size(100, 20);
            this.ulicaTextBox.TabIndex = 47;
            // 
            // miastoTextBox
            // 
            this.miastoTextBox.Location = new System.Drawing.Point(658, 163);
            this.miastoTextBox.Name = "miastoTextBox";
            this.miastoTextBox.Size = new System.Drawing.Size(100, 20);
            this.miastoTextBox.TabIndex = 46;
            // 
            // kodPocztowyTextBox
            // 
            this.kodPocztowyTextBox.Location = new System.Drawing.Point(658, 277);
            this.kodPocztowyTextBox.Name = "kodPocztowyTextBox";
            this.kodPocztowyTextBox.Size = new System.Drawing.Size(100, 20);
            this.kodPocztowyTextBox.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(694, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "Adres";
            // 
            // dodajNauczyciela
            // 
            this.dodajNauczyciela.Location = new System.Drawing.Point(47, 492);
            this.dodajNauczyciela.Name = "dodajNauczyciela";
            this.dodajNauczyciela.Size = new System.Drawing.Size(127, 23);
            this.dodajNauczyciela.TabIndex = 54;
            this.dodajNauczyciela.Text = "Dodaj Nauczyciela";
            this.dodajNauczyciela.UseVisualStyleBackColor = true;
            this.dodajNauczyciela.Click += new System.EventHandler(this.dodajNauczyciela_Click);
            // 
            // hasloTextBox
            // 
            this.hasloTextBox.Location = new System.Drawing.Point(67, 449);
            this.hasloTextBox.Name = "hasloTextBox";
            this.hasloTextBox.Size = new System.Drawing.Size(100, 20);
            this.hasloTextBox.TabIndex = 55;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(367, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "Będzie nauczał";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(288, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "Klasy";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(455, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 58;
            this.label8.Text = "Przedmiotu";
            // 
            // KlasacomboBox
            // 
            this.KlasacomboBox.FormattingEnabled = true;
            this.KlasacomboBox.Location = new System.Drawing.Point(241, 174);
            this.KlasacomboBox.Name = "KlasacomboBox";
            this.KlasacomboBox.Size = new System.Drawing.Size(121, 21);
            this.KlasacomboBox.TabIndex = 59;
            // 
            // przedmiotyICollectionBox
            // 
            this.przedmiotyICollectionBox.FormattingEnabled = true;
            this.przedmiotyICollectionBox.Location = new System.Drawing.Point(411, 169);
            this.przedmiotyICollectionBox.Name = "przedmiotyICollectionBox";
            this.przedmiotyICollectionBox.Size = new System.Drawing.Size(164, 212);
            this.przedmiotyICollectionBox.TabIndex = 60;
            // 
            // DodawanieNauczyciela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 527);
            this.Controls.Add(this.przedmiotyICollectionBox);
            this.Controls.Add(this.KlasacomboBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.hasloTextBox);
            this.Controls.Add(this.dodajNauczyciela);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.wojewodztwoComboBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ulicaTextBox);
            this.Controls.Add(this.miastoTextBox);
            this.Controls.Add(this.kodPocztowyTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.generowanieButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.wiekTextBox);
            this.Controls.Add(this.nazwiskoTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imieTextBox);
            this.Controls.Add(this.label4);
            this.Name = "DodawanieNauczyciela";
            this.Text = "PanelNauczyciela";
            this.Load += new System.EventHandler(this.PanelNauczyciela_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox imieTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nazwiskoTextBox;
        private System.Windows.Forms.TextBox wiekTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button generowanieButton;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox wojewodztwoComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ulicaTextBox;
        private System.Windows.Forms.TextBox miastoTextBox;
        private System.Windows.Forms.TextBox kodPocztowyTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button dodajNauczyciela;
        private System.Windows.Forms.TextBox hasloTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox KlasacomboBox;
        private System.Windows.Forms.ListBox przedmiotyICollectionBox;
    }
}