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
    public partial class PanelDyrektora : Form
    {
        int idDyrektora;
        string nazwaSzkoly;
        Szkola szkola;
        public PanelDyrektora(int id)
        {

            InitializeComponent();
            idDyrektora = id;         

        }

        private void WyswietlInfo(int id)
        {
            using (var context = new MojContext())
            {

                var query = (from D in context.Dyrektorzy where D.LogowanieID == id select D).Include(D => D.Szkola).Single();
                this.Text = "Witaj " + query.Imie + " " + "Panel Dyrektora Szkoły: " + query.Szkola.NazwaSzkoly;
                nazwaSzkoly = query.Szkola.NazwaSzkoly;
                szkola = query.Szkola;
                if (query.Szkola.ListaKlas.Count > 0)//?? tabela szkoła powinna mieć osobno listę nauczanych przedmiotów??
                {
                    dodajUczniaButton.Enabled = true;
                    dodajNauczycielaButton.Enabled = true;
                }

            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dataGridView1.Columns[2].Index && e.RowIndex >=0)
            {
                DodawaniePrzedmiotu du = new DodawaniePrzedmiotu(idDyrektora,this, nazwaSzkoly);//trzeba bedzie stworzy nowa forme
                du.Show();
            }
        }

        private void CzyDodanoKlasy()
        {
            using (var context = new MojContext())
            {
                var query = (from D in context.Dyrektorzy where D.LogowanieID == idDyrektora select D).Include(D => D.Szkola).Include(Name => Name.Szkola.ListaKlas).Include(n => n.Szkola.ListaKlas).Single();
                this.Text = "Witaj " + query.Imie + " " + "Panel Dyrektora Szkoły: " + query.Szkola.NazwaSzkoly;
                if (query.Szkola.ListaKlas.Count > 0)//?? tabela szkoła powinna mieć osobno listę nauczanych przedmiotów??
                {
                    dodajUczniaButton.Enabled = true;
                }
            }
        }

        private void PanelDyrektora_Load(object sender, EventArgs e)
        {
            ZarejestrujEventy();
            WylaczButtony();
            WyswietlInfo(idDyrektora);
        }

        private void CzySzkolaMaPrzypisanePrzedmioty()
        {
            using (var db = new MojContext())
            {
                var przedmiotyCount = db.ListaSzkol.Where(sz => sz.NazwaSzkoly == nazwaSzkoly).Select(sz => sz.Przedmioty).FirstOrDefault();
                if(przedmiotyCount!=null)
                {
                    dodajUczniaButton.Enabled = true;
                }
               
            }
        }

        private void ZarejestrujEventy()
        {
            this.Load += (s, e) =>
            {
                CzySzkolaMaPrzypisanePrzedmioty();
            };
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void WylaczButtony()
        {
            dodajUczniaButton.Enabled = false;
        }

        private void dodajUczniaButton_Click(object sender, EventArgs e)
        {
            
               
                DodawanieUcznia du = new DodawanieUcznia(nazwaSzkoly, this);
            this.Hide();
                du.Show();
            
        }

        private void dodajKlaseButton_Click(object sender, EventArgs e)
        {
            DodawanieKlasy dk = new DodawanieKlasy(nazwaSzkoly, this);
            dk.Show();
        }

        private void wyswietlNauczycieliButton_Click(object sender, EventArgs e)
        {
            WysweitlNauczycieli();
        }

        private void WysweitlNauczycieli()
        {
            using (var db = new MojContext())
            {
                //mogę porównywać prymitywne nazwa w zapytaniu entity ale nie moge uzywac extensino methods....
                var Nauczyciele = db.ListaSzkol.Where(s => s.NazwaSzkoly == nazwaSzkoly).Include(s => s.Przedmioty).Select(s => s.ListaNauczycieli.ToList()).Single();

                var result = (from N in Nauczyciele
                              select
                              new
                              {
                                  Nauczyciel = N,
                                  ImięNauczyciela = N.Imie,
                                  NauczanyPrzedmiot = N.Przedmioty
                              }).ToList();
                if (result.Count() == 0)
                {
                    MessageBox.Show("Ta szkoła nie posiada jeszcze żadnego przypisanego nauczyciela!");
                    dataGridView1.DataSource = null;
                }

                else
                {
                    DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
                    dataGridView1.Columns.Add("Imię", "Imię");
                    dataGridView1.Columns.Add(col);
                    col.HeaderText = "Nauczane Przedmioty";
                    DataGridViewButtonColumn bc = new DataGridViewButtonColumn();
                    dataGridView1.Columns.Add(bc);
                    bc.HeaderText = "Dodaj przedmiot";
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView1.AutoResizeRows();
                    for (int i = 0; i < result.Count; i++)
                    {
                        int rowIndex = dataGridView1.Rows.Add();
                        DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)dataGridView1.Rows[rowIndex].Cells[1];
                        cell.Items.Clear();
                        foreach (Przedmiot p in result[i].NauczanyPrzedmiot)
                        {
                            cell.Items.Add(p.NazwaPrzedmiotu);
                        }
                        dataGridView1.Rows[rowIndex].Cells[0].Value = result[i].ImięNauczyciela;
                        var buttonCell = (DataGridViewButtonCell)dataGridView1.Rows[rowIndex].Cells[2];
                        buttonCell.Value = "Zapisz na nowy przedmiot";
                    }
                }

            }
        }

        private void wylogujButton_Click(object sender, EventArgs e)
        {
            KlasaPomocnicza.Wyloguj(sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodawaniePrzedmiotu dp = new DodawaniePrzedmiotu(idDyrektora, this, nazwaSzkoly);
            dp.Show();
        }

        private void dodajNauczycielaButton_Click(object sender, EventArgs e)
        {
            DodawanieNauczyciela dn = new DodawanieNauczyciela(nazwaSzkoly);
            dn.Show();
        }
    }
}
