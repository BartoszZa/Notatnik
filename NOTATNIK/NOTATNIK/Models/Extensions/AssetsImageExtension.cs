using NOTATNIK.Models.Interfaces;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NOTATNIK.Models.Extensions
{
    /// <summary> 
    /// Klasa pomocnicza do wczytywania obrazka. 
    /// </summary> 
    [ContentProperty("Source")]
    public class AssetsImageExtension : IMarkupExtension
    {
        /// <summary> 
        /// Źródło obrazka. 
        /// </summary> 
        public string Source { get; set; }

        /// <summary> 
        /// Metoda do odczytania ścieżki obrazka. 
        /// </summary> 
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            try
            {
                Stream stream = DependencyService.Get<IStreamService>().GetStream(Source);
                return ImageSource.FromStream(() => stream);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary> 
        /// Metoda do odczytania ścieżki obrazka. 
        /// </summary> 
        public static ImageSource GetSource(string source)
        {
            if (!string.IsNullOrEmpty(source))
            {
                try
                {
                    Stream stream = DependencyService.Get<IStreamService>().GetStream(source);
                    return ImageSource.FromStream(() => { return stream; });
                }
                catch (Exception) { }
            }
            return source != null ? ImageSource.FromFile(source) : null;
        }
    }
}

