using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DziennikElektroniczny
{
    public static class KlasaPomocnicza
    {
        public static string GenerujHaslo(int dlugosc)
        {
            const string zbior = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890*&%$#@!";
            StringBuilder wynik = new StringBuilder();
            Random rnd = new Random();
            while (dlugosc > 0)
            {
                wynik.Append(zbior[rnd.Next(zbior.Length)]);
                dlugosc--;
            }
            return wynik.ToString();
        }

        public static void CzySameLiczby(object sender, EventArgs e)
        {
            if(sender as TextBox!=null)
            {
                if((sender as TextBox).Text.Any(c => !char.IsNumber(c)))
                {

                }
            }
        }

        private static Random random;
        private static object syncObj = new object();
        public static int GenerujLosowyCiagLiczb(int min, int max)//min to min dlugosc liczb dodana do loginu do logowania
        {
            lock (syncObj)
            {
                if (random == null)
                    random = new Random(); // Or exception...
                return random.Next(min, max);
            }
        }

        public static void Wyloguj(object sender)
        {
            Form oknoDoZamkniecia = (sender as Button).Parent.FindForm();


            oknoDoZamkniecia.Hide();
            PaneLogowania pl = new PaneLogowania();
            pl.Show();

        }

        public static bool CzyWypelnionePola(object sender)
        {
            List<TextBox> textBoxy = (sender as Form).Controls.OfType<TextBox>().ToList();
            List<ComboBox> comboBoxy = (sender as Form).Controls.OfType<ComboBox>().ToList();
            if (textBoxy.Any(t => t.Text == null || t.Text == string.Empty && t.Text.Length < 2))
            {
                return false;
            } 

            return true;
            

        }
    }

    
}
