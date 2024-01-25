using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PRG_MAUI_todo_app
{
    internal class StorageManager
    {
        private string filePath = Path.Combine(FileSystem.AppDataDirectory, "todoitems.json");

        public void SaveTodoItems(List<TodoItems> todoItems)
        {
            string json = JsonSerializer.Serialize(todoItems, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public List<TodoItems> LoadTodoItems()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<TodoItems>>(json) ?? new List<TodoItems>();
            }
            return new List<TodoItems>();
        }
    }
}



