using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace DziennikElektroniczny
{
    public partial class DodawanieUcznia : Form
    {
        private Uczen uczenDoDodania = new Uczen();
        private Szkola szkola;
        string nazwaszkoly;
        Form skadPrzybylem;
        public DodawanieUcznia(string nazwaSzkoly, Form skad)
        {
            InitializeComponent();
            skadPrzybylem = skad;
           
            ZarejestrujEventy(this);
            nazwaszkoly = nazwaSzkoly;

            KlasacomboBox.SelectedValueChanged += (sender, e) =>
            {
                zapisanyNaListBox.Items.Clear();
                using (var db = new MojContext())
                {
                    string nazwaKlasy = KlasacomboBox.SelectedItem.ToString();
                    var przedmioty = db.Klasy.Where(s => s.Szkola.NazwaSzkoly == nazwaszkoly && s.NazwaKlasy == nazwaKlasy).Select(k => k.PrzedmiotyKlasy).Single();
                    foreach (Przedmiot p in przedmioty)
                    {
                        uczenDoDodania.Przedmioty.Add(p);
                        zapisanyNaListBox.Items.Add(p.NazwaPrzedmiotu);
                    }
                }
            };

            przedmiotyICollectionBox.MouseEnter += (s, e) =>
                {
                    powiadomienieLabel.Text = "Kliknij LPM na przedmiot aby zapisać ucznia";
                    powiadomienieLabel.ForeColor = Color.Red;
                    powiadomienieLabel.Visible = true;
                };
            przedmiotyICollectionBox.MouseLeave += (s, e) =>
            {
                powiadomienieLabel.Visible = false;
            };
            przedmiotyICollectionBox.Click += (s, e) =>
            {
                try
                {
                    var przedmiot = przedmiotyICollectionBox.SelectedItems[0];
                    if (!zapisanyNaListBox.Items.Contains(przedmiot))
                    {
                        zapisanyNaListBox.Items.Add(przedmiot);
                    }
                    else
                    {
                        powiadomienieLabel.Text = "Już dodałeś ten przedmiot temu uczniowi!";
                        powiadomienieLabel.Visible = true;
                        powiadomienieLabel.ForeColor = Color.Red;
                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show("Nie dodano żadnego przedmiootu!");
                }

            };



        }



        private void KodPocztowyTextBox_TextAlignChanged(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            bool Ok = false;
            //może zastosować string format??
            if (text.Text.Length == 6 && char.IsNumber(text.Text[0]) && char.IsNumber(text.Text[1]) && text.Text[2] == '-'
                && char.IsNumber(text.Text[3]) && char.IsNumber(text.Text[4]) && char.IsNumber(text.Text[5]))
            {
                Ok = true;
            }
            else if (!Ok)
            {
                powiadomienieLabel.Visible = true;
                powiadomienieLabel.Text = "Kod pocztowy musi mieć postać NN-NNN i nie może zawierać liter!";
            }
            if (Ok)
            {
                powiadomienieLabel.Visible = false;
            }
        }
        private bool CzyDodanePrzedmioty()
        {
            if (przedmiotyICollectionBox.Items == null || zapisanyNaListBox.Items == null)
                return false;
            return true;
        }

        private bool CzyNadanoKlase()
        {
            if (KlasacomboBox.SelectedItem == null)
                return false;
            return true;
        }
        private void ZarejestrujEventy(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = (TextBox)c;
                    textBox.TextChanged += CzyWypelnionoTextBoxy;
                }
                else if (c is ComboBox)
                {
                    ComboBox combo = (ComboBox)c;
                    combo.SelectedValueChanged += CzyWypelnionoComboBoxy;
                }
                else
                {
                    ZarejestrujEventy(c);
                }
            }
        }
        bool comboBoxyWypelnione = false;
        private void CzyWypelnionoComboBoxy(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedItem != null)
            {
                comboBoxyWypelnione = true;
            }
        }

        private bool CzyTextBoxyMajaDobreDane()
        {
            List<TextBox> textBoxy = this.Controls.OfType<TextBox>().ToList();
            foreach (TextBox t in textBoxy)
            {
                if (t.Name == "imieTextBox " || t.Name == "nazwiskoTextBox" || t.Name == "miastoTextBox "
                    || t.Name == "ulicaTextBox")
                {
                    if (t.Text.Any(c => !char.IsLetter(c) && !char.IsWhiteSpace(c)))
                    {

                        return false;
                    }
                }
                if (t.Name == "nrBudynkuTextBox" || t.Name == "wiekTextBox")
                {
                    if (t.Text.Any(c => !char.IsNumber(c)))
                    {

                        return false;
                    }
                }


            }
            return true;
        }
        private void CzyWypelnionoTextBoxy(object sender, EventArgs e)
        {
            if (KlasaPomocnicza.CzyWypelnionePola(this) == true && comboBoxyWypelnione && CzyTextBoxyMajaDobreDane() && CzyDodanePrzedmioty() && CzyNadanoKlase())
            {
                errorLabel.Visible = false;
                zapiszUczniaButton.Enabled = true;
            }
            if ((sender as TextBox).Name == imieTextBox.Name)
            {
                (sender as TextBox).TextChanged += CzyMoznaWygenerowacLogin;
            }
            if ((sender as TextBox).Name == nazwiskoTextBox.Name)
            {
                (sender as TextBox).TextChanged += CzyMoznaWygenerowacLogin2;
            }

            bool result = KlasaPomocnicza.CzyWypelnionePola(this);
            if (!result || !comboBoxyWypelnione || !CzyTextBoxyMajaDobreDane() || !CzyDodanePrzedmioty() || !CzyNadanoKlase())
            {
                errorLabel.Visible = true;
                errorLabel.Text = "Wprowadziłeś nieprawidłowy znak. Aby zapisać ucznia popraw błąd";
                errorLabel.ForeColor = Color.Red;
                zapiszUczniaButton.Enabled = false;
            }
        }
        bool warunek2 = false;
        bool warunek1 = false;

        private void CzyMoznaWygenerowacLogin2(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text.All(c => char.IsLetter(c)) && (sender as TextBox).Text.Length > 2)
            {
                warunek2 = true;
            }
            else
            {
                warunek2 = false;
            }
            if (CzyWolno())
            {
                generowanieButton.Enabled = true;
            }
            else
            {
                generowanieButton.Enabled = false;
            }

        }




        private bool CzyWolno()
        {
            return warunek1 && warunek2;
        }
        private void CzyMoznaWygenerowacLogin(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text.All(c => char.IsLetter(c)) && (sender as TextBox).Text.Length > 2)
            {
                warunek1 = true;
            }
            else
            {
                warunek1 = false;
            }
            if (CzyWolno())
            {
                generowanieButton.Enabled = true;
            }
            else
            {
                generowanieButton.Enabled = false;
            }


        }


        private void DodawanieUcznia_Load(object sender, EventArgs e)
        {
            // dodajUcznia.Enabled = false;
            generowanieButton.Enabled = false;
            using (var db = new MojContext())
            {
                var wynik = db.ListaSzkol.Where(s => s.NazwaSzkoly == nazwaszkoly).Include(s => s.ListaKlas).Single();

                foreach (Klasa k in wynik.ListaKlas)
                {
                    KlasacomboBox.Items.Add(k.NazwaKlasy);
                }

                var przedmiotySzkoly = db.ListaSzkol.Where(s => s.NazwaSzkoly == nazwaszkoly).Select(s => s.Przedmioty).Single();
                foreach (Przedmiot p in przedmiotySzkoly)
                {
                    przedmiotyICollectionBox.Items.Add(p.NazwaPrzedmiotu);
                }

            }

        }



        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }





        private void dodajUcznia_Click(object sender, EventArgs e)
        {


        }

        private string GenerujLoginUcznia()
        {
            return imieTextBox.Text[0].ToString() +
                imieTextBox.Text[1].ToString() +
                imieTextBox.Text[2].ToString() +
                KlasaPomocnicza.GenerujLosowyCiagLiczb(100, 999).ToString();
        }

        private void generowanieButton_Click(object sender, EventArgs e)
        {
            uczenDoDodania.Imie = imieTextBox.Text;
            uczenDoDodania.Nazwisko = nazwiskoTextBox.Text;
            Logowanie daneLogowaniaUcznia = new Logowanie();
            loginTextBox.Text = daneLogowaniaUcznia.Login = GenerujLoginUcznia();
            hasloTextBox.Text = daneLogowaniaUcznia.Haslo = KlasaPomocnicza.GenerujHaslo(9);
            daneLogowaniaUcznia.Rola = "Uczen";
            FileStream fs = new FileStream(@"loginyUcznia.txt", FileMode.Append, FileAccess.Write);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("Dane logowania Ucznia: " + uczenDoDodania.Imie + " " + uczenDoDodania.Nazwisko + ":");
                sw.WriteLine("Login: " + daneLogowaniaUcznia.Login);
                sw.WriteLine("Hasło: " + daneLogowaniaUcznia.Haslo);
            }

            uczenDoDodania.Logowanie = daneLogowaniaUcznia;



        }

        private void dodajZdjecieButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Filter = "Pliki zdjęć (*.jpeg, *.bmp, *.png) | *.jpeg; *.bmp; *.png";
            if (opd.ShowDialog() == DialogResult.OK)
            {
                string[] formatZdjecia = opd.FileName.Split('.');
                pictureBox1.Image = Image.FromFile(opd.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                uczenDoDodania.Zdjecie = PrzygotujZdjecieDoBazy(pictureBox1.Image, formatZdjecia[1]);
            }

        }

        private byte[] PrzygotujZdjecieDoBazy(Image zdjecie, string formatZdjecia)
        {
            MemoryStream mstream = new MemoryStream();
            switch (formatZdjecia)
            {
                case "png":
                zdjecie.Save(mstream, System.Drawing.Imaging.ImageFormat.Png);
                    return mstream.ToArray();
                    
                case "jpg":
                    zdjecie.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return mstream.ToArray();
                    
                case "bmp":
                    zdjecie.Save(mstream, System.Drawing.Imaging.ImageFormat.Bmp);
                    return mstream.ToArray();
                    
                default:
                    throw new Exception("Fd");


            }
            

            
        }
        
    

        private void zapiszNaPrzedmiotyButton_Click(object sender, EventArgs e)
        {

        }

        private void zapiszUczniaButton_Click(object sender, EventArgs e)
        {
            using (var db = new MojContext())
            {
                uczenDoDodania.DataUrodzenia = DateTime.Now;
                uczenDoDodania.AdresUcznia = new Adres
                {
                    Miejscowosc = miastoTextBox.Text,
                    Ulica = ulicaTextBox.Text,
                    NumerBudynku = Int32.Parse(nrBudynkuTextBox.Text)
                };
                var listaKlas= db.ListaSzkol.Where(s => s.NazwaSzkoly == nazwaszkoly).Select(s => s.ListaKlas).Single();
                Klasa zapisanyNa = listaKlas.Where(k => k.NazwaKlasy == KlasacomboBox.SelectedItem.ToString()).Single();
                uczenDoDodania.Klasa = zapisanyNa;
                db.Uczniowie.Add(uczenDoDodania);
                db.SaveChanges();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            skadPrzybylem.Show();
        }
    }
}

    


