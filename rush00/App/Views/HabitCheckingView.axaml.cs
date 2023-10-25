using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace App.Views
{
    public partial class HabitCheckingView : UserControl
    {
        public HabitCheckingView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}