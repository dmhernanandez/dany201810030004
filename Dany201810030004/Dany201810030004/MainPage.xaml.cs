using Dany201810030004.Modelo;
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


        private async void tbiNuevaUbicacion_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtLatitud.Text) && string.IsNullOrEmpty(TxtLongitud.Text) && string.IsNullOrEmpty(TxtDescripcionCorta.Text) && string.IsNullOrEmpty(TxtDescripcionUbicacion.Text))
            {
                Limpiar();
            }
            else
            {
                bool confirmacion = await DisplayAlert("¿Desea cancelar la ubicación actual?", "Se borraran los datos actuales", "Cancelar","Aceptar");
                if (confirmacion)
                    Limpiar();  
            }
        }

        private async void BtnVerLista_Clicked(object sender, EventArgs e)
        {
            ValidarSalida();
        }

        private void BtnLocationActual_Clicked(object sender, EventArgs e)
        {
     
        }

        private async void BtnCapturar_Clicked(object sender, EventArgs e)
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
                    var position = await ubicacionActual.GetPositionAsync();
                    TxtLatitud.Text = position.Latitude.ToString();
                    TxtLongitud.Text = position.Longitude.ToString();

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
            if (!string.IsNullOrEmpty   (TxtLatitud.Text) && !string.IsNullOrEmpty(TxtLongitud.Text) && !string.IsNullOrEmpty(TxtDescripcionCorta.Text) && !string.IsNullOrEmpty(TxtDescripcionUbicacion.Text))
            {
         App.GetInstanceDB.SaveUbicationAsync(new Ubicacion
                {
                    DescripcionCorta = TxtDescripcionCorta.Text,
                    DescripcionLarga = TxtDescripcionUbicacion.Text,
                    Latitud = double.Parse(TxtLatitud.Text),
                    Longitud = double.Parse(TxtLongitud.Text)
                });
                Limpiar();
            }
            else
            {
                DisplayAlert("Campos incompletos", "Todos los campos deben estar llenos", "Aceptar");
            }
        }

    
        private void TbiLista_Clicked(object sender, EventArgs e)
        {
            ValidarSalida();
        }

        //Limpiamos los valores
        private void Limpiar()
        {
            TxtDescripcionCorta.Text = "";
            TxtDescripcionUbicacion.Text = "";
            TxtLatitud.Text = "";
            TxtLongitud.Text = "";
        }

        //Valida la salida que no hayan valores en los campos
        private async void ValidarSalida()
        {
            if (string.IsNullOrEmpty(TxtLatitud.Text) && string.IsNullOrEmpty(TxtLongitud.Text) && string.IsNullOrEmpty(TxtDescripcionCorta.Text) && string.IsNullOrEmpty(TxtDescripcionUbicacion.Text))
            {
                await Navigation.PushAsync(new ListaUbicaciones());
            }
            else
            {
                bool confirmacion = await DisplayAlert("¿Desea guardar los datos?", "Si sale se borraran los datos actuales", "Cancelar", "Aceptar");
                if (confirmacion)
                    await Navigation.PushAsync(new ListaUbicaciones());
            }
        }
    }
}
