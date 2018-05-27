using System;
using System.Collections.Generic;
using System.Text;

using App1_Mimica.Model; // para ter acesso as classes modelo do projeto.
using System.ComponentModel; // para implementar a interface INotifyPropertyChanged.
using Xamarin.Forms; // para ter acesso ao Tipo Command.
// using App1_Mimica.Armazenamento; // para ter acesso as classes de armazenamento do jogo. *** DESNECESSARIO PQ A CLASSE E O NAMESPACE TEM O MESMO NOME ***

namespace App1_Mimica.ViewModel {
    public class InicioViewModel : INotifyPropertyChanged {

        public Jogo Jogo { get; set; }
        public Command IniciarCommand { get; set; }

        public InicioViewModel() {
            IniciarCommand = new Command(IniciarJogo);
            Jogo = new Jogo(); // observe que a variavel Jogo não refere-se ao tipo e sim a variavel.
            Jogo.Grupo1 = new Grupo();
            Jogo.Grupo2 = new Grupo();

            Jogo.TempoPalavra = 120;
            Jogo.Rodadas = 7;
        }

        private void IniciarJogo() {

            Armazenamento.Armazenamento.Jogo = this.Jogo; // sem o uso do using pq utiliza o caminho completo da classe no projeto.
            Armazenamento.Armazenamento.RodadaAtual = 1;
            App.Current.MainPage = new View.Jogo(Jogo.Grupo1);
        }

        public event PropertyChangedEventHandler PropertyChanged; // requisito para que funcione INotifyPropertyChanged.

        private void onPropertyChanged(string NameProperty) {
            if(PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }
    }
}
