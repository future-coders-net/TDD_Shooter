using System;
using Windows.UI.Xaml.Media.Imaging;

namespace TDD_Shooter.Model
{
    class Back : Drawable
    {
        internal Back(String source) : base(632, 3328)
        {
            Source = new BitmapImage(new Uri(source));
            Y = -2528;
        }

        public override void Tick()
        {
            Y += SpeedY;
            if (Y > 0)
            {
                Y = -2528;
            }
        }

    }
}
