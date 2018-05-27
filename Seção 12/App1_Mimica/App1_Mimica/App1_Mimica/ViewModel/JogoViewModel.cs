using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using System.ComponentModel;
using App1_Mimica.Model;

namespace App1_Mimica.ViewModel {
    public class JogoViewModel : INotifyPropertyChanged {

        public Grupo Grupo { get; set; }
        public string NomeGrupo { get; set; }

        private byte _PalavraPontuacao;
        public byte PalavraPontuacao { get { return _PalavraPontuacao; } set { _PalavraPontuacao = value; OnPropertyChanged("PalavraPontuacao"); } }

        private string _Palavra;
        public string Palavra { get { return _Palavra; } set { _Palavra = value; OnPropertyChanged("Palavra"); } }

        private string _TextoContagem;
        public string TextoContagem { get { return _TextoContagem; } set { _TextoContagem = value; OnPropertyChanged("TextoContagem"); } }

        private bool _IsVisibleContainerContagem;
        public bool IsVisibleContainerContagem { get { return _IsVisibleContainerContagem; } set { _IsVisibleContainerContagem = value; OnPropertyChanged("IsVisibleContainerContagem"); } }

        private bool _IsVisibleContainerIniciar;
        public bool IsVisibleContainerIniciar { get { return _IsVisibleContainerIniciar; } set { _IsVisibleContainerIniciar = value; OnPropertyChanged("IsVisibleContainerIniciar"); } }

        private bool _IsVisibleBtnMostrar;
        public bool IsVisibleBtnMostrar { get { return _IsVisibleBtnMostrar; } set { _IsVisibleBtnMostrar = value; OnPropertyChanged("IsVisibleBtnMostrar"); } }

        public Command MostrarPalavra { get; set; }
        public Command Acertou { get; set; }
        public Command Errou { get; set; }
        public Command Iniciar { get; set; }

        public JogoViewModel(Grupo grupo) {

            Grupo = grupo;
            NomeGrupo = grupo.Nome;

            IsVisibleContainerContagem = false;
            IsVisibleContainerIniciar = false;
            IsVisibleBtnMostrar = true;

            Palavra = "****************************";

            MostrarPalavra = new Command(MostrarPalavraAction);
            Acertou = new Command(AcertouAction);
            Errou = new Command(ErrouAction);
            Iniciar = new Command(IniciarAction);
        }

        private void MostrarPalavraAction() {
            PalavraPontuacao = 3;
            Palavra = "Sentar";
            IsVisibleBtnMostrar = false;
            IsVisibleContainerIniciar = true;
        }

        private void IniciarAction() {
            IsVisibleContainerIniciar = false;
            IsVisibleContainerContagem = true;

            //TODO Quando o tempo terminar, parar a contagem/apresentação.
            int i = Armazenamento.Armazenamento.Jogo.TempoPalavra; // erro de exceção.
            TextoContagem = i.ToString();
            i--;

            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                TextoContagem = i.ToString();
                i--;
                if(i < 0) {
                    TextoContagem = "Esgotou o tempo";
                }
                return true;
            });
        }

        private void AcertouAction() {
            Grupo.Pontuacao += PalavraPontuacao;
            GoProximoGrupo();
        }

        private void GoProximoGrupo() {
            //TODO Verificar se a rodada terminou
            Grupo grupo;
            if (Armazenamento.Armazenamento.Jogo.Grupo1 == Grupo) {
                grupo = Armazenamento.Armazenamento.Jogo.Grupo2;
            } else {
                grupo = Armazenamento.Armazenamento.Jogo.Grupo1;
            }
            App.Current.MainPage = new View.Jogo(grupo);
        }
        private void ErrouAction() {
            GoProximoGrupo();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string NameProperty) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }
    }
}
