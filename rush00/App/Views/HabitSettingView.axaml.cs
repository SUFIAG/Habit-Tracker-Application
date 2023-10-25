using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace App.Views
{
    public partial class HabitSettingView : UserControl
    {
        public HabitSettingView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
