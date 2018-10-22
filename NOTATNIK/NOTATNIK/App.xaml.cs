using NOTATNIK.Views;

using Xamarin.Forms;

namespace NOTATNIK
{
    /// <summary> 
    /// Klasa startowa projektu.
    /// </summary> 
    public partial class App : Application
    {
        public double Width { get; set; }
        public double Height { get; set; }
        /// <summary> 
        /// Konstruktor.
        /// </summary>
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new InitializationPage());
        }
    }
}
