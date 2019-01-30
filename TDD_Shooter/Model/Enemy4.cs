using System;
using Windows.UI.Xaml.Media.Imaging;

namespace TDD_Shooter.Model
{
    internal class Enemy4 : AbstractEnemy
    {
        Random r;
        int hitCount = 0;

        internal Enemy4(double x, double y, int seed = 0) : base(x, y, 150, 150)
        {
            Source = new BitmapImage(new Uri("ms-appx:///Images/enemy4.png"));
            X = x;
            Y = y;
            r = new Random(seed == 0 ? DateTime.Now.Millisecond : seed);
        }

        public override void Tick()
        {
            if (count++ % 50 == 0)
            {
                int rx = r.Next(0, (int)(ViewModel.Field.Width - Width));
                int ry = r.Next(0, (int)(ViewModel.Field.Height - Height));
                SpeedX = (rx - X) / 50.0;
                SpeedY = (ry - Y) / 50.0;
            }
            X += SpeedX;
            Y += SpeedY;
            Theta += 1;
        }

        internal override bool IsFire => count % 25 == 0 && count > 0;

        public override bool IsValid
        {
            get
            {
                return hitCount < 20;
            }
            set
            {
                if (value == false)
                {
                    hitCount++;
                }
            }
        }
    }
}
