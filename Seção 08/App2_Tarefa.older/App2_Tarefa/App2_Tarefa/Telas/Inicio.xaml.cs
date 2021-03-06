﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App2_Tarefa.Modelos;

namespace App2_Tarefa.Telas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Inicio : ContentPage
	{
		public Inicio ()
		{
			InitializeComponent ();
            DataHoje.Text = DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Now.ToString("dd/MM");
            CarregarTarefas();
		}

        public void ActionGoCadastro(object sender, EventArgs args) {
            Navigation.PushAsync(new Cadastro());
        }

        private void CarregarTarefas() {
            SLTarefas.Children.Clear();

            List<Tarefa> Lista = new GerenciadorTarefa().Listagem();

            foreach (Tarefa tarefa in Lista) {
                LinhaStackLayout(tarefa);
            }
        }

        public void LinhaStackLayout(Tarefa tarefa) {

            Image Delete = new Image() {
                VerticalOptions = LayoutOptions.Center,
                Source = ImageSource.FromFile("Delete.png")
            };
            if (Device.RuntimePlatform == Device.UWP) {
                Delete.Source = ImageSource.FromFile("Resources/Delete.png");
            }
            Image Prioridade = new Image() {
                VerticalOptions = LayoutOptions.Center,
                Source = ImageSource.FromFile("p" + tarefa.Prioridade + ".png")
            };
            if (Device.RuntimePlatform == Device.UWP) {
                Prioridade.Source = ImageSource.FromFile("Resources/p" + tarefa.Prioridade + ".png");
            }

            View StackCentral = null;
            if(tarefa.DataFinalizacao == null) {
                StackCentral = new Label() {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Text = tarefa.Nome
                };
            } else {
                StackCentral = new StackLayout() {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Spacing = 0
                };
                ((StackLayout)StackCentral).Children.Add(new Label() {
                    Text = tarefa.Nome,
                    TextColor = Color.Gray
                });
                ((StackLayout)StackCentral).Children.Add(new Label() {
                    Text = "Finalizado em " + tarefa.DataFinalizacao.Value.ToString("dd/MM/yyyy - hh:mm") + "h",
                    TextColor = Color.Gray,
                    FontSize = 10
                });
            }

            Image Check = new Image() {
                VerticalOptions = LayoutOptions.Center,
                Source = ImageSource.FromFile("CheckOff.png")
            };
            if(Device.RuntimePlatform == Device.UWP) {
                Check.Source = ImageSource.FromFile("Resources/CheckOff.png");
	        }

            StackLayout Linha = new StackLayout() { Orientation = StackOrientation.Horizontal, Spacing = 15 };

            Linha.Children.Add(Check);
            Linha.Children.Add(StackCentral);
            Linha.Children.Add(Prioridade);
            Linha.Children.Add(Delete);

            SLTarefas.Children.Add(Linha);
        }
    }
}