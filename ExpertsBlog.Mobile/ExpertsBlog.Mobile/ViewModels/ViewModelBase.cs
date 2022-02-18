using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExpertsBlog.Mobile.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Méthode qui va effectuer la notification
        /// </summary>
        private void OnPropertyChanged(string propertyName)
        {
            // On vérifie que PropertyChanged n'est pas `null`
            if (PropertyChanged == null)
            {
                return;
            }
            // this = instance de `DemoViewModel`
            // Instancier l'événement qui va contenir le nom de la propriété à changer.
            // On créé les arguments de l'événement.
            var args = new PropertyChangedEventArgs(propertyName);
            // On invoque l'événément en lui donnant le nom de la propriété à modifier.
            PropertyChanged.Invoke(this, args);
        }

        /// <summary>
        /// Méthode générique qui va notifier le changement de valeur d'une propriété.
        /// </summary>
        /// <typeparam name="T">Type de la propriété publique et du champ privé.</typeparam>
        /// <param name="storage">Valeur avec sa réference (adresse en mémoire) du champ privé.</param>
        /// <param name="value">Nouvelle valeur.</param>
        /// <param name="propertyName">Le nom de la propriété qui va être modifiée.</param>
        protected void SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            // Vérifier l'égalité entre la valeur de `storage` et de `value`.
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                // Si la valeur est égale, on arrête.
                return;
            }
            // On remplace la valeur à l'adresse de `storage` par la nouvelle valeur, `value`.
            storage = value;
            // On appelle la méthode `OnPropertyChanged(string)` qui va créer un événement de changement de valeur.
            OnPropertyChanged(propertyName);
        }
    }
}