using System;
using Windows.UI.Xaml.Media.Imaging;

namespace TDD_Shooter.Model
{
    class Ship
    {
        public double X { set; get; }
        public double Y { set; get; }
        public double Width { get { return 60; } }
        public double Height { get { return 60; } }
        public BitmapImage Source { get; set; }
        internal Ship()
        {
            Source = new BitmapImage(new Uri("ms-appx:///Images/ship.png"));
        }
    }
}
