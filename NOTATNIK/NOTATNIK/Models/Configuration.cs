using NOTATNIK.Models.Interfaces;
using Xamarin.Forms;

namespace NOTATNIK.Models
{
    /// <summary> 
    /// Klasa pomocnicza ze stałymi wartościami do projektu
    /// </summary> 
    public class Configuration
    {
        public static string DATABASE
        {
            get
            {
                return DependencyService.Get<ISourceService>().GetSource() + "\\" + "notatnik";
            }
        }
    }
}
