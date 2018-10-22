using NOTATNIK.Models;
using NOTATNIK.Models.Database;
using NOTATNIK.Models.Interfaces;
using NOTATNIK.Views;
using PropertyChanged;
using SQLite;
using Xamarin.Forms;

namespace NOTATNIK.ViewModels
{
    /// <summary>
    /// Klasa implementujaca metode do pobrania tasków z bazy
    /// </summary>
    public class GetTask : IGetTask
    {
        public Task Task { get; set; }

        public async System.Threading.Tasks.Task DatabaseCall(int id)
        {
            SQLiteAsyncConnection connection = new SQLiteAsyncConnection(Configuration.DATABASE);
            Task taskDB = await connection.Table<Task>()
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();
            Task = taskDB;
        }
    }

    /// <summary> 
    /// Klasa pomocnicza do załadowania danych do widoku.
    /// </summary> 
    [AddINotifyPropertyChangedInterface]
    public class AddTaskViewModel
    {
        /// <summary> 
        /// Id taska.
        /// </summary> 
        private int _taskId = 0;
        /// <summary> 
        /// Zmienna mówiąca czy przycisk usuń ma być widoczny.
        /// </summary> 
        public bool IsRemove { get; set; } = false;
        /// <summary> 
        /// Zmienna subject
        /// </summary> 
        public string Subject { get; set; }
        /// <summary> 
        /// Zmienna content
        /// </summary> 
        public string Content { get; set; }
        /// <summary> 
        /// Event do klikniecia
        /// </summary> 
        public Command CmdSave { get; set; }
        /// <summary> 
        /// Event do klikniecia
        /// </summary> 
        public Command CmdRemove { get; set; }
        /// <summary> 
        /// Zmienna page.
        /// </summary> 
        public Page Page { get; set; }

        /// <summary> 
        /// Konstruktor.
        /// </summary> 
        public AddTaskViewModel()
        {
            /// <summary> 
            /// Połączenie do bazy
            /// </summary> 
            SQLiteAsyncConnection connection = new SQLiteAsyncConnection(Configuration.DATABASE);
            /// <summary> 
            /// Event do klikniecia
            /// </summary> 
            CmdSave = new Command(async () =>
            {
                if(_taskId > 0)
                {
                    Task taskDB = await connection.Table<Task>()
                        .Where(t => t.Id == _taskId)
                        .FirstOrDefaultAsync();

                    taskDB.Subject = Subject;
                    taskDB.Content = Content;
                    await connection.UpdateAsync(taskDB);
                }
                else
                {
                    Task taskDB = new Task()
                    {
                        Subject = Subject,
                        Content = Content
                    };
                    await connection.InsertAsync(taskDB);
                }
                await Page.Navigation.PushAsync(new DashboardPage());
            });
            /// <summary> 
            /// Event do klikniecia
            /// </summary> 
            CmdRemove = new Command(async () =>
            {
                if (_taskId > 0)
                {
                    Task taskDB = await connection.Table<Task>()
                        .Where(t => t.Id == _taskId)
                        .FirstOrDefaultAsync();

                    await connection.DeleteAsync(taskDB);
                    await Page.Navigation.PushAsync(new DashboardPage());
                }
            });
        }
        /// <summary> 
        /// Metoda do pobrania z bazy danych oraz wczytywanie ich do widoku.
        /// </summary> 
        /// <param name="getTask">interfejs</param>
        /// <param name="id">id taska</param>
        public async void Load(IGetTask getTask, int id)
        {
            _taskId = id;
            IsRemove = true;
            await getTask.DatabaseCall(id);
            Task taskDB = getTask.Task;

            Subject = taskDB.Subject;
            Content = taskDB.Content;
        }
    }
}
