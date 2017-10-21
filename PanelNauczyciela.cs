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
    public partial class PanelNauczyciela : Form
    {
        int idNauczyciela;
        public PanelNauczyciela(int id)
        {
            InitializeComponent();
            idNauczyciela = id;
        }

        private void PanelNauczyciela_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSize = true;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            using (var db = new MojContext())
            {
                var listaPrzedmiotow = db.Nauczyciele.Where(n => n.LogowanieID == idNauczyciela).Select(n => n.Przedmioty).Single();
                foreach (Przedmiot p in listaPrzedmiotow)
                {
                    przedmiotComboBox.Items.Add(p.NazwaPrzedmiotu);
                }
            }
            
            przedmiotComboBox.SelectedValueChanged += (s, ev) =>
            {
                using (var db = new MojContext())
                {
                    var listaPrzedmiotow = db.Nauczyciele.Where(n => n.LogowanieID == idNauczyciela).Select(n => n.Przedmioty).Single();
                    var zapisaneKlasy = listaPrzedmiotow.Where(p => p.NazwaPrzedmiotu == przedmiotComboBox.SelectedItem.ToString()).Select(p => p.ListaKlas).Single();
                    foreach (Klasa k in zapisaneKlasy)
                    {
                        klasaComboBox.Items.Add(k.NazwaKlasy);
                    }
                }
               
            };
            klasaComboBox.SelectedValueChanged += (s, ev) =>
             {
                 using (var db = new MojContext())
                 {
                     //zastosowac laod i zaladowac do pamieci rezultat aby nie wykonywac zbednych zapytan do bazy
                     var Uczniowie = db.Uczniowie.Where(u => u.Klasa.NazwaKlasy == klasaComboBox.SelectedItem.ToString()).Include(u=> u.Oceny.Select(up=> up.Przedmiot)).ToList();
                     dataGridView1.DataSource = null;

                     var bind = Uczniowie.Select(u =>
                         new
                         {
                             ImięUcznia = u.Imie,
                             NazwiskoUcznia = u.Nazwisko,
                             IDUcznia = u.UczenID

                         }).ToList();

                     List<DataGridViewComboBoxColumn> liczbaOcen = new List<DataGridViewComboBoxColumn>();
                     int lOcen = 5;
                     for (int i = 0; i < lOcen; i++)
                     {
                         liczbaOcen.Add(new DataGridViewComboBoxColumn());

                         dataGridView1.Columns.Add(liczbaOcen[i]);
                         dataGridView1.Columns[i].HeaderText = "Ocena" + (i + 1).ToString();
                     }
                     dataGridView1.Columns.Add("Imię", "Imię");
                     dataGridView1.Columns.Add("Nazwisko", "Nazwisko");
                     dataGridView1.Columns.Add("IDUCZNIADEBUG", "IDDEBUG");
                     dataGridView1.Columns[7].Visible = false;


                     List<int> listaDostpOcen = new List<int> { 1, 2, 3, 4, 5, 6 };
                     for (int i = 0; i < bind.Count; i++)
                     {
                         int rowIndex = dataGridView1.Rows.Add();
                         for (int j = 0; j < liczbaOcen.Count; j++)
                         {


                             DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)dataGridView1.Rows[rowIndex].Cells[j];
                             cell.Items.Clear();
                             foreach (int p in listaDostpOcen)
                             {

                                 cell.Items.Add(p.ToString());
                             }
                         }
                         dataGridView1.Rows[rowIndex].Cells[5].Value = bind[i].ImięUcznia;
                         dataGridView1.Rows[rowIndex].Cells[6].Value = bind[i].NazwiskoUcznia;
                         dataGridView1.Rows[rowIndex].Cells[7].Value = bind[i].IDUcznia;

                     }

                     //bindowanie ocen do comboboxcells
                          
                         int ik = 0;
                         foreach (Uczen u in Uczniowie)
                         {
                         int tenUczen;
                             if (u.UczenID == Int32.Parse(dataGridView1.Rows[ik].Cells[7].Value.ToString()))
                             {
                                tenUczen = u.UczenID;
                                 var oceny = u.Oceny.Where(up => up.UczenID == tenUczen && up.Przedmiot.NazwaPrzedmiotu == przedmiotComboBox.SelectedItem.ToString()).Select(up => up.Ocena).ToList();

                               

                                 for (int k = 0; k < oceny.Count; k++)
                                 {
                                 
                                    dataGridView1.Rows[ik].Cells[k].Value = oceny[k].ToString();
                                 }

                             }
                             ik++;
                         }


                     
                 }

             };

               
        }


        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (var db = new MojContext())
            {
             
            }
        }

        private void zapisOcenyButton_Click(object sender, EventArgs e)
        {
            var db = new MojContext();
            
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                List<int> oceny = new List<int>();
                for (int i = 0; i < 5; i++)
                {
                    if (dr.Cells[i].Value != null)
                    {
                        oceny.Add(Int32.Parse(dr.Cells[i].Value.ToString()));
                    }
                }
            
               
                    
                    var listaPrzedmiotow = db.Nauczyciele.Where(n => n.LogowanieID == idNauczyciela).Select(n => n.Przedmioty).Single();
                    var przedmiot = listaPrzedmiotow.Where(p => p.NazwaPrzedmiotu == przedmiotComboBox.SelectedItem.ToString()).Single();  
              

                int tenUczen;
                   
                        if (dr.Cells[7].Value != null)
                        {
                            tenUczen = Int32.Parse(dr.Cells[7].Value.ToString());
                            var uczen = db.Uczniowie.Where(u => u.UczenID ==tenUczen).Single();
                        
                            
                            for (int i = 0; i < oceny.Count; i++)
                            {
                                
                                uczen.Oceny.Add(new UczenPrzedmiotOcena
                                {
                                    Ocena = oceny[i],
                                    Uczen = uczen,
                                    Przedmiot = przedmiot,
                                    Opis = przedmiot.NazwaPrzedmiotu + "ocena" + (i + 1).ToString()
                                  });
                                 }
                        }
                    

                   
             
            }
            db.SaveChanges();
            db.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KlasaPomocnicza.Wyloguj(sender);
        }
    }
}
