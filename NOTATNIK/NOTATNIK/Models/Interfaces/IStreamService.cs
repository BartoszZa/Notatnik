using System.IO;

namespace NOTATNIK.Models.Interfaces
{
    /// <summary> 
    /// Intefejs do uzyskania stream ze ścieżki do zdjęcia.
    /// </summary> 
    public interface IStreamService
    {
        Stream GetStream(string path);
    }
}
