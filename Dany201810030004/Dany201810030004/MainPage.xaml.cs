using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Dany201810030004
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private void tbiNuevaUbicacion_Clicked(object sender, EventArgs e)
        {

        }

        private async void BtnVerLista_Clicked(object sender, EventArgs e)
        {
            ListaUbicaciones lista = new ListaUbicaciones();
            lista.BindingContext = new { Nombre = "Sara" };
            await Navigation.PushAsync(lista);
        }

        private void BtnLocationActual_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnCapturar_Clicked(object sender, EventArgs e)
        {
            var ubicacionActual = CrossGeolocator.Current;
            /*Obtiene nuestra ubicación actual si tenemos disponible la Geolocalizacion es decir el permiso o sino lo pedimos*/
            if (ubicacionActual.IsGeolocationAvailable)
            {

                if (!ubicacionActual.IsGeolocationEnabled)
                {
                    DisplayAlert("Ubicación", "Debe encender la  ubicacion o GPS de su dispositivo", "Aceptar");

                }
                else
                {
                    var position = ubicacionActual.GetPositionAsync();
                    TxtLatitud.Text = position.Result.Latitude.ToString();
                    TxtLongitud.Text = position.Result.Latitude.ToString();
                    /*   App.GetInstanceDB.SaveUbicationAsync(new Modelo.Ubicacion {
                       DescripcionCorta="Hola",DescripcionLarga="Esto es una prueba",
                       Latitud=123.222111,
                       Longitud=-80.311222
                       });*/
                }
            }
            else
            {
                DisplayAlert("Permiso denegado", "Para poder acceder a la localización debe pertir acceder a la ubicacion", "Aceptar");
            }
        }

        private void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            /*Se valida que los campos no esten vacios*/
            if (!string.IsNullOrEmpty(TxtLatitud.Text) && !string.IsNullOrEmpty(TxtLongitud.Text) && !string.IsNullOrEmpty(TxtDescripcionCorta.Text) && !string.IsNullOrEmpty(TxtDescripcionUbicacion.Text))
            {

            }
            else
            {
                DisplayAlert("Campos incompletos", "Todos los campos deben estar llenos", "Aceptar");
            }
        }

        private void TbiLista_Clicked(object sender, EventArgs e)
        {

        }

    }
}
