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
    public partial class DodawaniePrzedmiotu : Form
    {
        int id;
        Form panelDyrektora;
        string nazwaSzkoly;
        public DodawaniePrzedmiotu(int idDyrektora, Form sender, string szkola)
        {
            InitializeComponent();
            panelDyrektora = sender;
            id = idDyrektora;
            nazwaSzkoly = szkola;
        }

        private void ZarejestrujEventy()
        {




            nauczanePrzedmiotyListBox.SelectedValueChanged += (s, e) =>
            {
                listaKlasListBox.Enabled = true;
            };

            listaKlasListBox.SelectedValueChanged += (s, e) =>
            {
                var klasa = (s as ListBox).SelectedItem.ToString();
                var przedmiot = nauczanePrzedmiotyListBox.SelectedItem.ToString();
                DialogResult result = MessageBox.Show($"Czy na pewno chcesz zapisać klasę: {klasa} na przedmiot? {przedmiot}", "?", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    using (var db = new MojContext())
                    {
                        var szkola = db.ListaSzkol.Where(sz => sz.Dyrektor.LogowanieID == id).Single();
                        var zapisanaKlasa = szkola.ListaKlas.Where(k => k.NazwaKlasy == klasa).Single();
                        zapisanaKlasa.PrzedmiotyKlasy.Add(szkola.Przedmioty.Where(p => p.NazwaPrzedmiotu == przedmiot).Single());
                        db.SaveChanges();
                    }
                }
            };
            nowyPrzedmiotTextBox.TextChanged += (s, e) =>
            {

                TextBox t = s as TextBox;
                if (CzyPosiadaJuzTenPrzedmiot((s as TextBox).Text) || t.Text.Length < 3 || t.Text.Any(c => !char.IsLetter(c) && !char.IsWhiteSpace(c)))
                {
                    dodajPrzedmiotButton.Enabled = false;
                }
                else
                {
                    dodajPrzedmiotButton.Enabled = true;
                }
            };

            nauczanePrzedmiotyListBox.MouseEnter += Powiadomienie;
            nauczanePrzedmiotyListBox.MouseLeave += PowiadomienieUsun;
            listaKlasListBox.MouseEnter += Powiadomienie2;
            listaKlasListBox.MouseLeave += PowiadomienieUsun;
        }
        ToolTip tip = new ToolTip();
        private void PowiadomienieUsun(object sender, EventArgs e)
        {
            tip.Hide(this);
        }
        private void Powiadomienie2(object sender, EventArgs e)
        {

            tip.Show("A teraz kliknij LMP na klasę, która zostanie podpięta pod ten przedmiot", this, (sender as ListBox).Location);
        }
        private void Powiadomienie(object sender, EventArgs e)
        {
            
            tip.Show("Aby przypisać dany przedmiot klasie, zaznacz wybrany przedmiot, a następnie kliknij LPM na klasę, której chcesz przypisać ten przedmiot", this, (sender as ListBox).Location);
        }

        private void dodajPrzedmiotButton_Click(object sender, EventArgs e)
        {
            Przedmiot nowy = new Przedmiot();
            nowy.NazwaPrzedmiotu = nowyPrzedmiotTextBox.Text;
            nauczanePrzedmiotyListBox.Items.Add(nowyPrzedmiotTextBox.Text);
            using (var db = new MojContext())
            {
                var szkola = db.ListaSzkol.Where(sz => sz.NazwaSzkoly == nazwaSzkoly).Single();
                szkola.Przedmioty.Add(nowy);
                db.SaveChanges();
            }
           List<Button> buttons =  panelDyrektora.Controls.OfType<Button>().ToList();
            var nazwaPrzycisku = buttons.Where(b => b.Name == "dodajNauczycielaButton").Select(b=>b).Single();
            (nazwaPrzycisku as Button).Enabled = true;
            
           
        }

        private void DodawaniePrzedmiotu_Load(object sender, EventArgs e)
        {
            ZarejestrujEventy();
            
            listaKlasListBox.Enabled = false;
            dodajPrzedmiotButton.Enabled = false;
            using (var db = new MojContext())
            {
                var listaKlas= db.ListaSzkol.Where(d => d.NazwaSzkoly
                == nazwaSzkoly).Select(d => d.ListaKlas).Single();
               
                var bind = listaKlas.Select(k => k.NazwaKlasy).ToList();
                listaKlasListBox.Items.AddRange(bind.ToArray());
                var przedmioty = db.ListaSzkol.Where(sz => sz.NazwaSzkoly == nazwaSzkoly).Select(sz => sz.Przedmioty).Single();
                foreach (Przedmiot p in przedmioty)
                {
                    nauczanePrzedmiotyListBox.Items.Add(p.NazwaPrzedmiotu);
                }
            }
        }

        private bool CzyPosiadaJuzTenPrzedmiot(string nazwaPrzedmiotu)
        {
            using (var db = new MojContext())
            {
                var przedmioty = db.ListaSzkol.Where(sz => sz.NazwaSzkoly == nazwaSzkoly).Select(sz => sz.Przedmioty).Single();
                var przedmiot = przedmioty.Where(p => p.NazwaPrzedmiotu.ToLower() == nazwaPrzedmiotu.ToLower()).SingleOrDefault();
                if (przedmiot == null)
                    return false;
                else
                {
                    PowiadomUzytkownikaPowielenie();
                    return true;
                }
            }
        }

        private void PowiadomUzytkownikaPowielenie()
        {
            MessageBox.Show("Ta szkoła ma już zapisany ten przedmiot!", "!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
    }
}
