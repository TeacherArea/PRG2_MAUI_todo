using System.Collections.ObjectModel;

namespace PRG_MAUI_todo_app
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<TodoItems> Items { get; set; }

        public MainPage()
        {
            InitializeComponent();

            var storageManager = new StorageManager();
            var savedItems = storageManager.LoadTodoItems();
            Items = new ObservableCollection<TodoItems>(savedItems);
            this.BindingContext = this;
        }


        private void OnAddClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AddListItem.Text))
            {
                var newItem = new TodoItems(AddListItem.Text, DateTime.Now, false);
                Items.Add(newItem);
                AddListItem.Text = string.Empty; // Rensa Entry efter tillägg

                var storageManager = new StorageManager(); // Spara till fil
                storageManager.SaveTodoItems(Items.ToList());
            }
        }

        private async void OnDeleteSwipeItemInvoked(object sender, EventArgs e)
        {
            var swipeItem = (SwipeItem)sender;
            var item = (TodoItems)swipeItem.BindingContext;

            bool answer = await DisplayAlert("Confirm Delete", $"Are you sure you want to delete '{item.Title}'?", "Yes", "No");
            if (answer)
            {
                Items.Remove(item);

                var storageManager = new StorageManager(); // Spara ändringarna till fil
                storageManager.SaveTodoItems(Items.ToList());
            }
        }
    }
}
