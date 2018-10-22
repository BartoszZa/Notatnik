using NOTATNIK.Models;
using NOTATNIK.Models.Database;
using PropertyChanged;
using SQLite;
using System;
using Xamarin.Forms;

namespace NOTATNIK.ViewModels
{
    /// <summary> 
    /// Klasa pomocnicza do obsłużenia widoku InitializationPage.
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class InitializationViewModel
    {
        /// <summary> 
        /// Metoda do zapisywania rozdzielczości telefonu.
        /// </summary> 
        /// <param name="height">Wysokosc ekranu</param>
        /// <param name="width">Szerokosc ekranu</param>
        public void SizeChanged(double width, double height)
        {
            (Application.Current as App).Width = width;
            (Application.Current as App).Height = height;
        }
        /// <summary> 
        /// Klasa pomocnicza do stworzenia tabel w bazie.
        /// </summary>
        public async void Database()
        {
            SQLiteAsyncConnection connection = new SQLiteAsyncConnection(Configuration.DATABASE);
            bool isDatabase = false;
            try
            {
                int task = await connection.Table<Task>().CountAsync();
                isDatabase = task > 0;
            }
            catch (Exception) { }

            if(!isDatabase)
            {
                await connection.CreateTableAsync<Task>();
            }
        }
    }
}
