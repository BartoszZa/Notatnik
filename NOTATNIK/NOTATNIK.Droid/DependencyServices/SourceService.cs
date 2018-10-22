using NOTATNIK.Droid.DependencyServices;
using NOTATNIK.Models.Interfaces;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(SourceService))]
namespace NOTATNIK.Droid.DependencyServices
{
    public class SourceService : ISourceService
    {
        public string GetSource()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "//";
        }
    }
}