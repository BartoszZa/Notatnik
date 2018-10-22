using NOTATNIK.ViewModels;
using System;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NOTATNIK.Views
{
    public partial class InitializationPage : ContentPage
    {
        InitializationViewModel vm;

        public InitializationPage()
        {
            InitializeComponent();
            vm = new InitializationViewModel();
            BindingContext = vm;
            SizeChanged += (s, e) => vm.SizeChanged(Width, Height);
            vm.Database();
        }

        protected override async void OnAppearing()
        {
            await Task.Delay(1000);
            await Navigation.PushAsync(new DashboardPage());
        }

        private void Image_SizeChanged(object s, EventArgs e)
        {
            Image img = (Image)s;
            img.HeightRequest = (Application.Current as App).Height;
            img.WidthRequest = (Application.Current as App).Width;
        }
    }
}
