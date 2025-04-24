namespace PRG_MAUI_todo_app.View;

[QueryProperty(nameof(Title), "title")]
[QueryProperty(nameof(Description), "description")]
public partial class TodoDetailPage : ContentPage
{

    public string Title { get; set; }
    public string Description { get; set; }

    public TodoDetailPage()
    {
        InitializeComponent();
        BindingContext = this;
    }
}
