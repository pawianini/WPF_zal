using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Własna_Aplikacja
{
    public class MagazynyInitializer : DropCreateDatabaseIfModelChanges<MagazynyContext>
    {
        protected override void Seed(MagazynyContext context)
        {
            Adres addres1 = new Adres()
            {
                Ulica = "Wesola",
                Numer = "7",
                Miasto = "Kurakowo",
                KodPocztowy = "00-690"
            };

            Adres addres2 = new Adres()
            {
                Ulica = "Smieszna",
                Numer = "69",
                Miasto = "Wadowice",
                KodPocztowy = "02-137"
            };

            Magazyn magazyn1 = new Magazyn()
            {
                Adres = addres1,
                Nazwa = "Srubka - Janusz Wasacz sp. z.o.o.",
                Okreg = "Mazowsze"
            };

            Magazyn magazyn2 = new Magazyn()
            {
                Adres = addres2,
                Nazwa = "Srubka - Sebastian Nosacz sp. k.",
                Okreg = "Malopolska"
            };

            Towar towar1 = new Towar()
            {
                NazwaTowaru = "Błotnik",

                Segment = "A",

                Ilosc = 10,

                CenaJednostkowa = 800
            };
            Towar towar2 = new Towar()
            {
                NazwaTowaru = "Drzwi",

                Segment = "A",

                Ilosc = 7,

                CenaJednostkowa = 1000
            };

            Towar towar3 = new Towar()
            {
                NazwaTowaru = "Silnik",

                Segment = "B",

                Ilosc = 5,

                CenaJednostkowa = 5000
            };
             Towar towar4 = new Towar()
             {
                 NazwaTowaru = "Skrzynia Biegów",

                 Segment = "B",

                 Ilosc = 4,

                 CenaJednostkowa = 6000
             };

            Towar towar5 = new Towar()
            {
                NazwaTowaru = "Silnik",

                Segment = "B",

                Ilosc = 5,

                CenaJednostkowa = 5000
            };
            Towar towar6 = new Towar()
            {
                NazwaTowaru = "Skrzynia Biegów",

                Segment = "B",

                Ilosc = 4,

                CenaJednostkowa = 6000
            };

            magazyn1.Towary.AddRange(new Towar[] { towar1, towar2, towar3, towar4 });
            magazyn2.Towary.AddRange(new Towar[] { towar5, towar6 });
            context.Magazyny.AddRange(new Magazyn[] { magazyn1, magazyn2 });
            context.SaveChanges();
        }
    }

}
    
