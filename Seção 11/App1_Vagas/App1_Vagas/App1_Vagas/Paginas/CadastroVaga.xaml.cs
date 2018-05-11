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
    public partial class CadastroVaga : ContentPage {
        public CadastroVaga(Vaga vaga = null) {
            InitializeComponent();

            if(vaga != null) {
                //TODO Edição
            }
        }

        public void SalvarAction(object sender, EventArgs args) {
            
            Vaga vaga = new Vaga();

            //TODO Validar dados do cadastro
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
            database.Cadastro(vaga);

            App.Current.MainPage = new NavigationPage(new ConsultaVagas());
        }
    }
}