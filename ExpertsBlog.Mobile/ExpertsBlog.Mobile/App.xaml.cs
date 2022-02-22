using System;
using ExpertsBlog.Mobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: Dependency(typeof(ExpertsBlogApiService))]
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
        }

        /// <summary>
        /// Méthode appelée lors du démarrage de l'application
        /// </summary>
        protected override void OnStart()
        {
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