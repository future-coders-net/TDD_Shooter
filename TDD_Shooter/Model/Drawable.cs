using System;
using System.ComponentModel;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Foundation;

namespace TDD_Shooter.Model
{
    abstract class Drawable : INotifyPropertyChanged
    {
        internal abstract void Tick();

        internal virtual bool IsValid { set; get; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }

        internal Rect Rect;

        public double X
        {
            get { return Rect.X; }
            set { Rect.X = value; NotifyPropertyChanged("X"); }
        }

        public double Y
        {
            get { return Rect.Y; }
            set { Rect.Y = value; NotifyPropertyChanged("Y"); }
        }

        private BitmapImage source;
        public BitmapImage Source
        {
            get { return source; }
            protected set { source = value; NotifyPropertyChanged("Source"); }
        }

        public double Width { get { return Rect.Width; } }
        public double Height { get { return Rect.Height; } }
        public double SpeedX { get; set; }
        public double SpeedY { get; set; }

        protected Drawable(double w, double h)
        {
            Rect.Width = w;
            Rect.Height = h;
            IsValid = true;
        }

        public void Move()
        {
            X += SpeedX;
            Y += SpeedY;
        }
    }
}
