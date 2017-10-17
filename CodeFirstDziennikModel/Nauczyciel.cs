using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsApp1
{
    public class Nauczyciel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NauczycielID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int AdresID { get; set; }
        public int LogowanieID { get; set; }
        public int SzkolaID { get; set; }
        public byte[] Zdjecie { get; set; }
        public virtual ICollection<Przedmiot> Przedmioty { get; set; } = new HashSet<Przedmiot>();
        [ForeignKey("LogowanieID")]
        public Logowanie Logowanie { get; set; }
        [ForeignKey("AdresID")]
        public Adres Adres { get; set; }
        [ForeignKey("SzkolaID")]
        public Szkola Szkola { get; set; }
        public int Dupa { get; set; }
    }
}
