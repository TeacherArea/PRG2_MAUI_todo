using PRG_MAUI_todo_app.Model;
using System.Collections.ObjectModel;

namespace PRG_MAUI_todo_app.ViewModel
{
    internal class ToDoService
    {
        private static ToDoService _instance;
        public static ToDoService Instance => _instance ?? (_instance = new ToDoService());
        public ObservableCollection<ToDoItem> ToDoItemsList { get; } = new();
        public ToDoItem SelectedItem { get; set; }
        public ToDoService() { }
    }
}
