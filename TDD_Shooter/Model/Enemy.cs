﻿using System;
using Windows.UI.Xaml.Media.Imaging;

namespace TDD_Shooter.Model
{
    internal class Enemy : Drawable
    {
        private int count = 0;

        internal Enemy(double x, double y) : base(50, 50)
        {
            Source = new BitmapImage(new Uri("ms-appx:///Images/enemy0_0.png"));
            X = x;
            Y = y;
            SpeedY = 5;
        }

        public override void Tick()
        {
            Y += SpeedY;
        }

        internal bool IsFire
        {
            get { return ++count == 20; }
        }
    }
}
