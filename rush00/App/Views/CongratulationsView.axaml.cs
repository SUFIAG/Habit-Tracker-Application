using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace App.Views
{
    public partial class CongratulationsView : UserControl
    {
        public CongratulationsView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}