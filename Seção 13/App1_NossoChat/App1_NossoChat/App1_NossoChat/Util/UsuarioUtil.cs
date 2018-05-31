using System;
using System.Collections.Generic;
using System.Text;

using App1_NossoChat.Model;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace App1_NossoChat.Util {
    public class UsuarioUtil {

        public static void SetUsuarioLogado(Usuario usuario) {
            App.Current.Properties["LOGIN"] = JsonConvert.SerializeObject(usuario);
        }

        public static Usuario GetUsuarioLogado() {
            if(App.Current.Properties.ContainsKey("LOGIN")) { // com parenteses
                return JsonConvert.DeserializeObject<Usuario>((string)App.Current.Properties["LOGIN"]); // com chaves
            }
            return null;
        }
    }
}
