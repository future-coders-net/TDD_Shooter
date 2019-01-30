using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using TDD_Shooter.Model;
namespace TDD_Shooter.Tests
{
    [TestClass]
    public class EnemyTest
    {
        [UITestMethod]
        public void CreateEnemy()
        {
            ViewModel vm = new ViewModel();
            Assert.AreEqual(vm.Enemies.Count, 0);

            Enemy0 enemy = new Enemy0(100, -50);
            vm.AddEnemy(enemy);
            Assert.AreEqual(vm.Enemies.Count, 1);
            Assert.AreEqual(100, enemy.X);
            Assert.AreEqual(-50, enemy.Y);
            vm.Tick(1);
            Assert.AreEqual(100, enemy.X);
            Assert.AreEqual(-50 + enemy.SpeedY, enemy.Y);
            Assert.AreEqual(vm.Enemies.Count, 1);
            int nFrame = (int)(ViewModel.Field.Height / enemy.SpeedY) + 10;
            vm.Tick(nFrame);
            Assert.AreEqual(vm.Enemies.Count, 0);
        }

        [UITestMethod]
        public void HitEnemy()
        {
            ViewModel vm = new ViewModel();
            vm.Ship.X = 300;
            vm.Ship.Y = 300;

            Enemy0 enemy = new Enemy0(300, 0);
            vm.AddEnemy(enemy);

            vm.KeyDown(Windows.System.VirtualKey.Space);
            vm.Tick(1);
            Bullet bullet = (Bullet)vm.Bullets[0];

            int nFrame = (int)((bullet.Y - (enemy.Y + enemy.Height))
                / (enemy.SpeedY - bullet.SpeedY));
            vm.Tick(nFrame + 1);

            Assert.IsFalse(enemy.IsValid);
            Assert.IsFalse(bullet.IsValid);
            Assert.AreEqual(1, vm.Blasts.Count);

            Blast blast = (Blast)vm.Blasts[0];
            Assert.AreEqual(bullet.X + bullet.Width / 2, blast.X + blast.Width / 2);
            Assert.AreEqual(bullet.Y + bullet.Height / 2, blast.Y + blast.Height / 2);

            vm.Tick(10);
            Assert.AreEqual(0, vm.Blasts.Count);
        }

        [UITestMethod]
        public void Enemy1Movement()
        {
            ViewModel vm = new ViewModel();
            Enemy1 e = new Enemy1(200, 0);
            vm.AddEnemy(e);

            Assert.AreEqual(vm.Enemies.Count, 1);
            Assert.AreEqual(200, e.X);
            Assert.AreEqual(0, e.Y);
            Assert.AreEqual(vm.Bullets.Count, 0);

            double prevX = e.X, prevY = e.Y, prevS = e.SpeedY;
            for (int i = 0; i < 40; i++)
            {
                vm.Tick(1);
                Assert.AreEqual(prevX, e.X);
                Assert.IsTrue(prevY <= e.Y);
                Assert.AreEqual(prevS - 0.5, e.SpeedY);
                prevX = e.X;
                prevY = e.Y;
                prevS = e.SpeedY;
            }
            Assert.AreEqual(vm.Bullets.Count, 1);
            for (int i = 0; i < 40; i++)
            {
                vm.Tick(1);
                Assert.AreEqual(prevX, e.X);
                Assert.IsTrue(prevY > e.Y);
                Assert.AreEqual(prevS - 0.5, e.SpeedY);
                prevX = e.X;
                prevY = e.Y;
                prevS = e.SpeedY;
            }
        }

        [UITestMethod]
        public void Enemy2Movement()
        {
            ViewModel vm = new ViewModel();
            double speedX = 3, speedY = 10, theta = -1;
            Enemy2 enemy = new Enemy2(300, 0, speedX, speedY, theta);
            Assert.AreEqual("ms-appx:///Images/enemy2.png",
                                     enemy.Source.UriSource.AbsoluteUri);

            vm.AddEnemy(enemy);

            for (int i = 0; i < 50; i++)
            {
                Assert.AreEqual(300 + speedX * i, enemy.X);
                Assert.AreEqual(speedY * i, enemy.Y);
                Assert.AreEqual(theta * i, enemy.Theta);
                vm.Tick(1);
            }
            vm.Tick(50);
            Assert.AreEqual(0, vm.Enemies.Count);
        }

        [UITestMethod]
        public void Enemy3Movement()
        {
            ViewModel vm = new ViewModel();
            Enemy3 enemy = new Enemy3(200, 0);
            Assert.AreEqual("ms-appx:///Images/enemy3.png",
                enemy.Source.UriSource.AbsoluteUri);

            vm.AddEnemy(enemy);
            Assert.AreEqual(0, enemy.SpeedX);
            Assert.AreEqual(1, enemy.SpeedY);

            Assert.AreEqual(0, vm.Bullets.Count);
            for (int i = 0; i < 100; i += 10)
            {
                Assert.AreEqual(200, enemy.X);
                Assert.AreEqual(i, enemy.Y);
                vm.Tick(10);
            }
            Assert.AreEqual(1, vm.Bullets.Count);

            for (int i = 100; i < 200; i += 10)
            {
                Assert.AreEqual(200, enemy.X);
                Assert.AreEqual(i, enemy.Y);
                vm.Tick(10);
            }
            Assert.AreEqual(1, vm.Bullets.Count);
        }

    }
}
