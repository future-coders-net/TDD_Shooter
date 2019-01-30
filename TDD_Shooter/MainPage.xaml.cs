using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Core;
using TDD_Shooter.Model;

namespace TDD_Shooter
{
    public sealed partial class MainPage : Page
    {
        ViewModel Model;
        DispatcherTimer timer;

        public MainPage()
        {
            this.InitializeComponent();
            Model = new ViewModel();
            DataContext = Model;
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Tick += Tick;
            timer.Start();

            Model.AddEnemy(new Enemy(200, 100));
        }

        private void Tick(object sender, object e)
        {
            Model.Tick(1);
        }

        private void CoreWindow_KeyDown(CoreWindow sender, KeyEventArgs args)
        {
            Model.KeyDown(args.VirtualKey);
        }

        private void CoreWindow_KeyUp(CoreWindow sender, KeyEventArgs args)
        {
            Model.KeyUp(args.VirtualKey);
        }

    }
}
