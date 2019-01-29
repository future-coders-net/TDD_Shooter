using TDD_Shooter.Model;
namespace TDD_Shooter
{
    class ViewModel
    {
        public Ship Ship { get; set; }

        internal ViewModel()
        {
            Ship = new Ship();
        }
    }
}
