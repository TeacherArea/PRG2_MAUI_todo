using PRG_MAUI_todo_app.View;

namespace PRG_MAUI_todo_app
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ToDoDetailPage), typeof(ToDoDetailPage));
        }
    }
}
