using Selskiyvrach.Core.Math;

namespace Selskiyvrach.VampireHunter.Combat.Guns
{
    public interface ISight
    {
        Ray GetLineOfSight();
        Ray GetShotProjection();
    }

    public class SimpleSight : ISight
    {
        public Ray GetLineOfSight()
        {
            return new Ray();
        }

        public Ray GetShotProjection()
        {
            return new Ray();
        }
    }
}