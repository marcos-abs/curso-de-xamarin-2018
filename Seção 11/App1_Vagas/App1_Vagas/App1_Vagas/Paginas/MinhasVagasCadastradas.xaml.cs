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
    public partial class MinhasVagasCadastradas : ContentPage {

        List<Vaga> Lista { get; set; }

        public MinhasVagasCadastradas() {
            InitializeComponent();
            ConsultarVagas();
        }

        private void ConsultarVagas() {
            Database database = new Database();
            Lista = database.Consultar();
            ListaVagas.ItemsSource = Lista;
            if (Lista.Count > 1) {
                lblCount.Text = Lista.Count.ToString() + " vagas cadastradas";
            } else if (Lista.Count == 0) {
                lblCount.Text = "nenhuma vaga encontrada";
            } else {
                lblCount.Text = Lista.Count.ToString() + " vaga cadastrada";
            }
        }

        public void EditarAction(object sender, EventArgs args) {
            Label lblEditar = (Label)sender;
            Vaga vaga = ((TapGestureRecognizer)lblEditar.GestureRecognizers[0]).CommandParameter as Vaga;
            Navigation.PushAsync(new EditarVagas(vaga));
        }

        public void ExcluirAction(object sender, EventArgs args) {
            Label lblExcluir = (Label)sender;
            Vaga vaga = ((TapGestureRecognizer)lblExcluir.GestureRecognizers[0]).CommandParameter as Vaga;
            Database database = new Database();
            database.Exclusao(vaga);
            ConsultarVagas();
        }
    }
}