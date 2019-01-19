using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Własna_Aplikacja
{
    public class StanMagazynowyViewModel : INotifyPropertyChanged, IViewModel
    {

        public StanMagazynowyViewModel(MagazynyModel model, Magazyn wybranyMagazyn)
        {
            this.Model = model;
            this.wybranyMagazyn = model.Magazyny.FirstOrDefault(x => x.IdMagazynu == wybranyMagazyn.IdMagazynu);
            this.OdswiezTowary();
            this.OdswiezStok();
            this.OdswiezWartoscStoku();
            this.OdswiezSegmenty();

            this.EdytujCommand = new RelayCommand(
            action => this.Edytuj()
            , enable => this.CzyWybranoTowar()
            );
            this.DodajCommand = new RelayCommand(
            action => this.Dodaj()
            );
        }

        public MagazynyModel Model { get; set; }

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

        private IEnumerable<Towar> towary;
        public IEnumerable<Towar> Towary
        {
            get
            {
                return this.towary;
            }


            set
            {
                this.towary = value;

                this.OnPropertyChanged();
            }
        }

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

                this.OdswiezTowary();
                this.OdswiezStok();
                this.OdswiezWartoscStoku();
                this.OdswiezSegmenty();
                this.OnPropertyChanged();
            }
        }

        private void OdswiezTowary()
        {
            Towary = wybranyMagazyn.Towary.ToList();
        }
        private void OdswiezStok()
        {
            Stok = Model.ObliczStok(wybranyMagazyn);
        }
        private void OdswiezWartoscStoku()
        {
            WartoscStoku = Model.ObliczWartoscStoku(wybranyMagazyn);
        }
        private void OdswiezSegmenty()
        {
            Segmenty = Model.Segmenty(wybranyMagazyn);
        }
        private List<Grupy> segmenty;
        public List<Grupy> Segmenty
        {
            get
            {
                return this.segmenty;
            }


            set
            {
                this.segmenty = value;

                this.OnPropertyChanged();
            }
        }

        private double stok;
        public double Stok
        {
            get
            {
                return this.stok;
            }


            set
            {
                this.stok = value;

                this.OnPropertyChanged();
            }
        }

        private double wartoscStoku;
        public double WartoscStoku
        {
            get
            {
                return this.wartoscStoku;
            }


            set
            {
                this.wartoscStoku = value;

                this.OnPropertyChanged();
            }
        }



        public bool CzyWybranoTowar() { return !(wybranyTowar == null); }

        public void Edytuj() { Mediator.Notify("PokazEdycje", ""); }
        public void Dodaj() { Mediator.Notify("PokazEdycjeNowego", ""); }
        public ICommand EdytujCommand { get; private set; }
        public ICommand DodajCommand { get; private set; }
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
