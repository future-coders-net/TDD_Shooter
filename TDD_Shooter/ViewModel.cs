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
        public Message Message { get; set; }
        public static readonly Rect Field = new Rect(0, 0, 643, 800);
        public double Width { get { return Field.Width; } }
        public double Height { get { return Field.Height; } }

        private ObservableCollection<Drawable> drawables
            = new ObservableCollection<Drawable>();
        public ObservableCollection<Drawable> Drawables
        {
            get { return drawables; }
        }

        private List<Drawable> Filter<T>()
        {
            IEnumerable<Drawable> data = Drawables.Where(e => e is T);
            return data.ToList<Drawable>();
        }

        public List<Drawable> Enemies { get { return Filter<AbstractEnemy>(); } }
        public List<Drawable> Bullets { get { return Filter<Bullet>(); } }
        public List<Drawable> Blasts { get { return Filter<Blast>(); } }

        private int totalBullets = 0;
        public int TotalBullets { get { return totalBullets; } }


        internal ViewModel()
        {
            Message = new Message();
            Message.Text = "PUSH SPACE TO START";

            Ship = new Ship();
            Back = new Back("ms-appx:///Images/back.png");
            Back.SpeedY = 1;
            Cloud = new Back("ms-appx:///Images/back_cloud.png");
            Cloud.SpeedY = 2;
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

                Message.Tick();
                foreach (Drawable e in Drawables.ToArray())
                {
                    e.Tick();
                    Rect r = e.Rect;
                    r.Intersect(Field);
                    if (!e.IsValid || r.IsEmpty)
                    {
                        Drawables.Remove(e);
                    }
                    if (e is AbstractEnemy)
                    {
                        AbstractEnemy enemy = (AbstractEnemy)e;
                        if (enemy.IsFire)
                        {
                            CreateEnemyBullet(enemy);
                        }
                        if (Crash(e, Ship))
                        {
                            Ship.IsValid = false;
                            Message.Text = "GAME OVER";
                        }
                    }
                }

                foreach (Bullet b in Bullets)
                {
                    if (b.IsEnemy)
                    {
                        if (Crash(b, Ship))
                        {
                            Ship.IsValid = false;
                            Message.Text = "GAME OVER";
                        }
                        continue;
                    }

                    foreach (AbstractEnemy e in Enemies)
                    {
                        if (Crash(b, e) && b.IsValid && e.IsValid)
                        {
                            e.IsValid = false;
                            b.IsValid = false;
                            Blast blast = new Blast(b.X + b.Width / 2, b.Y + b.Height / 2);
                            Drawables.Add(blast);
                        }
                    }
                }
            }
            Ship.Y = Math.Max(0, Math.Min(Field.Height - Ship.Height, Ship.Y));
            Ship.X = Math.Max(0, Math.Min(Field.Width - Ship.Width, Ship.X));
        }

        internal void AddEnemy(AbstractEnemy e)
        {
            Drawables.Add(e);
        }

        internal void AddBullet(Bullet b)
        {
            totalBullets++;
            Drawables.Add(b);
        }

        private void CreateEnemyBullet(AbstractEnemy e)
        {
            double sX = e.X + e.Width / 2;
            double sY = e.Y + e.Height / 2;
            double eX = Ship.X + Ship.Width / 2;
            double eY = Ship.Y + Ship.Height / 2;
            double theta = Math.Atan2(eY - sY, eX - sX);
            double dx = Math.Cos(theta) * Bullet.Speed;
            double dy = Math.Sin(theta) * Bullet.Speed;
            Bullet b = new Bullet(sX, sY, dx, dy, true);
            AddBullet(b);
        }

        internal static bool Crash(Drawable d0, Drawable d1)
        {
            Rect r = d0.Rect;
            r.Intersect(d1.Rect);
            return r != Rect.Empty;
        }
    }
}
