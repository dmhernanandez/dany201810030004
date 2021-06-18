using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Dany201810030004.DataBase;

namespace Dany201810030004
{
    public partial class App : Application
    {

        /*Se declara una instancia de la clase que gestiona la base de datos privada y estatica porque será una misma durante la vida
         de la aplicación y privada porque solo se accesible mediante el metodo GetInstanceDB que valida si existe o no.*/
        private static ManagerDataBase InstanceDataBase;

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {

        }
        public static ManagerDataBase GetInstanceDB
        {
            get
            {
                //Validamos que solo exista una instancia de la calse ManagerDataBase
                if (InstanceDataBase == null)
                {
                    /*Variables estaticas que permiten crear la ruta donde se alamacenará nuestra base de datos*/
                    string dbName = "dbexamen.sqlite";
                    string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    string finalPathDb = Path.Combine( folderPath,dbName);

                    InstanceDataBase = new ManagerDataBase(finalPathDb);
                }
                return InstanceDataBase;
            }

        }
    }
}
