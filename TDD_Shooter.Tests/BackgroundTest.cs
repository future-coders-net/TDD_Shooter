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
            vm.Back.Scroll(1);
            Assert.AreEqual(-2527, vm.Back.Y);
        }

        [UITestMethod]
        public void JustScrollWrap()
        {
            ViewModel vm = new ViewModel();
            for (int i = 0; i < 2528; i++)
            {
                vm.Back.Scroll(1);
            }
            Assert.AreEqual(0, vm.Back.Y);
            vm.Back.Scroll(1);
            Assert.AreEqual(-2528, vm.Back.Y);
        }
    }
}
