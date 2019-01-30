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

            Enemy enemy = new Enemy(100, -50);
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

            Enemy enemy = new Enemy(300, 0);
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

    }
}
