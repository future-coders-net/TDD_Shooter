using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using TDD_Shooter.Model;

namespace TDD_Shooter.Tests
{
    [TestClass]
    public class BulletTest
    {
        [UITestMethod]
        public void CreateBullet()
        {
            ViewModel vm = new ViewModel();
            Assert.AreEqual(0, vm.Bullets.Count);

            Bullet bullet = new Bullet(100, -50);
            vm.AddBullet(bullet);

            Assert.AreEqual(1, vm.Bullets.Count);
            vm.Tick(200);
            Assert.AreEqual(0, vm.Bullets.Count);
        }

        [UITestMethod]
        public void ShootBullet()
        {
            ViewModel vm = new ViewModel();
            vm.KeyDown(Windows.System.VirtualKey.Space);
            vm.Tick(1);
            Assert.AreEqual(1, vm.Bullets.Count);
            Drawable b = vm.Bullets[0];
            double xPrev = b.X;
            double yPrev = b.Y;
            vm.Tick(1);
            Assert.AreEqual(xPrev, b.X);
            Assert.AreEqual(yPrev + b.SpeedY, b.Y);
        }


        [UITestMethod]
        public void BulletKeyRepeat()
        {
            ViewModel vm = new ViewModel();
            vm.Ship.Y = ViewModel.Field.Height - vm.Ship.Height;
            vm.Ship.X = ViewModel.Field.Width / 2;
            Assert.AreEqual(0, vm.Bullets.Count);

            vm.KeyDown(Windows.System.VirtualKey.Space);
            vm.Tick(1);
            Assert.AreEqual(1, vm.Bullets.Count);
            vm.Tick(5);
            Assert.AreEqual(1, vm.Bullets.Count);
            vm.KeyUp(Windows.System.VirtualKey.Space);
            Assert.AreEqual(1, vm.Bullets.Count);

            vm.Tick(1);
            vm.KeyDown(Windows.System.VirtualKey.Space);
            vm.Tick(1);
            Assert.AreEqual(2, vm.Bullets.Count);

            vm.Tick(100);
            Assert.AreEqual(0, vm.Bullets.Count);
        }

        [UITestMethod]
        public void EnemyShootBullet()
        {
            ViewModel vm = new ViewModel();
            vm.Ship.X = 300 - vm.Ship.Width / 2;
            vm.Ship.Y = 300;

            Enemy0 enemy = new Enemy0(300, 0);
            enemy.X -= enemy.Width / 2;
            vm.AddEnemy(enemy);
            vm.Tick(19);

            Assert.AreEqual(0, vm.Bullets.Count);
            vm.Tick(1);
            Assert.AreEqual(1, vm.Bullets.Count);

            Bullet b = (Bullet)vm.Bullets[0];
            Enemy0 e = (Enemy0)vm.Enemies[0];
            Assert.AreEqual(b.X + b.Width / 2 - 5, e.X + e.Width / 2);
            Assert.AreEqual(b.Y + b.Height / 2 - 5, e.Y + e.Height / 2);

            Assert.IsTrue(vm.Ship.IsValid);
            vm.Tick(20);
            Assert.IsFalse(vm.Ship.IsValid);
        }

    }
}
