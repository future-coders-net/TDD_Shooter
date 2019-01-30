using System;
using Windows.System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using TDD_Shooter.Model;

namespace TDD_Shooter.Tests
{
    [TestClass]
    public class ShipMoveTest
    {
        [UITestMethod]
        public void ShipKeyMove()
        {
            ViewModel vm = new ViewModel();
            vm.Ship.X = 100;
            vm.Ship.Y = 100;
            vm.KeyDown(VirtualKey.Left);
            vm.Tick(2);
            Assert.AreEqual(100 - Ship.Speed * 2, vm.Ship.X);
            vm.Tick(2);
            Assert.AreEqual(100 - Ship.Speed * 4, vm.Ship.X);
            vm.KeyUp(VirtualKey.Left);
            vm.Tick(2);
            Assert.AreEqual(100 - Ship.Speed * 4, vm.Ship.X);
        }
    }
}
