using System;
using Windows.UI.Xaml.Media.Imaging;

namespace TDD_Shooter.Model
{
    class Blast : Drawable
    {
        private static BitmapImage[] images = new BitmapImage[8];
        private int counter = 0;

        static Blast()
        {
            for (int i = 0; i < 8; i++)
            {
                images[i] = new BitmapImage(
                    new Uri("ms-appx:///Images/explode_" + i + ".png"));
            }
        }

        internal Blast(double x, double y) : base(96, 96)
        {
            X = x - Width / 2;
            Y = y - Height / 2;
            Source = images[counter];
        }

        internal override void Tick()
        {
            counter++;
            Source = images[Math.Min(7, counter)];
        }

        internal override bool IsValid
        {
            get { return counter < 8; }
        }
    }
}
