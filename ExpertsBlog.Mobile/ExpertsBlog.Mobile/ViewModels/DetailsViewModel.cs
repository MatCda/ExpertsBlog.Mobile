using ExpertsBlog.Entities;
using ExpertsBlog.Mobile.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ExpertsBlog.Mobile.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class DetailsViewModel : ViewModelBase
    {
        private readonly IExpertsBlogApiService apiService;

        public DetailsViewModel()
        {
            apiService = DependencyService.Get<IExpertsBlogApiService>();
            Addresses = new ObservableCollection<Address>();
        }
        private int id;
        public int Id
        {
            get => id;
            set
            {
                SetProperty(ref id, value);
                LoadItem(value);
            }
        }

        private string title;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        private int index;

        /// <summary>
        /// Index pour l'exemple de la commande
        /// </summary>
        public int Index
        {
            get => index;
            set => SetProperty(ref index, value);
        }
        private string content;
        public string Content
        {
            get => content;
            set => SetProperty(ref content, value);
        }
        private DateTime creation;
        public DateTime Creation
        {
            get => creation;
            set => SetProperty(ref creation, value);
        }
        private string name;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        private Category category;
        public Category Category
        {
            get => category;
            set => SetProperty(ref category, value);
        }
        private string author;
        public string Author
        {
            get => author;
            set => SetProperty(ref author, value);
        }

        private ObservableCollection<Address> addresses;
        public ObservableCollection<Address> Addresses
        {
            get => addresses;
            set => SetProperty(ref addresses, value);
        }

        private void LoadItem(int id)
        {
            //BlogPost blogpost = await apiService.GetBlogPost(id);
            Task.Run(async () =>
            {
                var blogPost = await apiService.GetBlogPost(id);
                Author = blogPost.Author;
                Creation = blogPost.Creation;
                Title = blogPost.Title;
                Content = blogPost.Content;
                Category = blogPost.Category;

                foreach (var address in await apiService.GetAddresses(id))
                {
                    Addresses.Add(address);
                }
                //Addresses = new ObservableCollection<Address>(blogPost.Addresses);
            });
        }
        public ICommand ClickCommand => new Command(() => Index++);

        public ICommand OpenMapsCommand => new Command<Address>(async address =>
        {
            // https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/map/native-map-app
            string a = $"{address.Street}, {address.Zip} {address.City}, France";
            if (Device.RuntimePlatform == Device.iOS)
            {
                // https://developer.apple.com/library/ios/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
                await Launcher.OpenAsync("http://maps.apple.com/?q=" + a);
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                // open the maps app directly
                await Launcher.OpenAsync("geo:0,0?q=" + a);
            }
            else if (Device.RuntimePlatform == Device.UWP)
            {
                await Launcher.OpenAsync("bingmaps:?where=" + a);
            }
        });


    }
}
