using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace App1_Mimica.ViewModel {
    public class JogoViewModel {
        public byte PalavraPontuacao { get; set; }
        public string Palavra { get; set; }
        public string TextoContagem { get; set; }

        public bool ContainerContagem { get; set; }
        public bool ContainerIniciar { get; set; }

        public Command MostrarPalavra { get; set; }
        public Command Acertou { get; set; }
        public Command Errou { get; set; }
        public Command Iniciar { get; set; }

        public JogoViewModel() {
            ContainerContagem = false;
            MostrarPalavra = new Command();
            Acertou = new Command();
            Errou = new Command();
            Iniciar = new Command();
        }
    }
}
