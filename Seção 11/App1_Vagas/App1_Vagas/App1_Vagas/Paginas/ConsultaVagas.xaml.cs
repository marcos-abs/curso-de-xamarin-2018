using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1_Vagas.Modelos;
using App1_Vagas.Banco;

namespace App1_Vagas.Paginas {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaVagas : ContentPage {
        public ConsultaVagas() {
            InitializeComponent();

            Database database = new Database();
            var Lista = database.Consultar();
            ListaVagas.ItemsSource = Lista;
            if(Lista.Count > 1 ) {
                lblCount.Text = Lista.Count.ToString() + " vagas cadastradas";
            } else if (Lista.Count == 0) {
                lblCount.Text = "nenhuma vaga encontrada";
            } else {
                lblCount.Text = Lista.Count.ToString() + " vaga cadastrada";
            }
        }

        public void GoCadastro(object sender, EventArgs args) {
            Navigation.PushAsync(new CadastroVaga());
        }

        public void GoMinhasVagas(object sender, EventArgs args) {
            Navigation.PushAsync(new MinhasVagasCadastradas());
        }

        public void MaisDetalhesAction(object sender, EventArgs args) {
            Label lblDetalhe = (Label)sender;
            Vaga vaga = ((TapGestureRecognizer)lblDetalhe.GestureRecognizers[0]).CommandParameter as Vaga;
            Navigation.PushAsync(new DetalheVaga(vaga));
        }
    }
}