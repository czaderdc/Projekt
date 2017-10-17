using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using System.Data.Entity;

namespace DziennikElektroniczny
{
    public partial class PanelAdmina : Form
    {
        public PanelAdmina()
        {
            InitializeComponent();
            
        }

        private void dodajSzkoleButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            DodawanieSzkoly ds = new DodawanieSzkoly(this);
            ds.Show();
        }

        private void PanelAdmina_Load(object sender, EventArgs e)
        {

            wyswietlUczniowButton.Enabled = false;
            wyswietlNauczycieliButton.Enabled = false;
            comboBox1.SelectedValueChanged += (s, ev) =>
            {
                wyswietlUczniowButton.Enabled = true;
                wyswietlNauczycieliButton.Enabled = true;
            };
            WyswietlListeSzkolComboBox();
        }

        private void WyswietlListeSzkolComboBox()
        {
            using (var db = new MojContext())
            {
                var szkoly = db.ListaSzkol.ToList();


                foreach (Szkola s in szkoly)
                {
                    comboBox1.Items.Add(s.NazwaSzkoly);
                }
            }
        }

        private void wyswietlUczniowButton_Click(object sender, EventArgs e)
        {
            using (var db = new MojContext())
            {
                string wybranaSzkola = comboBox1.SelectedItem.ToString();
                var szkolaKlasy = db.ListaSzkol.Where(s => s.NazwaSzkoly == wybranaSzkola).Include(s => s.ListaKlas).Single();

                List<Uczen> UczniowieSzkoly = new List<Uczen>();
                foreach(Klasa k in szkolaKlasy.ListaKlas)
                {
                    foreach(Uczen u in k.Uczniowie)
                    {
                        UczniowieSzkoly.Add(u);
                    }
                }

                var wynik = UczniowieSzkoly.Select(u => new
                {
                    ImięUcznia = u.Imie,
                    NazwiskoUcznia = u.Nazwisko,
                }).ToList();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = wynik;
            }
        }

        private void wyswietlNauczycieliButton_Click(object sender, EventArgs e)
        {
            using (var db = new MojContext())
            {
                string wybranaSzkola = comboBox1.SelectedItem.ToString();
                var nauczyciele = db.Nauczyciele.Where(n => n.Szkola.NazwaSzkoly == wybranaSzkola).ToList();
                var wynik = nauczyciele.Select(n =>
                new
                {
                    ImieNauczyciela = n.Imie,
                    NazwiskoNauczyciela = n.Nazwisko
                }).ToList();

                if (wynik == null)
                {
                    MessageBox.Show("Ta szkoła nie posiada przypisanych nauczycieli!");
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = wynik;

            }
        }

        private void wylogujButton_Click(object sender, EventArgs e)
        {
          
            KlasaPomocnicza.Wyloguj(sender);
        }
    }
}
