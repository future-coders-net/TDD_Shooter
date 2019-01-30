using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
namespace TDD_Shooter.Tests
{
    [TestClass]
    public class BackgroundTest
    {
        [UITestMethod]
        public void JustScroll()
        {
            ViewModel vm = new ViewModel();
            Assert.AreEqual(-2528, vm.Back.Y);
            vm.Back.Tick();
            Assert.AreEqual(-2527, vm.Back.Y);
        }

        [UITestMethod]
        public void JustScrollWrap()
        {
            ViewModel vm = new ViewModel();
            for (int i = 0; i < 2528; i++)
            {
                vm.Back.Tick();
            }
            Assert.AreEqual(0, vm.Back.Y);
            vm.Back.Tick();
            Assert.AreEqual(-2528, vm.Back.Y);
        }

        [UITestMethod]
        public void CloudScroll()
        {
            ViewModel vm = new ViewModel();
            Assert.AreEqual(-2528, vm.Cloud.Y);
            vm.Cloud.Tick();
            Assert.AreEqual(-2526, vm.Cloud.Y);
        }

        [UITestMethod]
        public void CloudScrollWrap()
        {
            ViewModel vm = new ViewModel();
            for (int i = 0; i < 2528 / 2; i++)
            {
                vm.Cloud.Tick();
            }
            Assert.AreEqual(0, vm.Cloud.Y);
            vm.Cloud.Tick();
            Assert.AreEqual(-2528, vm.Cloud.Y);
        }
    }
}
