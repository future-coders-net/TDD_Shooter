using System;
using Windows.Foundation;
using Windows.UI.Xaml.Media.Imaging;

namespace TDD_Shooter.Model
{
    class Bullet : Drawable
    {
        internal const double Speed = 10;

        internal bool IsEnemy { set; get; }

        internal Bullet(double x, double y,
            double dx = 0, double dy = -Bullet.Speed,
            bool isEnemy = false) : base(10, 10)
        {
            IsEnemy = isEnemy;
            String file = IsEnemy ? "bullet1.png" : "bullet0.png";
            Source = new BitmapImage(
                new Uri("ms-appx:///Images/" + file));
            X = x;
            Y = y;
            SpeedX = dx;
            SpeedY = dy;
        }

        public override void Tick()
        {
            Y += SpeedY;
            X += SpeedX;
            Rect r = this.Rect;
            r.Intersect(ViewModel.Field);
            if (r == Rect.Empty)
            {
                IsValid = false;
            }
        }
    }
}
