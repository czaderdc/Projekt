using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace DziennikElektroniczny
{
    public partial class DodawanieSzkoly : Form
    {
        private Szkola Szkola = new Szkola();
        private Dyrektor Dyrektor = new Dyrektor();
        private Adres AdresSzkoly = new Adres();
        private Adres AdresDyrektora = new Adres();
        private Logowanie daneLogowaniaDyrektora = new Logowanie();
        Form skadPrzybylem;
        public DodawanieSzkoly(Form sender)
        {

            InitializeComponent();
            skadPrzybylem = sender;
           
           
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
                if (t.Name == "imieDyrektoraTextBox" || t.Name == "nazwiskoDyrektoraTextBox" || t.Name == "miejscowoscDyrektorTextBox"
                    || t.Name == "ulicaDyrektorTextBox" || t.Name == "nazwaSzkolyTextBox" || t.Name == "miejscowoscSzkolaTextBox"
                    || t.Name == "ulicaSzkolaTextBox")
                {
                    if (t.Text.Any(c => !char.IsLetter(c) && !char.IsWhiteSpace(c)))
                    {
                        label17.Visible = true;
                        label17.Text = "Wprowadziłeś nieprawidłowy znak w: "+ t.Name +". Aby zapisać szkołę popraw błąd";
                        label17.ForeColor = Color.Red;
                        return false;
                    }
                }
                if (t.Name == "numerBudynkuDyrektorTextBox" || t.Name == "nrBudynkuSzkolaTextBox")
                {
                    if (t.Text.Any(c => !char.IsNumber(c)))
                    {
                        label17.Visible = true;
                        label17.Text = "Wprowadziłeś nieprawidłowy znakw: " + t.Name + ". Aby zapisać szkołę popraw błąd";
                        label17.ForeColor = Color.Red;
                        return false;
                    }
                }
                    
               
            }
            return true;
        }
        private void CzyWypelnionoTextBoxy(object sender, EventArgs e)
        {
            if (KlasaPomocnicza.CzyWypelnionePola(this) == true && comboBoxyWypelnione && CzyTextBoxyMajaDobreDane())
            {
                label17.Visible = false;
                zapiszSzkoleButton.Enabled = true;
            }
            if((sender as TextBox).Name == imieDyrektoraTextBox.Name)
            {
                (sender as TextBox).TextChanged += CzyMoznaWygenerowacLogin;
            }
            if ((sender as TextBox).Name == nazwiskoDyrektoraTextBox.Name)
            {
                (sender as TextBox).TextChanged += CzyMoznaWygenerowacLogin2;
            }

            bool result = KlasaPomocnicza.CzyWypelnionePola(this);
            if (!result || !comboBoxyWypelnione || !CzyTextBoxyMajaDobreDane())
            {
               
                zapiszSzkoleButton.Enabled = false;
            }
        }
        bool warunek2 = false;
        bool warunek1 = false;

        private void CzyMoznaWygenerowacLogin2(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text.All(c=> char.IsLetter(c)) && (sender as TextBox).Text.Length > 2)
            {
                warunek2 = true;
            }
            else
            {
                warunek2 = false;
            }
            if(CzyWolno())
            {
                generujDaneLogowaniaButton.Enabled = true;
            }
            else
            {
                generujDaneLogowaniaButton.Enabled = false;
            }

        }

        

        //sprawdza czy oba textboxy zawieraja wylacznie litery
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
                generujDaneLogowaniaButton.Enabled = true;
            }
            else
            {
                generujDaneLogowaniaButton.Enabled = false;
            }


        }

        private void DodawanieSzkoly_FormClosing(object sender, FormClosingEventArgs e)
        {
            

                
               

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
       

        
        private void DodawanieSzkoly_Load(object sender, EventArgs e)
        {
            this.MouseMove += DodawanieSzkoly_MouseMove;
            if (!File.Exists(@"loginy.txt"))
            {
                 FileStream s = File.Create(@"loginy.txt");
                 s.Close();
                
            }
           // zapiszSzkoleButton.Enabled = false;
            dataUrDyrTextBox.Enabled = false;
            generujDaneLogowaniaButton.Enabled = false;
            loginDyrektoraTextBox.Enabled = false;
            hasloDyrektoraTextBox.Enabled = false;
            ZarejestrujEventy(this);

            using (var context = new MojContext())
            {
                monthCalendar1.DateSelected += (s, ev) =>
                {
                    DialogResult wynik = MessageBox.Show("Czy chcesz zaaakceptować zmianę?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (wynik == DialogResult.Yes)
                    {
                        dataUrDyrTextBox.Text = monthCalendar1.SelectionRange.Start.ToShortDateString();
                        Dyrektor.DataUrodzenia = monthCalendar1.SelectionRange.Start;
                    }
                };

                this.FormClosing += DodawanieSzkoly_FormClosing;
            }
            typSzkolyComboBox.Items.AddRange(new object[] { "Szkoła Podstawowa", "Gimnazjum", "Szkoła Średnia" });
        }


        private ToolTip toolTip = new ToolTip();
        private bool isShown = false;

        private void DodawanieSzkoly_MouseMove(object sender, MouseEventArgs e)
        {
            if (zapiszSzkoleButton == this.GetChildAtPoint(e.Location))
            {
                if (!isShown) // i sprawdzic warunku z eventow aby niepotrzebnie nie wyswietlac informacji w razie poprawnej walidacji danych
                {
                    toolTip.Show("Aby aktywować przycisk musisz uzupełnić wszystkie pola poprawnymi danymi :)",
                        this, e.Location);
                    isShown = true;
                }
            }
            else
            {
                toolTip.Hide(zapiszSzkoleButton);
                isShown = false;
            }
        }

        private void CzySameLiczby(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if(t.Text.Any(c => !char.IsNumber(c)))
            {
                zapiszSzkoleButton.Enabled = false;
            }
        }

        private void zapiszSzkoleButton_Click(object sender, EventArgs e)
        {
            ZapiszSzkole();

        }

        private void ZapiszSzkole()
        {
            using (var context = new MojContext())
            {
                AdresSzkoly.Ulica = ulicaSzkolaTextBox.Text;
                AdresSzkoly.Miejscowosc = miejscowoscSzkolaTextBox.Text;
                AdresSzkoly.NumerBudynku = Int32.Parse(nrBudynkuSzkolaTextBox.Text);
                AdresDyrektora.Miejscowosc = miejscowoscDyrektorTextBox.Text;
                AdresDyrektora.Ulica = ulicaDyrektorTextBox.Text;
                AdresDyrektora.NumerBudynku = Int32.Parse(numerBudynkuDyrektorTextBox.Text);
                Dyrektor.Adres = AdresDyrektora;
                Dyrektor.Logowanie = daneLogowaniaDyrektora;
                Szkola.Dyrektor = Dyrektor;
                Szkola.AdresSzkoly = AdresSzkoly;
                Szkola.NazwaSzkoly = nazwaSzkolyTextBox.Text;
                context.ListaSzkol.Add(Szkola);
                context.SaveChanges();
                //gdy sapisuje szkole, to od razu zapisuje ja rowniez w comboboxie, co nie wymusza na mnie zwracania sie do bazy w celu
                //zaktualizowania wyniku
                FormCollection collection = Application.OpenForms;
                Control control = collection["PanelAdmina"].Controls["comboBox1"];
                (control as ComboBox).Items.Add(Szkola.NazwaSzkoly);

            }
        }

        private void generujDaneLogowaniaButton_Click(object sender, EventArgs e)
        {
            UzupelnijDaneLogowania();
            ZapiszDaneLogowaniaDoPlikuTXT(daneLogowaniaDyrektora);

        }

        private void UzupelnijDaneLogowania()
        {
            Dyrektor.Imie = imieDyrektoraTextBox.Text;
            Dyrektor.Nazwisko = nazwiskoDyrektoraTextBox.Text;
            loginDyrektoraTextBox.Text = daneLogowaniaDyrektora.Login = GenerujLoginDyrektora();
            hasloDyrektoraTextBox.Text = daneLogowaniaDyrektora.Haslo = KlasaPomocnicza.GenerujHaslo(9);
            daneLogowaniaDyrektora.Rola = "Dyrektor";
        }

        private void ZapiszDaneLogowaniaDoPlikuTXT(Logowanie lDyrekotra)
        {
            FileStream fs = new FileStream(@"loginy.txt", FileMode.Append, FileAccess.Write);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("Dane logowania dyrektora: " + Dyrektor.Imie + " " + Dyrektor.Nazwisko + ":");
                sw.WriteLine("Login: " + lDyrekotra.Login);
                sw.WriteLine("Hasło: " + lDyrekotra.Haslo);
            }
        }

        private string GenerujLoginDyrektora()
        {
            return imieDyrektoraTextBox.Text[0].ToString() +
                imieDyrektoraTextBox.Text[1].ToString() +
                imieDyrektoraTextBox.Text[2].ToString() +
                KlasaPomocnicza.GenerujLosowyCiagLiczb(100, 999).ToString();
        }

        private void wrocButton_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxy = this.Controls.OfType<TextBox>().ToList();
            if (textBoxy.Any(y => y.Text != null && y.Text != string.Empty))
            {
                DialogResult result = MessageBox.Show("Czy na pewno zakończyć dodawanie? Wprowadziłeś pewne dane", "Ostrzeżenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {

                    this.Close();
                    skadPrzybylem.Show();

                }

            }
            else
            {
                DialogResult result = MessageBox.Show("Czy na pewno chcesz zakończyć dodawanie?", "Uwaga", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                    skadPrzybylem.Show();
                }
            }
        }
    }
}
