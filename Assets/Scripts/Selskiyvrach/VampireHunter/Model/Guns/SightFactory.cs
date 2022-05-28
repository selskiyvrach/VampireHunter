using Selskiyvrach.Core;
using Selskiyvrach.Core.Factories;
using Selskiyvrach.Core.Screen;
using Selskiyvrach.VampireHunter.Model.Crosshairs;
using Selskiyvrach.VampireHunter.Model.Stats;

namespace Selskiyvrach.VampireHunter.Model.Guns
{
    public class SightFactory : Factory<ISight>
    {
        private readonly IAimingSettings _aimingSettings;
        private readonly IRandomPointInUnitCircleGenerator _pointInUnitCircleGenerator;
        private readonly IStatProvider _statProvider;
        private readonly IScreen _screen;

        public SightFactory(
            IAimingSettings aimingSettings, 
            IRandomPointInUnitCircleGenerator pointInUnitCircleGenerator, 
            IStatProvider statProvider, 
            IScreen screen)
        {
            _aimingSettings = aimingSettings;
            _pointInUnitCircleGenerator = pointInUnitCircleGenerator;
            _statProvider = statProvider;
            _screen = screen;
        }

        public override ISight Create() =>
            new Sight(
                _statProvider,
                _aimingSettings,
                _pointInUnitCircleGenerator, 
                _screen);
    }
}