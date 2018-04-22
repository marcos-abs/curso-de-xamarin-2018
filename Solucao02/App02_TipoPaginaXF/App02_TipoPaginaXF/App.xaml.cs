using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App02_TipoPaginaXF
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new App02_TipoPaginaXF.TipoPagina.Carrousel.TipoPagina3(); //apontando para a pagina3
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
