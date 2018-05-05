using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App1_Cell.Modelo;

namespace App1_Cell.Pagina
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImageCellPage : ContentPage
	{
		public ImageCellPage ()
		{
			InitializeComponent ();

            List<Funcionario> Lista = new List<Funcionario>();

            Lista.Add(new Funcionario() { Foto = "https://media.licdn.com/dms/image/C4E03AQFOggbk903rQA/profile-displayphoto-shrink_200_200/0?e=1529528400&v=beta&t=dJlR2QmHTJJuLm-dVpf9K2zHtcWwOHlKtGRVh4DX_LU", Nome = "José", Cargo = "Presidente da empresa" });
            Lista.Add(new Funcionario() { Foto = "http://blogs.uai.com.br/cantodogalo/wp-content/uploads/sites/32/2018/04/nathalia_mazzieiro.jpg", Nome = "Maria", Cargo = "Gerente de Vendas" });
            Lista.Add(new Funcionario() { Foto = "https://ct.yimg.com/cy/4689/38609694164_71b709_128sq.jpg", Nome = "Elaine", Cargo = "Gerente de Marketing" });
            Lista.Add(new Funcionario() { Foto = "http://0.gravatar.com/avatar/c73a32ea07a8d0f1efc5e010fab5001d?s=128&d=https%3A%2F%2Fwww.midiatismo.com.br%2Fwp-content%2Fthemes%2FMidiatismo%2Fimgs%2Fmystery-logo-150.jpg&r=g", Nome = "Felipe", Cargo = "Entregador" });
            Lista.Add(new Funcionario() { Foto = "http://www.administradores.com.br/_assets/modules/members/member_273788.jpg?", Nome = "João", Cargo = "Vendedor" });

            ListaFuncionario.ItemsSource = Lista;

        }
    }
}