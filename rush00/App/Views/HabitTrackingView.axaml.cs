using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace App.Views
{
    public partial class HabitTrackingView : UserControl
    {
        public HabitTrackingView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}