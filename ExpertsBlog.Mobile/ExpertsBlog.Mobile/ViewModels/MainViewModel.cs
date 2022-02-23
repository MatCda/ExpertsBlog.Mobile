using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using ExpertsBlog.Entities;
using ExpertsBlog.Mobile.Pages;
using Xamarin.Forms;
using System.Net.Http;
using System;
using Newtonsoft.Json;
using System.Diagnostics;
using ExpertsBlog.Mobile.Services;
using System.Threading.Tasks;

namespace ExpertsBlog.Mobile.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IExpertsBlogApiService apiService ;

        private ObservableCollection<BlogPost> blogPosts ;

        public ObservableCollection<BlogPost> BlogPosts
        {
            get => blogPosts;
            set => SetProperty(ref blogPosts, value);
        }    
        public MainViewModel()
        {
            //GetData();
            apiService = DependencyService.Get<IExpertsBlogApiService>();
            BlogPosts = new ObservableCollection<BlogPost>();
            //Onload();
        }
        public void Onload()
        {
            Task.Run(async () =>
            {
                var blogPostFromService = await apiService.GetBlogPosts();
                foreach (var blogPost in blogPostFromService)
                {
                    BlogPosts.Add(blogPost);
                }
            });
        }
        //private async void GetData()
        //{
        //    BlogPosts = new ObservableCollection<BlogPost>(await apiService.GetBlogPosts());

        //}
        public ICommand DetailsCommand => new Command<BlogPost>(async bp =>
       {
           await Shell.Current.GoToAsync($"{nameof(DetailsPage)}?{nameof(DetailsViewModel.Id)}={bp.Id}");
       });

        //private async void GetData()
        //{
        //    using (HttpClient httpClient = new HttpClient()
        //    {
        //        BaseAddress = new Uri("https://expertsblogapi.azurewebsites.net/")
        //    })
        //    {
        //        var json = await httpClient.GetStringAsync("BlogPosts");
        //        Debug.WriteLine("***********************************" + json);
        //        var x = JsonConvert.DeserializeObject<IEnumerable<BlogPost>>(json);
        //        foreach (var blogPost in x)
        //        {
        //            BlogPosts.Add(blogPost);
        //        }
        //    }
        //}


        //public event PropertyChangedEventHandler PropertyChanged;
        //private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //protected void SetProperty<T>(ref T storage, T value, /*Action afteraction = null,*/ [CallerMemberName] string propertyName = null)
        //{
        //    if (EqualityComparer<T>.Default.Equals(storage, value))
        //    {
        //        return;
        //    }
        //    storage = value;
        //    OnPropertyChanged(propertyName);
        //    //afteraction?.Invoke();
        //    //return true;
        //}
    }
}
