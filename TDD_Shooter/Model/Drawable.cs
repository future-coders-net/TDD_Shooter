using System;
using System.ComponentModel;
using Windows.UI.Xaml.Media.Imaging;

namespace TDD_Shooter.Model
{
    class Drawable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }

        protected double x, y;

        public double X
        {
            get { return x; }
            set { x = value; NotifyPropertyChanged("X"); }
        }

        public double Y
        {
            get { return y; }
            set { y = value; NotifyPropertyChanged("Y"); }
        }

        public double Width { get; }
        public double Height { get; }
        public double SpeedX { get; set; }
        public double SpeedY { get; set; }
        public BitmapImage Source { get; protected set; }

        protected Drawable(double w, double h)
        {
            Width = w;
            Height = h;
        }

        public void Move()
        {
            X += SpeedX;
            Y += SpeedY;
        }
    }
}
