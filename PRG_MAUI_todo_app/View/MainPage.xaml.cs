using Microsoft.Maui.Controls;
using PRG_MAUI_todo_app.Model;
using System.Collections.ObjectModel;

namespace PRG_MAUI_todo_app.View
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<ToDoItem> ToDoItemsList { get; set; }

        public MainPage()
        {
            InitializeComponent();

            ToDoItemsList = new ObservableCollection<ToDoItem>();
            this.BindingContext = this;
        }

        private void OnAddClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AddListItem.Text))
            {
                ToDoItemsList.Add(new ToDoItem { Title = AddListItem.Text }); // tidigare ToDoItemsList.Add(AddListItem.Text);
                AddListItem.Text = string.Empty;
            }
        }


        private async void DeleteOnSwipe(object sender, EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var item = (ToDoItem)swipeItem.BindingContext;

            if (ToDoItemsList.Contains(item))
            {
                bool answer = await DisplayAlert("Confirm Delete", $"Are you sure you want to delete '{item}'?", "Yes", "No");
                if (answer)
                {
                    ToDoItemsList.Remove(item);
                }
            }
        }

        private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is ToDoItem selectedItem)
            {
                await Shell.Current.GoToAsync($"///TodoDetailPage?title={selectedItem.Title}&description={selectedItem.Description}");
            }
        }
    }
}


