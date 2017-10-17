using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsApp1
{
    public class UczenPrzedmiotOcena
    {
        public int UczenPrzedmiotOcenaID{ get; set; }
        public int UczenID { get; set; }
        public int PrzedmiotID { get; set; }
        public int Ocena { get; set; }
        public string Opis { get; set; }//potrzebny opis oceny w stylu IDoceny + nazwaprzemiotu aby móc ją łatwo zedytowac w razie potrzeby
        [ForeignKey("UczenID")]
        public Uczen Uczen { get; set; }
        [ForeignKey("PrzedmiotID")]
        public Przedmiot Przedmiot { get; set; }
    }
}
