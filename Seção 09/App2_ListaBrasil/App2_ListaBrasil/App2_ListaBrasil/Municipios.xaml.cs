using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App2_ListaBrasil.Modelo;

namespace App2_ListaBrasil
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Municipios : ContentPage
	{
		public Municipios (Estado estado)
		{
			InitializeComponent ();
		}
	}
}