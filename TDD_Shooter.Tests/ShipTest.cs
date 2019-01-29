using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using Windows.UI.Xaml.Media.Imaging;
using TDD_Shooter.Model;

namespace TDD_Shooter.Tests
{
    [TestClass]
    public class ShipTest
    {
        [UITestMethod]
        public void ShipPos()
        {
            Ship ship = new Ship();
            ship.X = 100;
            ship.Y = 200;
            Assert.AreEqual(100, ship.X);
            Assert.AreEqual(200, ship.Y);
        }

        [UITestMethod]
        public void ShipSize()
        {
            Ship ship = new Ship();
            Assert.AreEqual(60, ship.Width);
            Assert.AreEqual(60, ship.Height);
        }

        [UITestMethod]
        public void ShipImage()
        {
            Ship ship = new Ship();
            Assert.IsNotNull(ship.Source);
            Assert.IsInstanceOfType(ship.Source, typeof(BitmapImage));
        }

        [UITestMethod]
        public void ViewModelShip()
        {
            ViewModel vm = new ViewModel();
            Assert.AreEqual(60, vm.Ship.Width);
            Assert.AreEqual(60, vm.Ship.Height);
        }

    }
}
