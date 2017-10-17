using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsApp1
{
    public class Przedmiot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrzedmiotID { get; set; }
        public string NazwaPrzedmiotu { get; set; }
        public virtual ICollection<Uczen> Uczniowie { get; set; } = new HashSet<Uczen>();
        public virtual ICollection<Klasa> ListaKlas { get; set; } = new HashSet<Klasa>();
        public virtual ICollection<Szkola> Szkoly { get; set; } = new HashSet<Szkola>();
        public virtual ICollection<Nauczyciel> Nauczyciele { get; set; } = new HashSet<Nauczyciel>();
    }
}
