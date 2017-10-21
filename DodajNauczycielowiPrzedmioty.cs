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

namespace DziennikElektroniczny
{
    public partial class DodajNauczycielowiPrzedmioty : Form
    {
        string Szkola;
        int dyrektor;
        int nauczyciel;
        Form poprzedniaForm;
        public DodajNauczycielowiPrzedmioty(int idNauczyciela, int idDyrektora, string nazwaSzkoly, Form skadPrzybylem)
        {
            InitializeComponent();
            Szkola = nazwaSzkoly;
            dyrektor = idDyrektora;
            nauczyciel = idNauczyciela;
            poprzedniaForm = skadPrzybylem;
        }

        private void DodajNauczycielowiPrzedmioty_Load(object sender, EventArgs e)
        {
            dostepnePrzedmiotyListBox.SelectedValueChanged += (s, eventargs) =>
            {
                ListBox box = s as ListBox;
                if(box!= null && box.SelectedItem != null)
                {
                    wybranePrzedmiotyListBox.Items.Add(box.SelectedItem.ToString());
                }
            };

            using (var db = new MojContext())
            {
                var Przedmioty = db.ListaSzkol.Where(sz => sz.NazwaSzkoly == Szkola).Select(sz => sz.Przedmioty).Single();
                UzupelnijNauczanePrzedmiotyListBox(Przedmioty);
            }
        }

        private void UzupelnijNauczanePrzedmiotyListBox(ICollection<Przedmiot> przedmioty)
        {
            foreach(Przedmiot p in przedmioty)
            {
                dostepnePrzedmiotyListBox.Items.Add(p.NazwaPrzedmiotu);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(nauczyciel.ToString());
            using (var db = new MojContext())
                {
                    try
                    {
                        var belfer = db.Nauczyciele.Where(n => n.NauczycielID == nauczyciel).Single();
                    MessageBox.Show(belfer.Imie);
                    foreach (string s in wybranePrzedmiotyListBox.Items)
                     {
                        
                        var przedmiot = db.Przedmioty.Where(p => p.NazwaPrzedmiotu == s).SingleOrDefault();
                      
                        belfer.Przedmioty.Add(przedmiot);
                        DataGridView dg = poprzedniaForm.Controls.OfType<DataGridView>().Single();
                        foreach(DataGridViewRow dr in dg.Rows)
                        {
                            MessageBox.Show(dr.Index.ToString());
                            if(Int32.Parse(dr.Cells[3].Value.ToString()) == belfer.NauczycielID)
                            {
                                DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)dg.Rows[dr.Index].Cells[1];
                                cell.Items.Add(przedmiot.NazwaPrzedmiotu);
                                break;//trzeba wyskoczyc bo datagridview mi generuje dodatkowy wiersz i rzuca wyjątek powieniem to poprawić, bo wyglada tragicznie
                            }
                        }

                            
                     }
                    db.SaveChanges();
                    }
                    
                    
                    catch (ArgumentException ex)
                    {
                    MessageBox.Show("tutaj");
                    }
                

              
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            poprzedniaForm.Show();
        }
    }
}
