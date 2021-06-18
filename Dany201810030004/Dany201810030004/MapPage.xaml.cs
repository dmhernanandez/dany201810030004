using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dany201810030004.Modelo;
using Xamarin.Forms.Maps;

namespace Dany201810030004
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        //Esta variable se utiliza para recuperar la ubicacionPin que se envia por parametro
        private Ubicacion ubicacionSeleccionada;

        public MapPage()
        {
            InitializeComponent();
        }
        //Se sobrecarga el constructor permitiendo obtener los datos de la ubicación
        public MapPage(Ubicacion ubicacion)
        {
            InitializeComponent();
            ubicacionSeleccionada = ubicacion;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            /*Antes de asignar un pin al mapa validamos que los datos de la ubicacionPin no sean nulos*/
            if(ubicacionSeleccionada!=null)
            {
                //Creamos una posicion a partir de los datos de la ubicación
                var posicion = new Position(ubicacionSeleccionada.Latitud, ubicacionSeleccionada.Longitud);

                //Se crea el Pin y se agrega al mapa
                Pin ubicacionPin = new Pin {
                    Address = ubicacionSeleccionada.DescripcionLarga,
                    Label = ubicacionSeleccionada.DescripcionCorta,
                    Type = PinType.Place,
                    
                    Position = posicion
                };
                mapa.Pins.Add(ubicacionPin);

                /* Una vez se agrega el pin debemos centrarlo en nuestra ubicacionPin para que pueda ser visible*/
                mapa.MoveToRegion(MapSpan.FromCenterAndRadius(posicion,Distance.FromKilometers(0.5)));
            }
        }

        private async void tbiNuevaUbicacion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
          await    Navigation.PushAsync(new MainPage());
        }
    }
}