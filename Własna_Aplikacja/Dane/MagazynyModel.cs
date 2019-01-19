using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Własna_Aplikacja
{
   public class MagazynyModel
    {
        protected readonly MagazynyContext context;
        public MagazynyModel()
        {
            context = new MagazynyContext();
        }

        public List<Magazyn> Magazyny
        {
            get
            {
              return new List<Magazyn>(context.Magazyny);
            }
        }
    public void DodajTowar(Magazyn magazyn, Towar towar) {
            magazyn.Towary.Add(towar);
            context.SaveChanges();
        }

        public void Zapisz() { context.SaveChanges(); }

        public double ObliczStok(Magazyn magazyn) { return magazyn.Towary.Sum(t => t.Ilosc); }
        public double ObliczWartoscStoku(Magazyn magazyn) { return magazyn.Towary.Sum(t => t.Ilosc*t.CenaJednostkowa); }
        public List<Grupy> Segmenty(Magazyn magazyn)
        {
            return (from m in magazyn.Towary
             group m by m.Segment into Grouping
             select
            new Grupy { Segment = Grouping.Key, Ilosc = Grouping.Sum(t => t.Ilosc), Wartosc = Grouping.Sum(t => t.Ilosc * t.CenaJednostkowa) }).OrderBy(x => x.Segment).ToList();
        }
    }
}
