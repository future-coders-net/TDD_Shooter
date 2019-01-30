using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using TDD_Shooter.Model;

namespace TDD_Shooter.Tests
{
    [TestClass]
    public class GameLifeCycleTest
    {
        private bool isGameOver;

        [UITestMethod]
        public void CollideEnemy()
        {
            isGameOver = false;
            ViewModel vm = new ViewModel();
            Assert.IsTrue(vm.Ship.IsValid);
            vm.Ship.X = 100;
            vm.Ship.Y = 100;
            vm.Ship.PropertyChanged += Ship_PropertyChanged;
            Enemy enemy = new Enemy(100, 100);
            vm.AddEnemy(enemy);
            vm.Tick(1);
            Assert.IsFalse(vm.Ship.IsValid);
            Assert.IsTrue(isGameOver);
            vm.Ship.PropertyChanged -= Ship_PropertyChanged;
        }

        private void Ship_PropertyChanged(object sender,
            System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsValid" && sender is Ship)
            {
                isGameOver = !((Ship)sender).IsValid;
            }
        }

        [UITestMethod]
        public void ShowMessage()
        {
            ViewModel vm = new ViewModel();
            vm.Message.Text = "PUSH SPACE TO START";
            Assert.AreEqual("PUSH SPACE TO START", vm.Message.Text);
            vm.Tick(10);

            vm.Message.Text = "";
            Assert.AreEqual("", vm.Message.Text);

            vm.Ship.X = 100;
            vm.Ship.Y = 100;
            Enemy enemy = new Enemy(100, 100);
            vm.AddEnemy(enemy);
            vm.Tick(1);
            Assert.AreEqual("GAME OVER", vm.Message.Text);
        }

    }
}
