using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TDD_Shooter.Model;

namespace TDD_Shooter
{
    class ScenarioReader
    {
        static internal Dictionary<int, List<AbstractEnemy>> Read(String content)
        {
            Dictionary<int, List<AbstractEnemy>> story
                = new Dictionary<int, List<AbstractEnemy>>();

            var json = (dynamic)JsonConvert.DeserializeObject(content);
            foreach (var e in json)
            {
                long time = e["time"].Value;
                long type = e["type"].Value;
                long x = e["x"].Value;
                long y = e["y"].Value;
                long sx = e["sx"]?.Value ?? 0;
                long sy = e["sy"]?.Value ?? 0;

                AbstractEnemy enemy = null;
                switch (type)
                {
                    case 0: enemy = new Enemy0(x, y); break;
                    case 1: enemy = new Enemy1(x, y); break;
                    case 2:
                        double t = sx > 0 ? -1 : +1;
                        enemy = new Enemy2(x, y, sx, sy, t);
                        break;
                    case 3: enemy = new Enemy3(x, y); break;
                    case 4: enemy = new Enemy4(x, y); break;
                }

                List<AbstractEnemy> enemies;
                if (story.ContainsKey((int)time))
                {
                    enemies = story[(int)time];
                }
                else
                {
                    enemies = new List<AbstractEnemy>();
                    story[(int)time] = enemies;
                }

                enemies.Add(enemy);
            }
            return story;
        }
    }
}
