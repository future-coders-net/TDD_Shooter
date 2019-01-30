using System;
using System.ComponentModel;
using Windows.UI.Xaml.Media.Imaging;
namespace TDD_Shooter.Model
{
    class Enemy : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private double x;
        public double X
        {
            set { x = value; NotifyPropertyChanged("X"); }
            get { return x; }
        }

        private double y;
        public double Y
        {
            set { y = value; NotifyPropertyChanged("Y"); }
            get { return y; }
        }

        public BitmapImage Source { get; set; }
        public double Speed { get { return 5; } }

        internal Enemy(double x, double y)
        {
            Source = new BitmapImage(
                new Uri("ms-appx:///Images/enemy0_0.png"));
            X = x;
            Y = y;
        }

        internal void Move()
        {
            Y += Speed;
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
