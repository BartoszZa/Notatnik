using NOTATNIK.Models.Database;

namespace NOTATNIK.Models.Interfaces
{
    /// <summary>
    /// Interfejs do pobrania Task
    /// </summary>
    public interface IGetTask
    {
        System.Threading.Tasks.Task DatabaseCall(int id);
        Task Task { get; set; }
    }
}
