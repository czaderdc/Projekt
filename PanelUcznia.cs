using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace DziennikElektroniczny
{
    public partial class PanelUcznia : Form
    {
        int IdUcznia;
        public PanelUcznia(int id)
        {
            InitializeComponent();
            IdUcznia = id;
        }

     

        private Image PobierzZdjecieBaza(byte[]zdjecie)
        {
            MemoryStream ms = new MemoryStream(zdjecie);
            Image fotka = Image.FromStream(ms);
            return fotka;
        }

        private void PanelUcznia_Load(object sender, EventArgs e)
        {
            

            using (var db = new MojContext())
            {
               // pictureBox1.Image = PobierzZdjecieBaza(db.Uczniowie.Where(u => u.UczenID == IdUcznia).Select(u => u.Zdjecie).Single());
                List<DataGridViewComboBoxColumn> comboKolumny = new List<DataGridViewComboBoxColumn>();
                
                var uczen = db.Uczniowie.Where(u => u.LogowanieID == IdUcznia).Include(u=> u.Oceny.Select(o=>o.Przedmiot)).Single();
                for (int i = 0; i < 5; i++)
                {
                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView1.Columns[i].HeaderText = "Ocena" + (i + 1).ToString();
                }
                dataGridView1.Columns.Add("Nazwa", "Nazwa Przedmiotu");
                var przedmioty = uczen.Oceny.Select(o => o.Przedmiot.NazwaPrzedmiotu).Distinct();
                foreach(string s in przedmioty)
                {
                    MessageBox.Show(s);
                }
               foreach(string p in przedmioty)
                {
                    int rowindex = dataGridView1.Rows.Add();
                   
                    var Oceny = uczen.Oceny.Where(o => o.Przedmiot.NazwaPrzedmiotu == p).Select(o => o.Ocena).ToList();
                    for (int i = 0; i < Oceny.Count; i++)
                    {
                        dataGridView1.Rows[rowindex].Cells[i].Value = Oceny[i].ToString();
                    }
                    dataGridView1.Rows[rowindex].Cells[5].Value = p;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            KlasaPomocnicza.Wyloguj(sender);
        }
    }
}
