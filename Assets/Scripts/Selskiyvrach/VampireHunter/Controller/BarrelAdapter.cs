using Selskiyvrach.Core.Maths;
using Selskiyvrach.VampireHunter.Model.Guns;
using Selskiyvrach.VampireHunter.View.Combat;

namespace Selskiyvrach.VampireHunter.Controller
{
    public class BarrelAdapter : IBarrel
    {
        private readonly Barrel _barrel;

        public BarrelAdapter(Barrel barrel)
        {
            _barrel = barrel;
        }

        public Vector3 ShootPoint => _barrel.BulletStartPoint.position.ToProject();
    }
}