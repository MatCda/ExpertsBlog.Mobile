using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using ExpertsBlog.Entities;
using ExpertsBlog.Mobile.Pages;
using Xamarin.Forms;

namespace ExpertsBlog.Mobile.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<BlogPost> blogPosts = new ObservableCollection<BlogPost>();
        public ObservableCollection<BlogPost> BlogPosts
        {
            get => blogPosts;
            set => SetProperty(ref blogPosts, value);
        }
        public MainViewModel()
        {
            BlogPosts = new ObservableCollection<BlogPost>();
            for (int i = 0; i < 10; i++)
            {
                BlogPosts.Add(new BlogPost
                {
                    Title = "Title" + i,
                    ImageUrl = "https://picsum.photos/10/10",
                    Author = "Author" + i

                });

            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        protected void SetProperty<T>(ref T storage, T value, /*Action afteraction = null,*/ [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return;
            } 
            storage = value;
            OnPropertyChanged(propertyName);
            //afteraction?.Invoke();
            //return true;
        }

        public  ICommand DetailsCommand => new Command<BlogPost>(async bp =>
        {
            await Shell.Current.GoToAsync($"{nameof(DetailsPage)}?{nameof(DetailsViewModel.Id)}={bp.Id}");
        });
    }
}
 