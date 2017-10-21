using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1;


namespace DziennikElektroniczny
{
    public partial class PaneLogowania : Form
    {
        public PaneLogowania()
        {
           
            InitializeComponent();
            this.FormClosed += (s, e) =>
            {
                Application.Exit();
            };
        }

        private void zalogujButton_Click(object sender, EventArgs e)
        {
            Zaloguj();
        }

        private void Zaloguj()
        {
            using (var db = new MojContext())
            {
                try
                {
                    var query = db.Logowania.Where(l => l.Login == loginTextBox.Text && l.Haslo == hasloTextBox.Text).Single();

                    string Rola = query.Rola;

                    switch (Rola)
                    {
                        case "Administrator":
                            PanelAdmina pa = new PanelAdmina();
                            pa.Show();
                            this.Hide();
                            break;
                        case "Dyrektor":
                            PanelDyrektora pd = new PanelDyrektora(query.LogowanieID);
                            pd.Show();
                            this.Hide();
                            break;
                        case "Nauczyciel":
                            PanelNauczyciela pn = new PanelNauczyciela(query.LogowanieID);
                            pn.Show();
                            this.Hide();
                            break;
                        case "Uczen":
                            PanelUcznia pu = new PanelUcznia(query.LogowanieID);
                            pu.Show();
                            this.Hide();
                            break;
                    }
                }

                catch (InvalidOperationException ex)
                {
                    MessageBox.Show("Nie ma takiego użytkownika w bazie");
                }

            }
        }

        private void PaneLogowania_Load(object sender, EventArgs e)
        {
           DodajAdminaJesliGoNieMa();
        }

        private static void DodajAdminaJesliGoNieMa()
        {
            using (var db = new MojContext())
            {
                var query = db.Logowania.Where(l => l.LogowanieID == 1).SingleOrDefault();
                if (query == null)
                {
                    Logowanie admin = new Logowanie
                    {
                        Login = "admin",
                        Haslo = "admin"
                    };
                    admin.Rola = "Administrator";
                    db.Logowania.Add(admin);
                    db.SaveChanges();

                }



            }
        }
    }
 } 
