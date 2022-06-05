using Selskiyvrach.VampireHunter.Model.Guns;
using UniRx;

namespace Selskiyvrach.VampireHunter.Model.Gunslingers
{
    public class GunOperator
    {
        private readonly ReactiveProperty<float> _onRecoilKicked = new ReactiveProperty<float>();
        public IReadOnlyReactiveProperty<float> OnRecoilKicked => _onRecoilKicked;

        public MagazineStatus MagazineStatus => _gun.MagazineStatus;
        public bool HammerCocked => _gun.HammerCocked;
        private Gun _gun;

        public void Shoot()
        {
        }

        public void Reload()
        {
        }
    }
}