
namespace PRG_MAUI_todo_app.Debugging
{
    public class DebugGrid : Grid
    {
        public DebugGrid()
        {
            Loaded += (s, e) => AddDebugBorders();
        }

        private void AddDebugBorders()
        {
            for (int row = 0; row < RowDefinitions.Count; row++)
            {
                for (int col = 0; col < ColumnDefinitions.Count; col++)
                {
                    var border = new Border
                    {
                        Stroke = Colors.Red,
                        StrokeThickness = 1
                    };

                    Grid.SetRow((BindableObject)border, row);
                    Grid.SetColumn((BindableObject)border, col);

                    Children.Add(border);
                }
            }
        }
    }
}
