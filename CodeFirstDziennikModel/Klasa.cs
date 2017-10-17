using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsApp1
{
    public class Klasa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KlasaID { get; set; }
        public string NazwaKlasy { get; set; }
        public int SzkolaID { get; set; }
        [ForeignKey("SzkolaID")]
        public Szkola Szkola { get; set; }
        public ICollection<Przedmiot> PrzedmiotyKlasy { get; set; } = new HashSet<Przedmiot>();
        public ICollection<Uczen> Uczniowie { get; set; } = new HashSet<Uczen>();
    }
}
