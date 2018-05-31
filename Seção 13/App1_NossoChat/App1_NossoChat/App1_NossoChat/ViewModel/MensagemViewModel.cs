using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel; // INotifyPropertyChanged.
using App1_NossoChat.Model;
using App1_NossoChat.Service;
using Xamarin.Forms; // Binding + Command.
using System.Linq; // OrderBy para List<Chat>.
using App1_NossoChat.Util; // GetUsuarioLogado.

namespace App1_NossoChat.ViewModel {
    public class MensagemViewModel : INotifyPropertyChanged {

        // Encapsulamento do SelectedItemChat para o OnPropertyChanged funcionar.
        private StackLayout SL;
        private List<Mensagem> _mensagens;
        public List<Mensagem> Mensagens {
            get {
                return _mensagens;
            }
            set {
                _mensagens = value;
                OnPropertyChanged("Mensagem");
                ShowOnScreen();
            }
        }

        public MensagemViewModel(Chat chat, StackLayout SLMensagemContainer) {
            SL = SLMensagemContainer;
            Mensagens = ServiceWS.GetMensagensChat(chat);
        }

        private Xamarin.Forms.View CriarMensagemPropria(Mensagem mensagem) {
            var layout = new StackLayout() {                    // StackLayout do XAML
                Padding = 5,                                    // StackLayout do XAML
                BackgroundColor = Color.FromHex("#5ED055"),     // StackLayout do XAML
                HorizontalOptions = LayoutOptions.End           // StackLayout do XAML
            };                                                  // StackLayout do XAML
            var label = new Label() {                           // Label do XAML
                TextColor = Color.White,                        // Label do XAML
                Text = mensagem.mensagem                        // Label do XAML
            };                                                  // Label do XAML

            layout.Children.Add(label);
            return layout;
        }

        private Xamarin.Forms.View CriarMensagemOutrosUsuarios(Mensagem mensagem) {
            var labelNome = new Label() {                       // Label do XAML
                Text = mensagem.usuario.nome,                   // Label do XAML
                FontSize = 10,                                  // Label do XAML
                TextColor = Color.FromHex("#5ED055")            // Label do XAML
            };                                                  // Label do XAML
            var labelMensagem = new Label() {                   // Label do XAML
                Text = mensagem.mensagem,                       // Label do XAML
                TextColor = Color.FromHex("#5ED055")            // Label do XAML
            };                                                  // Label do XAML

            var SL = new StackLayout();                         // StackLaout do XAML

            SL.Children.Add(labelNome);                         // StackLaout do XAML
            SL.Children.Add(labelMensagem);                     // StackLaout do XAML

            var frame = new Frame() {                           // Frame do XAML
                BorderColor = Color.FromHex("#5ED055"),         // OutlineColor is obsolete use BorderColor.
                CornerRadius = 0,                               // Frame do XAML
                HorizontalOptions = LayoutOptions.Start         // Frame do XAML
            };                                                  // Frame do XAML

            frame.Content = SL;                                 // Frame do XAML

            return frame;
        }

        private void ShowOnScreen() {
            var usuario = UsuarioUtil.GetUsuarioLogado();
            SL.Children.Clear();
            foreach(var msg in Mensagens) {
                if(msg.usuario.id == usuario.id) {
                    SL.Children.Add(CriarMensagemPropria(msg));
                } else {
                    SL.Children.Add(CriarMensagemOutrosUsuarios(msg));
                }
            }
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
