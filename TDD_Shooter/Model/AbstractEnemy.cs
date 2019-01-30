namespace TDD_Shooter.Model
{
    abstract class AbstractEnemy : Drawable
    {
        protected int count = 0;

        internal AbstractEnemy(double x, double y,
            double w = 50, double h = 50) : base(w, h) { }

        abstract internal bool IsFire { get; }
    }
}
