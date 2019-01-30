using System;
using System.ComponentModel;
using Windows.UI.Xaml.Media.Imaging;

namespace TDD_Shooter.Model
{
    class Ship : INotifyPropertyChanged
    {
        private double x, y;
        public static readonly double Speed = 5;
        public event PropertyChangedEventHandler PropertyChanged;

        public double X
        {
            set
            {
                x = value;
                NotifyPropertyChanged("X");
            }
            get { return x; }
        }

        public double Y
        {
            set
            {
                y = value;
                NotifyPropertyChanged("Y");
            }
            get { return y; }
        }

        public double Width { get { return 60; } }
        public double Height { get { return 60; } }
        public BitmapImage Source { get; set; }

        internal Ship()
        {
            Source = new BitmapImage(new Uri("ms-appx:///Images/ship.png"));
        }

        internal void Move(double dx, double dy)
        {
            X += dx;
            Y += dy;
        }

        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
