using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Własna_Aplikacja
{
    public interface IViewModel
    {
        MagazynyModel Model { get; set; }
        Magazyn WybranyMagazyn { get; set; }
    }
}
