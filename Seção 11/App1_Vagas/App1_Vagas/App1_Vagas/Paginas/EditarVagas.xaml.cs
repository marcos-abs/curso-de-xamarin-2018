using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1_Vagas.Banco;
using App1_Vagas.Modelos;

namespace App1_Vagas.Paginas {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarVagas : ContentPage {

        private Vaga vaga { get; set; }

        public EditarVagas(Vaga vaga) {
            InitializeComponent();

            this.vaga = vaga;

            NomeVaga.Text = vaga.NomeVaga;
            Quantidade.Text = vaga.Quantidade.ToString();
            Salario.Text = vaga.Salario.ToString();
            Empresa.Text = vaga.Empresa;
            Cidade.Text = vaga.Cidade;
            Descricao.Text = vaga.Descricao;
            TipoContratacao.IsToggled = (vaga.TipoContratacao == "CLT") ? false : true;
            vaga.Telefone = Telefone.Text;
            vaga.Email = Email.Text;
        }

        public void SalvarAction(object sender, EventArgs args) {
            vaga.NomeVaga = NomeVaga.Text;
            vaga.Quantidade = short.Parse(Quantidade.Text);
            vaga.Salario = double.Parse(Salario.Text);
            vaga.Empresa = Empresa.Text;
            vaga.Cidade = Cidade.Text;
            vaga.Descricao = Descricao.Text;
            vaga.TipoContratacao = (TipoContratacao.IsToggled) ? "PJ" : "CLT";
            vaga.Telefone = Telefone.Text;
            vaga.Email = Email.Text;

            Database database = new Database();
            database.Atualizacao(vaga);

            App.Current.MainPage = new NavigationPage(new MinhasVagasCadastradas());
        }
    }
}