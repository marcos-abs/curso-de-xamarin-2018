using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel; // INotifyPropertyChanged.
using App1_NossoChat.Model;
using App1_NossoChat.Service;
using Xamarin.Forms; // Binding + Command.
using System.Linq; // OrderBy para List<Chat>.


namespace App1_NossoChat.ViewModel {
    public class MensagemViewModel : INotifyPropertyChanged {
        public MensagemViewModel(Chat chat) {
            //TODO Pesquisa e apresentação na tela.
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Para não ocorrer Exceptions
        private void OnPropertyChanged(string PropertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}
