using Windows.UI.Xaml.Controls;

namespace TDD_Shooter
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = new ViewModel();
        }
    }
}
