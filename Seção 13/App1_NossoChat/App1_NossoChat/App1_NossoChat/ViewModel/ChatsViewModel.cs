using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel; // INotifyPropertyChanged.
using App1_NossoChat.Model;
using App1_NossoChat.Service;
using Xamarin.Forms; // Binding + Command.
using System.Linq; // OrderBy para List<Chat>.

namespace App1_NossoChat.ViewModel {
    public class ChatsViewModel : INotifyPropertyChanged {

        // Encapsulamento do SelectedItemChat para o OnPropertyChanged funcionar.
        private Chat _selectedItemChat;
        public Chat SelectedItemChat {
            get {
                return _selectedItemChat;
            }
            set {
                _selectedItemChat = value;
                OnPropertyChanged("SelectedItemChat");
                GoPaginaMensagem(value);
            }
        }

        private void GoPaginaMensagem(Chat chat) {
            if(chat != null) {
                SelectedItemChat = null; // não funciona sozinho, somente com o Mode=TwoWay no XAML.
                ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new View.Mensagem(chat));
            }
        }

        // Encapsulamento do List<Chat> para o OnPropertyChanged funcionar.
        private List<Chat> _chats;
        public List<Chat> Chats {
            get {
                return _chats;
            }
            set {
                _chats = value;
                OnPropertyChanged("Chats");
            }
        }
        public Command AdicionarCommand { get; set; }
        public Command OrdenarCommand { get; set; }
        public Command AtualizarCommand { get; set; }

        public ChatsViewModel() {
            Atualizar();

            AdicionarCommand = new Command(Adicionar);
            OrdenarCommand = new Command(Ordenar);
            AtualizarCommand = new Command(Atualizar);
        }

        private void Adicionar() {
            ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new View.CadastrarChat());
        }

        private void Ordenar() {
            Chats = Chats.OrderBy(a => a.nome).ToList(); //LINQ
        }

        private void Atualizar() {
            Chats = ServiceWS.GetChats();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        // Para não ocorrer Exceptions
        private void OnPropertyChanged(string PropertyName) {
            if(PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}
