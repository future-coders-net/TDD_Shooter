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
        private int count = 0;

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

            Model.Message.Text = "GET READY...";
            Model.AddEnemy(new Enemy(300, 0));
            Model.AddEnemy(new Enemy(500, -50));
            Model.Ship.X = 300;
            Model.Ship.Y = 700;
        }

        private void Tick(object sender, object e)
        {
            if (++count == 50)
            {
                Model.Message.Text = "";
            }
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
