using System;
using System.ComponentModel;
using Windows.UI.Xaml.Media.Imaging;

namespace TDD_Shooter.Model
{
    class Back : INotifyPropertyChanged
    {
        private double y;
        public static readonly double SpeedY = 5;
        public event PropertyChangedEventHandler PropertyChanged;

        public double X
        {
            get { return 0; }
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

        public double Width { get { return 632; } }
        public double Height { get { return 3328; } }
        public BitmapImage Source { get; set; }

        internal Back(String source)
        {
            Source = new BitmapImage(new Uri(source));
            Y = -2528;
        }

        internal void Scroll(double dy)
        {
            Y += dy;
            if (Y > 0)
            {
                Y = -2528;
            }
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
