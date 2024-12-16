using System.Collections.ObjectModel;

namespace PRG_MAUI_todo_app
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public MainPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<string>();
            this.BindingContext = this;
        }

        private void OnAddClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AddListItem.Text))
            {
                Items.Add(AddListItem.Text);
                AddListItem.Text = string.Empty;
            }
        }

        private async void DeleteOnSwipe(object sender, EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var item = (string)swipeItem.BindingContext;

            if (Items.Contains(item))
            {
                bool answer = await DisplayAlert("Confirm Delete", $"Are you sure you want to delete '{item}'?", "Yes", "No");
                if (answer)
                {
                    Items.Remove(item);
                }
            }
        }
    }
}


