using PRG_MAUI_todo_app.Model;
using PRG_MAUI_todo_app.ViewModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PRG_MAUI_todo_app.View
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<ToDoItem> ToDoItemsList => ToDoService.Instance.ToDoItemsList;
        public bool swiped = false;

        public MainPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            TheCollectionView.SelectedItem = null;
        }


        private async void Button_OnAddClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AddListItem.Text))
            {
                ToDoItemsList.Add(new ToDoItem { Title = AddListItem.Text });
                AddListItem.Text = string.Empty;
            }
            else
            {
                await DisplayAlert("Meddelande", $"Det går inte att lägga till en tom uppgift!", "Ok");
            }
        }


        private async void DeleteOnSwipe(object sender, EventArgs e)
        {
            swiped = true;
            var swipe = sender as SwipeItem;
            var swipedItem = (ToDoItem)swipe.BindingContext;

            if (ToDoItemsList.Contains(swipedItem))
            {
                bool answer = await DisplayAlert("Confirm Delete", $"Are you sure you want to delete '{swipedItem}'?", "Yes", "No");
                if (answer)
                {
                    ToDoItemsList.Remove(swipedItem);
                }
            }

            await Task.Delay(250);
            swiped = false;
            swipedItem = null;
        }

        private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            if (swiped) return;

            if (e.CurrentSelection.FirstOrDefault() is ToDoItem selectedItem)
            {
                ToDoService.Instance.SelectedItem = selectedItem;
                await Shell.Current.GoToAsync(nameof(ToDoDetailPage));
            }
        }
    }
}


