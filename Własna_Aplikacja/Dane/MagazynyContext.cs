using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Własna_Aplikacja
{
  public class MagazynyContext:DbContext
    {
        public DbSet<Magazyn> Magazyny { get; set; }

        public DbSet<Towar> Towary { get; set; }

    }
}
