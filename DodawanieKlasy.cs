using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace DziennikElektroniczny
{
    public partial class DodawanieKlasy : Form
    {
        string NazwaSzkoly = string.Empty;
        PanelDyrektora pd;
        public DodawanieKlasy(string nazwaSzkoly, object sender)
        {
            InitializeComponent();
            NazwaSzkoly = nazwaSzkoly;
            pd = (sender as PanelDyrektora);
        }

        private void DodawanieKlasy_Load(object sender, EventArgs e)
        {
           
            listaKlasListBox.SelectedValueChanged += WyswietlUczniowWybranejKlasy;
            using (var db = new MojContext())
            {
                var listaKlas = db.Klasy.Where(k => k.Szkola.NazwaSzkoly == NazwaSzkoly).Include(k=> k.Szkola).ToList();
                foreach(Klasa k in listaKlas)
                {
                    listaKlasListBox.Items.Add(k.NazwaKlasy);
                }

                
            }
        }

        private void WyswietlUczniowWybranejKlasy(object sender, EventArgs e)
        {
            listaPrzedmiotowListBox.Items.Clear();
            ListBox lb = sender as ListBox;
            string NazwaKlasy = lb.SelectedItem.ToString();
            using (var db = new MojContext())
            {
                var przedmioty = db.Klasy.Where(k => k.Szkola.NazwaSzkoly == NazwaSzkoly && k.NazwaKlasy == NazwaKlasy).Select(k => k.PrzedmiotyKlasy).Single();

                
                foreach(Przedmiot p in przedmioty)
                {
                    listaPrzedmiotowListBox.Items.Add(p.NazwaPrzedmiotu);
                }
                var Uczniowie = db.Uczniowie.Where(u => u.Klasa.NazwaKlasy == NazwaKlasy && u.Klasa.Szkola.NazwaSzkoly == NazwaSzkoly).ToList();
                dataGridView1.DataSource = null;
              dataGridView1.DataSource = Uczniowie;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new MojContext())
            {
                Klasa k = new Klasa
                {
                    NazwaKlasy = nazwaKlasyTextBox.Text,
                    Szkola = db.ListaSzkol.Where(s => s.NazwaSzkoly == NazwaSzkoly).Single()
                };

                db.Klasy.Add(k);
                db.SaveChanges();
                listaKlasListBox.Items.Add(k.NazwaKlasy);
                listaKlasListBox.Refresh();
             
                List<Button> butt = pd.Controls.OfType<Button>().ToList();
                foreach(var b in butt)
                {
                  
                    if(b.Name == "dodajUczniaButton")
                    {
                        b.Enabled = true;
                    }
                }
                
            }


        }
    }
}
