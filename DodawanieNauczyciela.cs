using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace DziennikElektroniczny
{
    public partial class DodawanieNauczyciela : Form
    {
        string NazwaSzkoly;
        private Nauczyciel nowyNauczyciel = new Nauczyciel();
        private Adres AdresNauczyciela = new Adres();
        private Logowanie LogowanieNauczyciela = new Logowanie();
        private ICollection<Przedmiot> przedmiotyNauczyciela = new HashSet<Przedmiot>();

        public DodawanieNauczyciela(string nazwaSzkoly)
        {
            InitializeComponent();
            NazwaSzkoly = nazwaSzkoly;
        }

        private void PanelNauczyciela_Load(object sender, EventArgs e)
        {
            WypelnijListeKlas();

            ZarejestrujEventy();
        }

        private void ZarejestrujEventy()
        {
            //event Odpowiedzialny za wyswietlenie przedmiotów wybranej Klasy
            KlasacomboBox.SelectedValueChanged += (s, ev) =>
            {
                przedmiotyICollectionBox.Items.Clear();
                using (var db = new MojContext())
                {
                    string NazwaKlasy = KlasacomboBox.SelectedItem.ToString();
                    var przedmioty = db.Klasy.Where(k => k.Szkola.NazwaSzkoly == NazwaSzkoly && k.NazwaKlasy == NazwaKlasy).Select(k => k.PrzedmiotyKlasy).Single();
                    foreach (Przedmiot p in przedmioty)
                    {
                        przedmiotyICollectionBox.Items.Add(p.NazwaPrzedmiotu);
                    }
                }
            };
        }

        private void WypelnijListeKlas()
        {
            using (var db = new MojContext())
            {
                var ListaKlas = db.Klasy.Where(k => k.Szkola.NazwaSzkoly == NazwaSzkoly).ToList();
                foreach (Klasa k in ListaKlas)
                {
                    KlasacomboBox.Items.Add(k.NazwaKlasy);
                }
            }
        }

        private void dodajNauczyciela_Click(object sender, EventArgs e)
        {
            ZapiszNauczyciela();
        }

        private void ZapiszNauczyciela()
        {
            using (var db = new MojContext())
            {
                AdresNauczyciela.Miejscowosc = miastoTextBox.Text;
                AdresNauczyciela.Ulica = ulicaTextBox.Text;
                nowyNauczyciel.Imie = imieTextBox.Text;
                nowyNauczyciel.Nazwisko = nazwiskoTextBox.Text;
                nowyNauczyciel.Logowanie = LogowanieNauczyciela;
                nowyNauczyciel.Adres = AdresNauczyciela;
                string przedmiot = przedmiotyICollectionBox.SelectedItem.ToString();
                nowyNauczyciel.Szkola = db.ListaSzkol.Where(sz => sz.NazwaSzkoly == NazwaSzkoly).Single();
                nowyNauczyciel.Szkola.ListaKlas.Add(db.Klasy.Where(k => k.Szkola.NazwaSzkoly == NazwaSzkoly && k.NazwaKlasy == KlasacomboBox.SelectedItem.ToString()).Single());
                przedmiotyNauczyciela =
                (ICollection<Przedmiot>)db.Klasy.Where(k => k.Szkola.NazwaSzkoly == NazwaSzkoly && k.NazwaKlasy == KlasacomboBox.SelectedItem.ToString()).Select(k => k.PrzedmiotyKlasy.Where(kl => kl.NazwaPrzedmiotu == przedmiot)).Single();
                nowyNauczyciel.Przedmioty = przedmiotyNauczyciela;
                db.Nauczyciele.Add(nowyNauczyciel);
                db.SaveChanges();
            }
        }

        private void generowanieButton_Click(object sender, EventArgs e)
        {
 
            loginTextBox.Text = LogowanieNauczyciela.Login = GenerujLoginNauczyciela();
            hasloTextBox.Text = LogowanieNauczyciela.Haslo = KlasaPomocnicza.GenerujHaslo(9);
            LogowanieNauczyciela.Rola = "Nauczyciel";
            FileStream fs = new FileStream(@"loginyNauczycieli.txt", FileMode.Append, FileAccess.Write);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("Dane logowania Nauczyciela: " + nowyNauczyciel.Imie + " " + nowyNauczyciel.Nazwisko + ":");
                sw.WriteLine("Login: " + LogowanieNauczyciela.Login);
                sw.WriteLine("Hasło: " + LogowanieNauczyciela.Haslo);
            }

            nowyNauczyciel.Logowanie = LogowanieNauczyciela;
        }

        private string GenerujLoginNauczyciela()
        {
            return imieTextBox.Text[0].ToString() +
                imieTextBox.Text[1].ToString() +
                imieTextBox.Text[2].ToString() +
                KlasaPomocnicza.GenerujLosowyCiagLiczb(100, 999).ToString();
        }

    }
}
