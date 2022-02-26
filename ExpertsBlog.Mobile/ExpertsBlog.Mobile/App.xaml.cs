using System;
using System.Threading.Tasks;
using ExpertsBlog.Mobile.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ExpertsBlog.Mobile
{
    /// <summary>
    /// La classe App gère le cycle de vie de l'application.
    /// Cette classe est partielle. L'autre partie est générée grâce au fichier XAML associé (App.xaml.cs).
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Constructeur de la classe App
        /// </summary>
        public App()
        {
            // On initialise l'application
            InitializeComponent();
            // On défini l'objet de démarrage
            MainPage = new AppShell();
            DependencyService.Register<IExpertsBlogApiService, ExpertsBlogApiService>();
        }

        /// <summary>
        /// Méthode appelée lors du démarrage de l'application
        /// </summary>
        protected override async void OnStart()
        {
            await CheckPermissions<Permissions.LocationWhenInUse>();
            await CheckPermissions<Permissions.LocationAlways>();
            await CheckPermissions<Permissions.Camera>();
            await CheckPermissions<Permissions.Microphone>();
        }

        private async Task CheckPermissions<TPermission>()
            where TPermission : Permissions.BasePermission, new()
        {
            var status = await Permissions.CheckStatusAsync<TPermission>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<TPermission>();
                Console.WriteLine(status);
            }
        }

        /// <summary>
        /// Méthode appelée lorsque l'application va être mise en veille 
        /// (par le système ou lorsqu'on bascule d'une application à une autre)
        /// </summary>
        protected override void OnSleep()
        {
        }

        /// <summary>
        /// Méthode appelée lors de la reprise de l'application 
        /// (lorsqu'on reviens dessus)
        /// </summary>
        protected override void OnResume()
        {
        }
    }
}