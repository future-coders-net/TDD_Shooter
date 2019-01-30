using System;
using Windows.UI.Xaml.Media.Imaging;

namespace TDD_Shooter.Model
{
    internal class Enemy2 : AbstractEnemy
    {
        private double delta;

        internal Enemy2(double x, double y, double sx, double sy, double t)
            : base(x, y, 75, 160)
        {
            Source = new BitmapImage(new Uri("ms-appx:///Images/enemy2.png"));
            X = x;
            Y = y;
            SpeedX = sx;
            SpeedY = sy;
            delta = t;
        }

        internal override bool IsFire
        {
            get { return SpeedY == 0; }
        }

        public override void Tick()
        {
            Y += SpeedY;
            X += SpeedX;
            Theta += delta;
        }

    }
}
