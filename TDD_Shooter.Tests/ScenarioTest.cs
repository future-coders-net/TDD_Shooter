using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using TDD_Shooter.Model;
using System.Collections.Generic;

namespace TDD_Shooter.Tests
{
    [TestClass]
    public class ScenarioTest
    {
        [UITestMethod]
        public void SequentialEnemies()
        {
            String str = @"[
              { ""time"": 100, ""type"": 0, ""x"":10, ""y"": 60},
              { ""time"": 200, ""type"": 1, ""x"":20, ""y"": 70},
              { ""time"": 300, ""type"": 2, ""x"":30, ""y"": 80},
              { ""time"": 400, ""type"": 3, ""x"":40, ""y"": 90},
              { ""time"": 500, ""type"": 4, ""x"":50, ""y"": 100},
            ";
            Dictionary<int, List<AbstractEnemy>> story
                = ScenarioReader.Read(str);
            Assert.IsInstanceOfType(story[100][0], typeof(Enemy0));
            Assert.IsInstanceOfType(story[200][0], typeof(Enemy1));
            Assert.IsInstanceOfType(story[300][0], typeof(Enemy2));
            Assert.IsInstanceOfType(story[400][0], typeof(Enemy3));
            Assert.IsInstanceOfType(story[500][0], typeof(Enemy4));

            Enemy0 e0 = (Enemy0)story[100][0];
            Enemy1 e1 = (Enemy1)story[200][0];
            Enemy2 e2 = (Enemy2)story[300][0];
            Enemy3 e3 = (Enemy3)story[400][0];
            Enemy4 e4 = (Enemy4)story[500][0];
            Assert.AreEqual(10, e0.X);
            Assert.AreEqual(60, e0.Y);
            Assert.AreEqual(20, e1.X);
            Assert.AreEqual(70, e1.Y);
            Assert.AreEqual(30, e2.X);
            Assert.AreEqual(80, e2.Y);
            Assert.AreEqual(40, e3.X);
            Assert.AreEqual(90, e3.Y);
            Assert.AreEqual(50, e4.X);
            Assert.AreEqual(100, e4.Y);
        }

        [UITestMethod]
        public void SimultaneousEnemies()
        {
            String str = @"[
              { ""time"": 100, ""type"": 0, ""x"":10, ""y"": 60},
              { ""time"": 100, ""type"": 1, ""x"":20, ""y"": 70},
              { ""time"": 100, ""type"": 2, ""x"":30, ""y"": 80},
              { ""time"": 100, ""type"": 3, ""x"":40, ""y"": 90},
              { ""time"": 100, ""type"": 4, ""x"":50, ""y"": 100},
            ";
            Dictionary<int, List<AbstractEnemy>> story
                = ScenarioReader.Read(str);
            List<AbstractEnemy> enemies = story[100];
            Assert.IsInstanceOfType(enemies[0], typeof(Enemy0));
            Assert.IsInstanceOfType(enemies[1], typeof(Enemy1));
            Assert.IsInstanceOfType(enemies[2], typeof(Enemy2));
            Assert.IsInstanceOfType(enemies[3], typeof(Enemy3));
            Assert.IsInstanceOfType(enemies[4], typeof(Enemy4));
        }

        [UITestMethod]
        public void Enemy2Speed()
        {
            String str = @"[
              { ""time"": 100, ""type"": 2, ""x"":30, ""y"": 80},
              { ""time"": 200, ""type"": 2, ""x"":30, ""y"": 80, ""sx"":-5},
              { ""time"": 300, ""type"": 2, ""x"":30, ""y"": 80, ""sx"":5},
              { ""time"": 400, ""type"": 2, ""x"":30, ""y"": 80, ""sy"":5},
              { ""time"": 500, ""type"": 2, ""x"":30, ""y"": 80, ""sy"":10},
            ";
            Dictionary<int, List<AbstractEnemy>> story
                = ScenarioReader.Read(str);
            Assert.AreEqual(0, story[100][0].SpeedX);
            Assert.AreEqual(-5, story[200][0].SpeedX);
            Assert.AreEqual(+5, story[300][0].SpeedX);
            Assert.AreEqual(5, story[400][0].SpeedY);
            Assert.AreEqual(10, story[500][0].SpeedY);
            Assert.AreEqual(story[200][0].Theta, 0);
            Assert.AreEqual(story[300][0].Theta, 0);

            ViewModel vm = new ViewModel();
            vm.AddEnemy(story[200][0]);
            vm.AddEnemy(story[300][0]);
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(vm.Enemies[0].Theta, i);
                Assert.AreEqual(vm.Enemies[1].Theta, -i);
                vm.Tick(1);
            }
        }

        [UITestMethod]
        [ExpectedException(typeof(Newtonsoft.Json.JsonReaderException))]
        public void InvalidFormat()
        {
            String str = @"[{]";
            Dictionary<int, List<AbstractEnemy>> story
                = ScenarioReader.Read(str);
            Assert.Fail();
        }
    }
}
