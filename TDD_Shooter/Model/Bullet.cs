using System;
using Windows.UI.Xaml.Media.Imaging;

namespace TDD_Shooter.Model
{
    class Bullet : Drawable
    {
        internal Bullet(double x, double y) : base(10, 10)
        {
            Source = new BitmapImage(new Uri("ms-appx:///Images/bullet0.png"));
            X = x - Width / 2;
            Y = y - Height / 2;
            SpeedY = -10;
        }

        internal override void Tick()
        {
            Y += SpeedY;
        }
    }
}
