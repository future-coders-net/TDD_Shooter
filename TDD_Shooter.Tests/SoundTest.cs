using Windows.System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD_Shooter.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;

namespace TDD_Shooter.Tests
{
    [TestClass]
    public class SoundTest
    {
        SoundEffect effect;

        [UITestMethod]
        public void ShootSound()
        {
            ViewModel vm = new ViewModel();
            vm.PlaySound += PlaySoundHandler;

            AssertSoundEffect(vm, VirtualKey.Space, SoundEffect.Shoot);
            AssertSoundEffect(vm, VirtualKey.Up, SoundEffect.None);
            AssertSoundEffect(vm, VirtualKey.Down, SoundEffect.None);
            AssertSoundEffect(vm, VirtualKey.Left, SoundEffect.None);
            AssertSoundEffect(vm, VirtualKey.Right, SoundEffect.None);
        }

        [UITestMethod]
        public void BlastSound()
        {
            ViewModel vm = new ViewModel();
            vm.PlaySound += PlaySoundHandler;
            vm.Ship.X = 300;
            vm.Ship.Y = 300;
            Enemy0 e = new Enemy0(300, 0);
            vm.AddEnemy(e);

            AssertSoundEffect(vm, VirtualKey.Space, SoundEffect.Shoot);
            vm.Tick(50);
            Assert.AreEqual(SoundEffect.Blast, effect);
        }

        private void PlaySoundHandler(SoundEffect obj)
        {
            effect = obj;
        }

        private void AssertSoundEffect(ViewModel vm, VirtualKey key, SoundEffect e)
        {
            effect = SoundEffect.None;
            vm.KeyDown(key);
            vm.Tick(1);
            Assert.AreEqual(e, effect);
        }
    }
}
