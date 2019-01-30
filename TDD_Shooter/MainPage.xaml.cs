using System;
using System.Collections.Generic;
using Windows.Storage;
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
        Dictionary<int, List<AbstractEnemy>> story
            = new Dictionary<int, List<AbstractEnemy>>();

        public MainPage()
        {
            this.InitializeComponent();
            ReadScenarioAsync();

            Model = new ViewModel();
            DataContext = Model;
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Tick += Tick;
            timer.Start();

            Model.Message.Text = "GET READY...";
            Model.Ship.X = 300;
            Model.Ship.Y = 700;
        }

        private async void ReadScenarioAsync()
        {
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(
                new Uri("ms-appx:///Settings/scenario.json"));
            string text = await FileIO.ReadTextAsync(file);
            story = ScenarioReader.Read(text);
        }

        private void Tick(object sender, object e)
        {
            if (story.ContainsKey(count))
            {
                List<AbstractEnemy> enemies = story[count];
                foreach (AbstractEnemy enemy in enemies)
                {
                    Model.AddEnemy(enemy);
                }
                story.Remove(count);
            }

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
