using System;
using Windows.UI.Xaml.Media.Imaging;

namespace TDD_Shooter.Model
{
    internal class Enemy1 : AbstractEnemy
    {
        internal Enemy1(double x, double y) : base(50, 50)
        {
            Source = new BitmapImage(new Uri("ms-appx:///Images/enemy1.png"));
            X = x;
            Y = y;
            SpeedY = 20;
        }

        public override void Tick()
        {
            SpeedY -= 0.5;
            Y += SpeedY;
        }

        internal override bool IsFire
        {
            get { return SpeedY == 0; }
        }

    }
}
