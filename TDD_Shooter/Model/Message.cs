using System;
using System.ComponentModel;

namespace TDD_Shooter.Model
{
    public class Message : INotifyPropertyChanged, IClock
    {
        private String text;
        private double theta;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Tick()
        {
            theta += 0.1;
            NotifyPropertyChanged("Alpha");
        }

        public double Alpha
        {
            get { return (Math.Sin(theta) + 1) / 2; }
        }

        public String Text
        {
            get { return text; }
            set { text = value; NotifyPropertyChanged("Text"); }
        }
    }
}
