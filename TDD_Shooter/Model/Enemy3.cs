using System;
using Windows.UI.Xaml.Media.Imaging;

namespace TDD_Shooter.Model
{
    internal class Enemy3 : AbstractEnemy
    {
        internal Enemy3(double x, double y) : base(x, y, 120, 120)
        {
            Source = new BitmapImage(new Uri("ms-appx:///Images/enemy3.png"));
            X = x;
            Y = y;
            SpeedX = 0;
            SpeedY = 1;
        }

        internal override bool IsFire
        {
            get { return count % 100 == 0 && count > 0; }
        }

        public override void Tick()
        {
            count++;
            Y += SpeedY;
            X += SpeedX;
        }
    }
}
