using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ExpertsBlog.Entities;
using ExpertsBlog.Mobile.ViewModels;

namespace ExpertsBlog.Mobile.Pages
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((MainViewModel)BindingContext).Initialize();
        }
    }
}
