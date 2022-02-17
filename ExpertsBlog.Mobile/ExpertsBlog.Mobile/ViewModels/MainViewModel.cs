using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using ExpertsBlog.Entities;

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
                    ImageUrl = "https://picsum.photos/10/10"

                });

            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) =>PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        protected void SetProperty<T>(ref T storage, T value, /*Action afteraction = null,*/ [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return ;
            }
            storage = value;
            OnPropertyChanged(propertyName);
            //afteraction?.Invoke();
            //return true;
        }
    }
}
 