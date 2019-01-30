using Windows.System;
using Windows.Foundation;
using System.Collections.Generic;
using TDD_Shooter.Model;
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

        internal ViewModel()
        {
            Ship = new Ship();
            Back = new Back("ms-appx:///Images/back.png");
            Cloud = new Back("ms-appx:///Images/back_cloud.png");
        }

        internal void KeyDown(VirtualKey key)
        {
            keyMap[key] = true;
        }

        internal void KeyUp(VirtualKey key)
        {
            keyMap[key] = false;
        }

        internal void Tick(int frame)
        {
            for (int i = 0; i < frame; i++)
            {
                Back.Scroll(1);
                Cloud.Scroll(2);
                if (keyMap.ContainsKey(VirtualKey.Left) &&
                    keyMap[VirtualKey.Left])
                {
                    Ship.Move(-Ship.Speed, 0);
                }
                if (keyMap.ContainsKey(VirtualKey.Right) &&
                    keyMap[VirtualKey.Right])
                {
                    Ship.Move(+Ship.Speed, 0);
                }
                if (keyMap.ContainsKey(VirtualKey.Up) &&
                    keyMap[VirtualKey.Up])
                {
                    Ship.Move(0, -Ship.Speed);
                }
                if (keyMap.ContainsKey(VirtualKey.Down) &&
                    keyMap[VirtualKey.Down])
                {
                    Ship.Move(0, +Ship.Speed);
                }
            }
        }

    }
}
