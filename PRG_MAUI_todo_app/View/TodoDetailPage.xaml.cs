using PRG_MAUI_todo_app.Model;
using PRG_MAUI_todo_app.ViewModel;
using System.Collections.ObjectModel;

namespace PRG_MAUI_todo_app.View
{
    public partial class ToDoDetailPage : ContentPage
    {
        public ObservableCollection<ToDoItem> ToDoList => ToDoService.Instance.ToDoItemsList;
        private string _editedDescription;
        public ToDoDetailPage()
        {
            InitializeComponent();
            _editedDescription = ToDoService.Instance.SelectedItem.Description;
            EditorText.Text = _editedDescription;
            BindingContext = ToDoService.Instance.SelectedItem;
        }

        private async void Button_SaveDesciption(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(EditorText.Text))
            {
                ToDoService.Instance.SelectedItem.Description = EditorText.Text;
                DisplayAlert("Sparat", "Beskrivningen har sparats", "Ok");
                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                DisplayAlert("Varning", "Lägg till en beskrivning", "Ok");
            }
        }

        private async void Button_GoBack(object sender, EventArgs e)
        {
            if(_editedDescription != EditorText.Text)
            {
                bool discard = await DisplayAlert("Osparade ändringar", "Vill du spara ändringarna?", "Spara inte", "Spara");
                if (!discard)
                {
                    Button_SaveDesciption(sender, e);
                }
            }
            await Shell.Current.GoToAsync("..");
        }
    }
}