﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Cell.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : MasterDetailPage
	{
		public Master ()
		{
			InitializeComponent ();
		}

        public void GoPagina1(object sender, EventArgs args) {
            Detail = new NavigationPage(new Pagina.TextCellPage());
        }

        public void GoPagina2(object sender, EventArgs args) {
            Detail = new NavigationPage(new Pagina.ImageCellPage());
        }

        public void GoPagina3(object sender, EventArgs args) {
            Detail = new NavigationPage(new Pagina.EntryCellPage());
        }

        public void GoPagina4(object sender, EventArgs args) {
            Detail = new NavigationPage(new Pagina.SwitchCellPage());
        }

        public void GoPagina5(object sender, EventArgs args) {
            Detail = new NavigationPage(new Pagina.ViewCellPage());
        }

        public void GoPagina6(object sender, EventArgs args) {
            Detail = new NavigationPage(new Pagina.ListViewPage());
        }
    }
}