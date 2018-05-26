using System;
using System.Collections.Generic;
using System.Text;

using App1_Mimica.Model; // para ter acesso as classes modelo do projeto.
using System.ComponentModel; // para implementar a interface INotifyPropertyChanged.
using Xamarin.Forms; // para ter acesso ao Tipo Command.

namespace App1_Mimica.ViewModel {
    public class InicioViewModel : INotifyPropertyChanged {

        public Jogo jogo { get; set; }
        public Command IniciarCommand { get; set; }

        public InicioViewModel() {
            IniciarCommand = new Command(IniciarJogo);
        }

        private void IniciarJogo() {
            App.Current.MainPage = new View.Jogo();
        }

        public event PropertyChangedEventHandler PropertyChanged; // requisito para que funcione INotifyPropertyChanged.

        private void onPropertyChanged(string NameProperty) {
            if(PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }
    }
}
