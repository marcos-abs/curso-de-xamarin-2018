using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel; // necessário para utilizar INotifyPropertyChanged.
using Xamarin.Forms; // necessário para utilizar a classe Command.
using App1_NossoChat.Model; // necessário para utilizar as classes do projeto.
using App1_NossoChat.Service; // necessário para utilizar a classe de WebServices do projeto.
using Newtonsoft.Json; // necessário para utilizar as classes Serialize e Deserialize.

namespace App1_NossoChat.ViewModel {
    public class PaginaInicialViewModel : INotifyPropertyChanged {

        private string _nome;
        private string _senha;
        private string _mensagem;

        public string Nome { get { return _nome;  } set { _nome = value; PropertyChanged(this, new PropertyChangedEventArgs("Nome")); } }
        public string Senha { get { return _senha; } set { _senha = value; PropertyChanged(this, new PropertyChangedEventArgs("Senha")); } }
        public string Mensagem { get { return _mensagem; } set { _mensagem = value; PropertyChanged(this, new PropertyChangedEventArgs("Mensagem")); } }

        public Command AcessarCommand { get; set; }

        public PaginaInicialViewModel() {
            AcessarCommand = new Command(Acessar);
        }

        private void Acessar() {
            var user = new Usuario();
            user.nome = Nome;
            user.password = Senha;

            var usuarioLogado = ServiceWS.GetUsuario(user);
            if(usuarioLogado == null) {
                Mensagem = "Usuário/Senha incorreto(a)(s).";
            } else {
                App.Current.Properties["LOGIN"] = JsonConvert.SerializeObject(usuarioLogado);
                App.Current.MainPage = new NavigationPage(new View.Chats());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
