using ExpertsBlog.Entities;
using ExpertsBlog.Mobile.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using Xamarin.Forms;

namespace ExpertsBlog.Mobile.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class DetailsViewModel : ViewModelBase
    {
        private readonly IExpertsBlogApiService apiService = new ExpertsBlogApiService();

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
        private  string name;
        public  string Name
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

        private async void LoadItem(int id)
        {
            BlogPost blogpost = await apiService.GetBlogPost(id);

            Author = blogpost.Author;
            Creation = blogpost.Creation;
            Title = blogpost.Title;
            Content = blogpost.Content;
            Category = blogpost.Category;
        }
    }
}
 