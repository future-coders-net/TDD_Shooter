using Windows.System;
using TDD_Shooter.Model;
using System.Collections.Generic;
namespace TDD_Shooter
{
    class ViewModel
    {
        private Dictionary<VirtualKey, bool> keyMap
            = new Dictionary<VirtualKey, bool>();
        public Ship Ship { get; set; }

        internal ViewModel()
        {
            Ship = new Ship();
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
