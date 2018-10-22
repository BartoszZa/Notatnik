using NOTATNIK.Models.Interfaces;
using NOTATNIK.ViewModels;

using Xamarin.Forms;

namespace NOTATNIK.Views
{
    public partial class AddTaskPage : ContentPage
    {
        private AddTaskViewModel _vm;
        public int TaskId { get; set; } = 0;

        public AddTaskPage()
        {
            InitializeComponent();
            _vm = new AddTaskViewModel();
            BindingContext = _vm;
            _vm.Page = this;
            
        }

        protected override void OnAppearing()
        {
            Title = TaskId > 0 ? "EDYCJA" : "DODAWANIE";
            if (TaskId > 0)
            {
                IGetTask getTask = new GetTask();
                _vm.Load(getTask, TaskId);
            }
        }
    }
}
