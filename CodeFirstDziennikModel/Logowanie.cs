using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Logowanie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogowanieID { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; } // powinniec byc przechowywany hash hasła, ale dla ułatwienia przechowam je w bazie 1:1
        public string Rola { get; set; }
    }
}
