using System;
using Windows.UI.Xaml.Media.Imaging;

namespace TDD_Shooter.Model
{
    class Ship : Drawable
    {
        static internal readonly double Speed = 10;

        internal Ship() : base(60, 60)
        {
            Source = new BitmapImage(new Uri("ms-appx:///Images/ship.png"));
        }

        internal override void Tick()
        {
            X += SpeedX;
            Y += SpeedY;
        }
    }
}
