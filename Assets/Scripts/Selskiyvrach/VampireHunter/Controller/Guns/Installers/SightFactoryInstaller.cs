using Selskiyvrach.Core.Factories;
using Selskiyvrach.Core.Zenject;
using Selskiyvrach.VampireHunter.Model.Guns;

namespace Selskiyvrach.VampireHunter.Controller.Guns.Installers
{
    public class SightFactoryInstaller : GenericInstaller<IFactory<ISight>, SightFactory>
    {
    }
}