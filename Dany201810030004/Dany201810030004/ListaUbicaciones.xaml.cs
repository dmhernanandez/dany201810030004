using Dany201810030004.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
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
            int numero = await App.GetInstanceDB.GetCount();
            if(numero<=0)
            {
                await App.GetInstanceDB.SaveUbicationAsync(new Ubicacion
                {
                    DescripcionCorta = "Playas Milla 4",
                    DescripcionLarga = "Milla 4, 50 mt despues de Omoa",
                    Latitud = 15.735478781752864,
                    Longitud = -88.08252484157082
                });

                await App.GetInstanceDB.SaveUbicationAsync(new Ubicacion
                {
                    DescripcionCorta = "UNO La mega",
                    DescripcionLarga = "Aldea El chile",
                    Latitud = 15.82541412765695,
                    Longitud = -87.8701507471099
                });

                await App.GetInstanceDB.SaveUbicationAsync(new Ubicacion
                {
                    DescripcionCorta = "Terreno familiar",
                    DescripcionLarga = "Aldea Campana",
                    Latitud = 15.814165724882274,
                    Longitud = -87.84356799759748
                });

                await App.GetInstanceDB.SaveUbicationAsync(new Ubicacion
                {
                    DescripcionCorta = "Texaco Hercules",
                    DescripcionLarga = "Barrio Pueblo Nuevo",
                    Latitud = 15.82802240938438,
                    Longitud = -87.91803538821438
                });

                await App.GetInstanceDB.SaveUbicationAsync(new Ubicacion
                {
                    DescripcionCorta = "Carretera Nueva Esperanza",
                    DescripcionLarga = "Aldea El triunfo, hacia frontera con Guatemala",
                    Latitud = 15.615792215598686,
                    Longitud = -88.27623156345695
                });
            }
          
            UbicacionesLista.ItemsSource = await App.GetInstanceDB.GetAllUbications();
        }

        private async void OnDelete_Clicked(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var ubicacionSeleccionada = mi.CommandParameter as Ubicacion;
            //Se pregunta al usuario si desea elminar la ubicación
            bool confirmacion = await DisplayAlert("¿Desea borrar la ubicación?", "Los datos de borrarán de forma permanente", "Aceptar", "Cancelar ");
            if (confirmacion)
            {
               await App.GetInstanceDB.DeleteUbication(ubicacionSeleccionada);
                await DisplayAlert("Datos borrados con exito" ,"Cierre y entre nuevamente para ver los cambios", "Aceptar");
            }
  
        }

        private async void UbicacionesLista_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var ubicacionSeleccionada = e.Item as Ubicacion;

            await Navigation.PushAsync(new MapPage(ubicacionSeleccionada));
        }

        private async void tbiNuevaUbicacion_Clicked(object sender, EventArgs e)
        {
            
            
               await Navigation.PopAsync();
            Navigation.PushAsync(new MainPage());
        }
    }
}