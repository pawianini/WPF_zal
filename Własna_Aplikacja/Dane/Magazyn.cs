using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Własna_Aplikacja
{
   public class Magazyn
    {
        public Magazyn()
        {
            Towary= new List<Towar>();
        }

        [Key]
        public int IdMagazynu { get; set; }

        public string Nazwa { get; set; }

        public string Okreg { get; set; }

        public Adres Adres { get; set; }

        public virtual List<Towar> Towary { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Okreg, Nazwa);
        }

    }
}
