using NOTATNIK.Droid.DependencyServices;
using NOTATNIK.Models.Interfaces;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(StreamService))]
namespace NOTATNIK.Droid.DependencyServices
{
    public class StreamService : IStreamService
    {
        public Stream GetStream(string path)
        {
            return Forms.Context.Assets.Open(path);
        }
    }
}