using NOTATNIK.Models;
using NOTATNIK.Models.Database;
using NOTATNIK.Views;
using NOTATNIK.Views.Controls;
using PropertyChanged;
using SQLite;
using System.Collections.Generic;
using Xamarin.Forms;

namespace NOTATNIK.ViewModels
{
    /// <summary> 
    /// Klasa pomocnicza do załadowania danych do widoku.
    /// </summary> 
    [AddINotifyPropertyChangedInterface]
    public class DashboardViewModel
    {
        /// <summary> 
        /// Lista obiektów TaskViewModel.
        /// </summary> 
        public List<TaskViewModel> Tasks = new List<TaskViewModel>();
        public bool HasItems { get; set; } = true;
        public bool NoItems { get; set; } = false;
        /// <summary> 
        /// Event do kliknięcia
        /// </summary> 
        public Command CmdAdd { get; set; }
        /// <summary> 
        /// Zmienna page
        /// </summary> 
        public Page Page { get; set; }

        /// <summary> 
        /// Konstruktor.
        /// </summary> 
        public DashboardViewModel()
        {
            CmdAdd = new Command(async () =>
            {
                await Page.Navigation.PushAsync(new AddTaskPage());
            });
        }
        /// <summary> 
        /// Metoda do pobrania z bazy danych oraz wczytywanie ich do widoku.
        /// </summary> 
        /// <param name="layout">StackLayout</param>
        public async void Load(StackLayout layout)
        {
            SQLiteAsyncConnection connection = new SQLiteAsyncConnection(Configuration.DATABASE);
            List<Task> tasksDB = await connection.Table<Task>().OrderByDescending(m => m.Id).ToListAsync();
            if (Tasks.Count < tasksDB.Count)
            {
                foreach (var task in tasksDB)
                {
                    TaskViewModel taskVM = new TaskViewModel()
                    {
                        Id = task.Id,
                        Subject = task.Subject,
                        Content = task.Content
                    };
                    Tasks.Add(taskVM);
                }
                HasItems = Tasks.Count > 0;
                NoItems = !HasItems;
                AddTasks(layout);
            }
        }
        /// <summary> 
        /// Metoda wczytywania widoku.
        /// </summary> 
        /// <param name="layout">StackLayout</param>
        public void AddTasks(StackLayout layout)
        {
            layout.Children.Clear();
            if (layout.Children.Count < 1)
            {
                foreach (var task in Tasks)
                {
                    task.CmdSelected = new Command(async () =>
                    {
                            AddTaskPage page = new AddTaskPage();
                            page.TaskId = task.Id;
                            await Page.Navigation.PushAsync(page);
                    });

                    TaskControl control = new TaskControl();
                    control.BindingContext = task;
                    layout.Children.Add(control);
                }
            }
        }
    }
}
