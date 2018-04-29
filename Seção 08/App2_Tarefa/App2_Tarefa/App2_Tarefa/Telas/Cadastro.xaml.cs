using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2_Tarefa.Telas {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage {
        public Cadastro() {
            InitializeComponent();
        }

        public void PrioridadeSelectAction(object sender, EventArgs args) {
            var Stacks = SLPrioridades.Children;
            foreach (var Linha in Stacks) {
                Label LblPrioridade = ((StackLayout)Linha).Children[1] as Label;
                LblPrioridade.TextColor = Color.Gray;
                ((Label)((StackLayout)sender).Children[1]).TextColor = Color.Black;
                FileImageSource Source = ((Image)((StackLayout)sender).Children[0]).Source as FileImageSource;
                String Prioridade = Source.File.ToString().Replace("Resources/", "").Replace(".png", "");
                txtNome.Text = Prioridade;
            }
        }

    }
}