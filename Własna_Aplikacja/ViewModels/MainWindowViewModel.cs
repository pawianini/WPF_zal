using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Własna_Aplikacja
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            Task.Run(() => Init());
        }

        private MagazynyModel model;
        internal void Init()
        {
            model = new MagazynyModel();
            this.viewModels.Add(new MagazynyViewModel(model));
            Mediator.Subscribe("PokazStany", PokazStany);
            Mediator.Subscribe("PokazEdycje", PokazEdycje);
            Mediator.Subscribe("PokazEdycjeNowego", PokazEdycjeNowego);
            this.SelectedViewModel = ViewModels[0];
        }

        private List<IViewModel> viewModels = new List<IViewModel>();
        public List<IViewModel> ViewModels { get { return viewModels; } }
        private IViewModel selectedViewModel;

        public IViewModel SelectedViewModel

        {

            get { return selectedViewModel; }

            set
            {
                selectedViewModel = value;
                OnPropertyChanged();

            }

        }
        public event PropertyChangedEventHandler PropertyChanged;
        public bool CzyKolejny() { return !(SelectedViewModel is MagazynyViewModel)&& !(SelectedViewModel==null); }
        public void Powrot()
        {

                ViewModels.Remove(SelectedViewModel);
            Magazyn wybranyMagazyn = ViewModels[ViewModels.Count - 1].WybranyMagazyn;
            ViewModels[ViewModels.Count - 1]=(IViewModel)Activator.CreateInstance(ViewModels[ViewModels.Count - 1].GetType(), model,wybranyMagazyn); 
                SelectedViewModel = ViewModels[ViewModels.Count - 1];
            
            }


     
        private ICommand powrotCommand;
        public ICommand PowrotCommand
        {
            get
            {
                // Opoznione tworzenie polecenia przy pierwszym uzyciu
                if (powrotCommand == null)
                {
                   powrotCommand = new RelayCommand(
                   action => this.Powrot(),
                   enable => this.CzyKolejny()
                   );
                }
                return powrotCommand;
            }
        }


        private void PokazStany(object arg) {
            ViewModels.Add(new StanMagazynowyViewModel(model, ((IViewModel)ViewModels[0]).WybranyMagazyn));
             SelectedViewModel = ViewModels[1];
          
        }
        private void PokazEdycje(object arg)
        {
            ViewModels.Add(new TowarEdycjaViewModel(model, ((IViewModel)ViewModels[1]).WybranyMagazyn, ((StanMagazynowyViewModel)ViewModels[1]).WybranyTowar));
            SelectedViewModel = ViewModels[2];
            ((TowarEdycjaViewModel)SelectedViewModel).WybranyTowar = ((StanMagazynowyViewModel)ViewModels[1]).WybranyTowar;
        }

        private void PokazEdycjeNowego(object arg)
        {
            ViewModels.Add(new TowarEdycjaViewModel(model, ((IViewModel)ViewModels[1]).WybranyMagazyn));
            SelectedViewModel = ViewModels[2];
          
        }

        private void OnPropertyChanged(
           [System.Runtime.CompilerServices.CallerMemberName]
            string propertyName = "")
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}


