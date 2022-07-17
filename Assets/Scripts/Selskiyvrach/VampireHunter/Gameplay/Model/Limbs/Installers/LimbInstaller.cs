using Selskiyvrach.VampireHunter.Gameplay.Model.BulletTargets;
using UnityEngine;
using Zenject;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Limbs.Installers
{
    public abstract class LimbInstaller<T> : MonoInstaller where T : Limb
    {
        [SerializeField] private BulletTargetComponent _bulletTarget;
        [SerializeField] private LimbSettings _limbSettings;

        public override void InstallBindings() => 
            Container.Bind<T>().FromSubContainerResolve().ByMethod(CreateHead);

        private void CreateHead(DiContainer container)
        {
            container.Bind<T>().FromNew().AsSingle();
            container.Bind<IBulletTargetComponent>().To<BulletTargetComponent>().FromInstance(_bulletTarget).AsSingle();
            container.Bind<ILimbSettings>().To<LimbSettings>().FromInstance(_limbSettings).AsSingle();
        }
    }
}