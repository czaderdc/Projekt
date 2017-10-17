using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Uczen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UczenID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int AdresID { get; set; }
        public int KlasaID { get; set; }
        public int LogowanieID { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public byte[] Zdjecie { get; set; }
        [ForeignKey("LogowanieID")]
        public Logowanie Logowanie { get; set; }
        [ForeignKey("AdresID")]
        public Adres AdresUcznia { get; set; }
        [ForeignKey("KlasaID")]
        public virtual Klasa Klasa { get; set; }

        public virtual ICollection<Przedmiot> Przedmioty { get; set; } = new HashSet<Przedmiot>();
        public virtual ICollection<UczenPrzedmiotOcena> Oceny { get; set; } = new HashSet<UczenPrzedmiotOcena>();

    }
}
