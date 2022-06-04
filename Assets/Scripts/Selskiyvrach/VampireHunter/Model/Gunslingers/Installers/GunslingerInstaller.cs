using Selskiyvrach.Core.Zenject;

namespace Selskiyvrach.VampireHunter.Model.Gunslingers.Installers
{
    public class GunslingerInstaller : GenericInstaller<Gunslinger>
    {
        public override void InstallBindings() => 
            Container.Bind<Gunslinger>().AsSingle();
    }
}