using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Własna_Aplikacja
{
    public class TowarEdycjaViewModel : INotifyPropertyChanged, IViewModel
    {

        public TowarEdycjaViewModel(MagazynyModel model)
        {

            this.Model = model;

            this.ZapiszCommand = new RelayCommand(
                action => this.Zapisz()
                ,enable => this.CzyWypelnione()
              );
        }

        public TowarEdycjaViewModel(MagazynyModel model, Magazyn wybranyMagazyn) : this(model)
        {
            this.wybranyMagazyn = model.Magazyny.FirstOrDefault(x => x.IdMagazynu == wybranyMagazyn.IdMagazynu);
            this.wybranyTowar = new Towar();
            //this.wybranyMagazyn.Towary.Add(wybranyTowar);
       
        }

        public TowarEdycjaViewModel(MagazynyModel model, Magazyn wybranyMagazyn, Towar wybranyTowar):this(model)
        {
            this.wybranyMagazyn = model.Magazyny.FirstOrDefault(x => x.IdMagazynu == wybranyMagazyn.IdMagazynu);
            this.wybranyTowar = wybranyMagazyn.Towary.FirstOrDefault(x => x.Id == wybranyTowar.Id);
        }

        public MagazynyModel Model { get; set; }
        private Magazyn wybranyMagazyn;
        public Magazyn WybranyMagazyn
        {
            get
            {
                return this.wybranyMagazyn;
            }


            set
            {
                this.wybranyMagazyn = value;

                this.OnPropertyChanged();

            }
        }

        private Towar wybranyTowar;
        public Towar WybranyTowar
        {
            get
            {
                return this.wybranyTowar;
            }


            set
            {
                this.wybranyTowar = value;

                this.OnPropertyChanged();
            }
        }

      //  private string nazwaTowaru;
        public string NazwaTowaru
        {
            get
            {
                return this.wybranyTowar.NazwaTowaru;
            }


            set
            {
                this.wybranyTowar.NazwaTowaru = value;

                this.OnPropertyChanged();
            }
        }

      //  private string segment;
        public string Segment
        {
            get
            {
                return this.wybranyTowar.Segment;
            }


            set
            {
                this.wybranyTowar.Segment = value;

                this.OnPropertyChanged();
            }
        }

       // private double ilosc;
        public double Ilosc
        {
            get
            {
                return this.wybranyTowar.Ilosc;
            }


            set
            {
                this.wybranyTowar.Ilosc = value;

                this.OnPropertyChanged();
            }
        }

      //  private double cenaJednostkowa;
        public double CenaJednostkowa
        {
            get
            {
                return this.wybranyTowar.CenaJednostkowa;
            }


            set
            {
                this.wybranyTowar.CenaJednostkowa = value;

                this.OnPropertyChanged();
            }
        }

 

        public bool CzyWypelnione()
        {
            return !String.IsNullOrWhiteSpace(NazwaTowaru) &&
            !String.IsNullOrWhiteSpace(Segment);
        }
        public void Zapisz()
        {
            if (wybranyMagazyn.Towary.Contains(wybranyTowar))
            {
                Model.Zapisz();
                System.Windows.MessageBox.Show("Zapisano Towar");
            }
            else
            {

                Model.DodajTowar(wybranyMagazyn, wybranyTowar);
                this.wybranyTowar = new Towar();
                System.Windows.MessageBox.Show("Dodano Towar");
            }
        }
        public ICommand ZapiszCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(
            [System.Runtime.CompilerServices.CallerMemberName]
            string propertyName = "")
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
