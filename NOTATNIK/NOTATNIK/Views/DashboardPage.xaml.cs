using NOTATNIK.ViewModels;

using Xamarin.Forms;

namespace NOTATNIK.Views
{
    public partial class DashboardPage : ContentPage
    {
        private DashboardViewModel _vm;

        public DashboardPage()
        {
            InitializeComponent();
            _vm = new DashboardViewModel();
            _vm.Page = this;
            BindingContext = _vm;
            Title = "NOTATNIK";
        }

        protected override void OnAppearing()
        {
            _vm.Load(StlTask);
        }
    }
}
