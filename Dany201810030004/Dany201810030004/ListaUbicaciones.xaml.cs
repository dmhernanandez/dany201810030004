using Dany201810030004.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dany201810030004
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaUbicaciones : ContentPage
    {
        public ListaUbicaciones()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            UbicacionesLista.ItemsSource = await App.GetInstanceDB.GetAllUbications();
        }

        private void OnDelete_Clicked(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var mas = mi.CommandParameter as Ubicacion;
            DisplayAlert("Selecciona", mas.IdUbicacion + " + " + mas.DescripcionCorta, "OK");
        }
    }
}