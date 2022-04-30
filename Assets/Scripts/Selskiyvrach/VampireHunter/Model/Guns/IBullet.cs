using Selskiyvrach.Core.Math;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public interface IBullet
    {
        IBullet SetTrajectory(Ray trajectory);
        IBullet Launch();
    }

    public class SimpleBullet : IBullet
    {
        public IBullet SetTrajectory(Ray trajectory)
        {
            return this;
        }

        public IBullet Launch()
        {
            return this;
        }
    }
}