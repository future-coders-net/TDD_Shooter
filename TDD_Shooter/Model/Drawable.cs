using System;
using System.ComponentModel;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Foundation;

namespace TDD_Shooter.Model
{
    abstract class Drawable : INotifyPropertyChanged, IClock
    {
        abstract public void Tick();

        protected bool isValid;
        public virtual bool IsValid
        {
            get { return isValid; }
            set
            {
                isValid = value;
                NotifyPropertyChanged("IsValid");
            }
        }

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

        private double theta = 0;
        public virtual double Theta
        {
            get { return theta; }
            set { theta = value; NotifyPropertyChanged("Theta"); }
        }
        public double CenterX { get { return Width / 2; } }
        public double CenterY { get { return Height / 2; } }


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
