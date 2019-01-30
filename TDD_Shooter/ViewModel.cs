using TDD_Shooter.Model;
using Windows.System;
using Windows.Foundation;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace TDD_Shooter
{
    class ViewModel
    {
        private Dictionary<VirtualKey, bool> keyMap
            = new Dictionary<VirtualKey, bool>();

        public Ship Ship { get; set; }
        public Back Back { get; set; }
        public Back Cloud { get; set; }
        public static readonly Rect Field = new Rect(0, 0, 643, 800);
        public double Width { get { return Field.Width; } }
        public double Height { get { return Field.Height; } }

        private ObservableCollection<Drawable> drawables
            = new ObservableCollection<Drawable>();
        public ObservableCollection<Drawable> Drawables
        {
            get { return drawables; }
        }

        public List<Drawable> Enemies
        {
            get
            {
                IEnumerable<Drawable> data = Drawables.Where(e => e is Enemy);
                return data.ToList<Drawable>();
            }
        }

        public List<Drawable> Bullets
        {
            get
            {
                IEnumerable<Drawable> data = Drawables.Where(e => e is Bullet);
                return data.ToList<Drawable>();
            }
        }

        internal ViewModel()
        {
            Ship = new Ship();
            Back = new Back("ms-appx:///Images/back.png");
            Cloud = new Back("ms-appx:///Images/back_cloud.png");
            drawables.Add(Back);
            drawables.Add(Cloud);
            drawables.Add(Ship);
        }

        internal void KeyDown(VirtualKey key)
        {
            keyMap[key] = true;
        }

        internal void KeyUp(VirtualKey key)
        {
            keyMap[key] = false;
        }

        private Boolean IsKeyDown(VirtualKey key)
        {
            return keyMap.ContainsKey(key) && keyMap[key];
        }

        internal void Tick(int frame)
        {
            for (int i = 0; i < frame; i++)
            {
                Back.Scroll(1);
                Cloud.Scroll(2);

                Ship.SpeedX = 0;
                Ship.SpeedY = 0;
                if (IsKeyDown(VirtualKey.Left))
                {
                    Ship.SpeedX = -Ship.Speed;
                }
                if (IsKeyDown(VirtualKey.Right))
                {
                    Ship.SpeedX = Ship.Speed;
                }
                if (IsKeyDown(VirtualKey.Up))
                {
                    Ship.SpeedY = -Ship.Speed;
                }
                if (IsKeyDown(VirtualKey.Down))
                {
                    Ship.SpeedY = Ship.Speed;
                }
                if (IsKeyDown(VirtualKey.Space))
                {
                    Bullet b = new Bullet(Ship.X + Ship.Width / 2,
                        Ship.Y + Ship.Height / 2);
                    AddBullet(b);
                    keyMap[VirtualKey.Space] = false;
                }

                foreach (Drawable e in Drawables.ToArray())
                {
                    e.Move();
                    if (e.Y > Field.Height || e.Y + e.Height < 0 ||
                        e.X > Field.Width || e.X + e.Width < 0)
                    {
                        Drawables.Remove(e);
                    }
                }
            }
            Ship.Y = Math.Max(0, Math.Min(Field.Height - Ship.Height, Ship.Y));
            Ship.X = Math.Max(0, Math.Min(Field.Width - Ship.Width, Ship.X));
        }

        internal void AddEnemy(Enemy e)
        {
            Drawables.Add(e);
        }

        internal void AddBullet(Bullet b)
        {
            Drawables.Add(b);
        }

    }
}
