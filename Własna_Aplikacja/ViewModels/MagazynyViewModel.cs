using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Własna_Aplikacja
{
    public class MagazynyViewModel : INotifyPropertyChanged, IViewModel
    {
        public MagazynyViewModel(MagazynyModel model)
        {
            this.Model = model;
           
            this.PokazStanyCommand = new RelayCommand(
         action => this.PokazStany()
         , enable => this.CzyWybrany()
            );

            this.OdswiezMagazyny();
        }
        public MagazynyViewModel(MagazynyModel model, Magazyn wybranyMagazyn):this(model)
        {
            this.wybranyMagazyn = model.Magazyny.FirstOrDefault(x => x.IdMagazynu == wybranyMagazyn.IdMagazynu);
        }




        public bool CzyWybrany()
        {
            
            return (this.WybranyMagazyn != null);
        }


        public void PokazStany() {
            Mediator.Notify("PokazStany", "");
        }
        public MagazynyModel Model { get; set; }
        private void OdswiezMagazyny()
        {
            this.Magazyny = Model.Magazyny;
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
                
                this.OnPropertyChanged();
            }
        }

        private IEnumerable<Magazyn> magazyny;
        public IEnumerable<Magazyn> Magazyny
        {
            get
            {
                return this.magazyny;
            }
    

            set
            {
                this.magazyny = value;
                this.OnPropertyChanged();
            }
        }

        public ICommand PokazStanyCommand { get; private set; }
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
