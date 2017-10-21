using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WindowsFormsApp1
{
    public class Szkola
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SzkolaID { get; set; }
        public string NazwaSzkoly { get; set; }
        public int AdresID { get; set; }
        public int DyrektorID { get; set; }
        public string TypSzkoly { get; set; }
        [ForeignKey("AdresID")]
        public Adres AdresSzkoly { get; set; }
        public int MyProperty { get; set; }
        [ForeignKey("DyrektorID")]
        public virtual Dyrektor Dyrektor { get; set; }
        public virtual ICollection<Klasa> ListaKlas { get; set; } = new HashSet<Klasa>();
        public virtual ICollection<Nauczyciel> ListaNauczycieli { get; set; } = new HashSet<Nauczyciel>();
        public virtual ICollection<Przedmiot> Przedmioty { get; set; } = new HashSet<Przedmiot>();
       }
    
}
