using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsApp1
{
    public class Dyrektor
    {
        [ForeignKey("Szkola")]
        public int DyrektorID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int LogowanieID { get; set; }
        public int SzkolaID { get; set; }
        public int AdresID { get; set; }
        public byte[] Zdjecie { get; set; }
        public DateTime DataUrodzenia { get; set; }
        [ForeignKey("AdresID")]
        public Adres Adres { get; set; }
        [ForeignKey("SzkolaID")]
        public Szkola Szkola { get; set; }
        [ForeignKey("LogowanieID")]
        public Logowanie Logowanie { get; set; }



    }
}
