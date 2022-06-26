using Zenject;

namespace Selskiyvrach.VampireHunter.Gameplay.Model.Players.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            Container.BindInterfacesAndSelfTo<Player>().FromNew().AsSingle();
    }
}