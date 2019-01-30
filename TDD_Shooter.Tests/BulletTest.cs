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
    }
}
