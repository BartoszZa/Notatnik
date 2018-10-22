using PropertyChanged;
using Xamarin.Forms;

namespace NOTATNIK.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public Command CmdSelected { get; set; }
    }
}
