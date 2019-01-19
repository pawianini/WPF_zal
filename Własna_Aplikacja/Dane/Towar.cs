using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Własna_Aplikacja
{
    public class Towar
    {
        [Key]
        public int Id { get; set; }

        public string NazwaTowaru { get; set; }

        public string Segment { get; set; }

        public double Ilosc { get; set; }

        public double CenaJednostkowa { get; set; }
        [ForeignKey("Magazyn")]
        public int IdMagazynu { get; set; }

        public virtual Magazyn Magazyn { get; set; }

    }
}
